/* WebSiteAdvantage KeePass to Firefox
 * Copyright (C) 2008 - 2012  Anthony James McCreath
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

using NLog;

using WebSiteAdvantage.KeePass.Firefox.Logging;
using WebSiteAdvantage.KeePass.Firefox.Profiles;
using WebSiteAdvantage.KeePass.Firefox.Signons;
using WebSiteAdvantage.KeePass.Firefox.Utilities;

namespace WebSiteAdvantage.KeePass.Firefox.Converter
{
    public delegate void LogProgressDeligate(int percent);
    public delegate void ThreadFinishedDeligate(Exception ex);

    public partial class Form1 : Form
    {
        private const string AutoTypeSequence = "{USERNAME}{TAB}{PASSWORD}{ENTER}";
        private const int MaxTitleLength = 15;

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private static readonly string Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        #region Constructor

        public Form1()
        {
            InitializeComponent();

            iconComboBox.SelectedIndex = 16;
        }

        #endregion

        #region Thread Management

        private Thread thread;

        protected void StopThread()
        {
            if (thread != null)
            {
                thread.Abort();
                thread = null;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            StopThread();
            base.OnClosing(e);
        }

        #endregion

        #region Thread Events

        /// <summary>
        /// thread safe way to update the porgress bar
        /// </summary>
        /// <param name="percent"></param>
        protected void LogProgress(int percent)
        {
            if (InvokeRequired)
                Invoke(new LogProgressDeligate(LogProgress), percent);
            else
                progressBar.Value = percent;
        }

        /// <summary>
        /// Call this at the end of any thread execution
        /// if theres an exception it will warn the user otherwise it will indicate success
        /// </summary>
        /// <param name="ex"></param>
        protected void ThreadFinished(Exception ex)
        {
            if (InvokeRequired)
            {
                Invoke(new ThreadFinishedDeligate(ThreadFinished), ex);
            }
            else
            {
                startButton.Text = "Start";
                thread = null;
                settingsTab.Enabled = true;

                if (ex == null)
                {
                    // success
                    MessageBox.Show("KeePass file successfully created", "Converted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (ex is ThreadAbortException)
                    {
                        MessageBox.Show("Stopped", "Converting", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (ex.Message.Contains("Failed to Validate Password"))
                            MessageBox.Show(ex.Message, "Converting Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            ErrorDialog.Show("Converting Failed", ex);

                        Logger.Error(ex);
                    }
                }
            }
        }
        #endregion

        #region Data for Thread

        private string keePassFile;

        /// <summary>
        /// The file to store the result in
        /// </summary>
        public string KeePassFile
        {
            get => keePassFile;
            set => keePassFile = Path.HasExtension(value) ? value : value + ".xml";
        }

        /// <summary>
        /// The file to load from if using xml exported data
        /// </summary>
        public string FirefoxFile { get; set; }

        /// <summary>
        /// If the internet should be used to get titles
        /// </summary>
        public bool GetTitles { get; set; }

        /// <summary>
        /// Should auttype data be added
        /// </summary>
        public bool GenerateAutoType { get; set; }

        /// <summary>
        /// The name of the group to store the entries
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// The id of the icon to use with all entries
        /// </summary>
        public int IconId { get; set; }

        /// <summary>
        /// password to use when accessing firefox
        /// </summary>
        public string FirefoxMasterPassword { get; set; }

        /// <summary>
        /// the path to the selected profile
        /// </summary>
        public string ProfilePath { get; set; }

        #endregion

        #region Generators

        /// <summary>
        /// Create the keepass file using an exported firefox file
        /// </summary>
        private void GenerateUsingExport()
        {
            try
            {
                // load in the firefox xml document
                var fireFoxDocument = new XmlDocument();
                FileStream fileStream = File.Open(FirefoxFile, FileMode.Open, FileAccess.Read);
                try
                {
                    var settings = new XmlReaderSettings
                    {
                        CheckCharacters = false,
                        ValidationType = ValidationType.None
                    };

                    XmlReader reader = XmlReader.Create(fileStream, settings);

                    try
                    {
                        fireFoxDocument.Load(reader);
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to load the password file. " + Environment.NewLine +
                        "This may be due to the presence of foreign characters in the data. " + Environment.NewLine +
                        "Please check the website for help" + Environment.NewLine + Environment.NewLine + ex.Message, ex);
                }
                finally
                {
                    fileStream.Close();
                }

                // get a list of each password node
                XmlNodeList fireFoxEntryNodes = fireFoxDocument.SelectNodes("xml/entries/entry");

                // the output xml document
                XmlDocument keePassDocument = new XmlDocument();

                XmlElement keePassRootElement = keePassDocument.CreateElement("pwlist");
                keePassDocument.AppendChild(keePassRootElement);

                int current = 0;
                int max = fireFoxEntryNodes.Count;
                // loop each input password and generate the output password
                foreach (XmlElement fireFoxEntryElement in fireFoxEntryNodes)
                {
                    current++;

                    string title = fireFoxEntryElement.SelectSingleNode("@host").InnerText;

                    string url = title;

                    string formSubmitUrl = fireFoxEntryElement.SelectSingleNode("@formSubmitURL").InnerText;

                    if (!string.IsNullOrEmpty(formSubmitUrl))
                        url = formSubmitUrl;

                    string host = url;
                    try
                    {
                        Uri uri = new Uri(url);
                        host = uri.Host;
                    }
                    catch { }

                    string internetTitle = null;

                    if (GetTitles)
                    {
                        (internetTitle, _) = await WebScraper.ScrapeAsync(url, scrapeIcon: false);

                        if (!string.IsNullOrEmpty(internetTitle))
                            title = internetTitle;
                    }

                    string notes = string.Empty;

                    if (importNotesCheckBox.Checked)
                    {
                        notes +=
                            "Imported from FireFox by the Web Site Advantage Firefox To KeePass Importer" + Environment.NewLine + Environment.NewLine +
                            "UserNameField=" + fireFoxEntryElement.SelectSingleNode("@userFieldName").InnerText + System.Environment.NewLine +
                            "PasswordField=" + fireFoxEntryElement.SelectSingleNode("@passFieldName").InnerText + System.Environment.NewLine +
                            "LoginFormDomain=" + fireFoxEntryElement.SelectSingleNode("@formSubmitURL").InnerText + System.Environment.NewLine;
                    }

                    if (GenerateAutoType)
                    {
                        if (!string.IsNullOrEmpty(internetTitle))
                        {
                            notes += Environment.NewLine +
                                "Auto-Type: " + AutoTypeSequence + Environment.NewLine +
                                "Auto-Type-Window: *" + host + "*" + Environment.NewLine +
                                "Auto-Type-Window: " + (internetTitle.Length < MaxTitleLength ? internetTitle : internetTitle.Substring(0, MaxTitleLength)) + "*" + Environment.NewLine;
                        }
                        else
                        {
                            notes += Environment.NewLine +
                                "Auto-Type: " + AutoTypeSequence + Environment.NewLine +
                                "Auto-Type-Window: *" + host + "*" + Environment.NewLine;
                        }
                    }

                    string now = XmlConvert.ToString(DateTime.Now, "yyyy-MM-ddTHH:mm:ss");

                    // create the xml

                    XmlElement keePassEntryElement = keePassDocument.CreateElement("pwentry");
                    keePassRootElement.AppendChild(keePassEntryElement);

                    XmlElement keePassGroupElement = keePassDocument.CreateElement("group");
                    keePassEntryElement.AppendChild(keePassGroupElement);
                    keePassGroupElement.InnerText = GroupName;

                    // set the group the password gets stored in
                    if (!string.IsNullOrEmpty(GroupName))
                        keePassGroupElement.SetAttribute("tree", GroupName);

                    XmlElement keePassTitleElement = keePassDocument.CreateElement("title");
                    keePassEntryElement.AppendChild(keePassTitleElement);
                    keePassTitleElement.InnerText = title;

                    XmlElement keePassUserNameElement = keePassDocument.CreateElement("username");
                    keePassEntryElement.AppendChild(keePassUserNameElement);
                    keePassUserNameElement.InnerText = fireFoxEntryElement.SelectSingleNode("@user").InnerText;

                    XmlElement keePassUrlElement = keePassDocument.CreateElement("url");
                    keePassEntryElement.AppendChild(keePassUrlElement);
                    keePassUrlElement.InnerText = fireFoxEntryElement.SelectSingleNode("@host").InnerText;


                    XmlElement keePassPasswordElement = keePassDocument.CreateElement("password");
                    keePassEntryElement.AppendChild(keePassPasswordElement);
                    keePassPasswordElement.InnerText = fireFoxEntryElement.SelectSingleNode("@password").InnerText;

                    // put other stuff in the notes
                    if (!string.IsNullOrEmpty(notes))
                    {
                        XmlElement keePassNotesElement = keePassDocument.CreateElement("notes");
                        keePassEntryElement.AppendChild(keePassNotesElement);

                        XmlCDataSection cd = keePassDocument.CreateCDataSection(notes);
                        keePassNotesElement.AppendChild(cd);
                    }

                    XmlElement keePassUuidElement = keePassDocument.CreateElement("uuid");
                    keePassEntryElement.AppendChild(keePassUuidElement);
                    keePassUuidElement.InnerText = Guid.NewGuid().ToString().Replace("-", "").ToLower(); // condensed guid

                    XmlElement keePassImageElement = keePassDocument.CreateElement("image");
                    keePassEntryElement.AppendChild(keePassImageElement);
                    keePassImageElement.InnerText = IconId.ToString();

                    XmlElement keePassCreatedElement = keePassDocument.CreateElement("creationtime");
                    keePassEntryElement.AppendChild(keePassCreatedElement);
                    keePassCreatedElement.InnerText = now;

                    XmlElement keePassModifiedElement = keePassDocument.CreateElement("lastmodtime");
                    keePassEntryElement.AppendChild(keePassModifiedElement);
                    keePassModifiedElement.InnerText = now;

                    XmlElement keePassAccessedElement = keePassDocument.CreateElement("lastaccesstime");
                    keePassEntryElement.AppendChild(keePassAccessedElement);
                    keePassAccessedElement.InnerText = now;

                    // so it does not expire
                    XmlElement keePassExpiresElement = keePassDocument.CreateElement("expiretime");
                    keePassEntryElement.AppendChild(keePassExpiresElement);
                    keePassExpiresElement.SetAttribute("expires", "false");
                    keePassExpiresElement.InnerText = "2999-12-28T23:59:59";

                    LogProgress((int) ((double) current * 100 / max));
                }

                XmlTextWriter writer = new XmlTextWriter(KeePassFile, Encoding.UTF8);
                try
                {
                    writer.Formatting = Formatting.Indented;
                    keePassDocument.Save(writer);
                }
                finally
                {
                    writer.Close();
                }

                ThreadFinished(null);
            }
            catch (Exception ex)
            {
                ThreadFinished(ex);
            }

        }

        /// <summary>
        /// generates a keepass xml file by directly accessing firefoxes passwords
        /// designed to be used in a thread
        /// uses the thread
        /// </summary>
        private void GenerateUsingFirefox()
        {
            try
            {
                var profile = new Profile(ProfilePath, FirefoxMasterPassword);
                Signon[] signons = profile.GetSignons().ToArray();

                // the group to store the passwords

                // the output xml document
                XmlDocument keePassDocument = new XmlDocument();

                XmlElement keePassRootElement = keePassDocument.CreateElement("pwlist");
                keePassDocument.AppendChild(keePassRootElement);

                int current = 0;
                int max = signons.Length;
                // loop each input password and generate the output password
                foreach (Signon signon in signons)
                {
                    current++;

                    string siteTitle = null;

                    if (GetTitles)
                        (siteTitle, _) = await WebScraper.ScrapeAsync(signon.Site, scrapeIcon: false);

                    foreach (FirefoxSignon signon in signon.Signons)
                    {
                        string title = siteTitle ?? signon.Site;

                        if (!string.IsNullOrEmpty(signon.LoginFormDomain))
                            title = signon.LoginFormDomain;

                        string host = null;
                        try
                        {
                            Uri uri = new Uri(signon.Site);
                            host = uri.Host;
                        }
                        catch { }

                        if (GetTitles)
                        {
                            // get the pages title

                            string internetTitle = null;

                            if (string.IsNullOrEmpty(signon.LoginFormDomain) || signon.LoginFormDomain == signon.Site)
                                internetTitle = siteTitle;
                            else
                                (internetTitle, _) = await WebScraper.ScrapeAsync(signon.LoginFormDomain, scrapeIcon: false);

                            if (!string.IsNullOrEmpty(internetTitle))
                            {
                                title = internetTitle;
                            }

                        }

                        string notes = string.Empty;

                        if (importNotesCheckBox.Checked)
                        {
                            notes += "Imported from FireFox by the Web Site Advantage Firefox To KeePass" + Environment.NewLine;
                        }

                        if (GenerateAutoType)
                        {
                            if (GetTitles)
                            {

                                notes += Environment.NewLine  +
                                    "Auto-Type: " + AutoTypeSequence + Environment.NewLine +
                                    (string.IsNullOrEmpty(host) ? string.Empty : "Auto-Type-Window: *" + host + "*" + Environment.NewLine) +
                                    "Auto-Type-Window: " + (title?.Length < MaxTitleLength ? title : title?.Substring(0, MaxTitleLength)) + "*" + Environment.NewLine;

                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(host))
                                {
                                    notes += Environment.NewLine  +
                                        "Auto-Type: " + AutoTypeSequence + Environment.NewLine +
                                        "Auto-Type-Window: *" + host + "*" + Environment.NewLine;
                                }
                            }
                        }


                        string now = XmlConvert.ToString(DateTime.UtcNow, "yyyy-MM-ddTHH:mm:ssK");

                        // create xml

                        XmlElement keePassEntryElement = keePassDocument.CreateElement("pwentry");
                        keePassRootElement.AppendChild(keePassEntryElement);

                        XmlElement keePassGroupElement = keePassDocument.CreateElement("group");
                        keePassEntryElement.AppendChild(keePassGroupElement);
                        keePassGroupElement.InnerText = GroupName;

                        // set the group the password gets stored in
                        if (!string.IsNullOrEmpty(GroupName))
                            keePassGroupElement.SetAttribute("tree", GroupName);

                        XmlElement keePassTitleElement = keePassDocument.CreateElement("title");
                        keePassEntryElement.AppendChild(keePassTitleElement);
                        keePassTitleElement.InnerText = title;

                        XmlElement keePassUserNameElement = keePassDocument.CreateElement("username");
                        keePassEntryElement.AppendChild(keePassUserNameElement);
                        keePassUserNameElement.InnerText = signon.UserName;

                        XmlElement keePassUrlElement = keePassDocument.CreateElement("url");
                        keePassEntryElement.AppendChild(keePassUrlElement);
                        keePassUrlElement.InnerText = signon.Site;

                        XmlElement keePassPasswordElement = keePassDocument.CreateElement("password");
                        keePassEntryElement.AppendChild(keePassPasswordElement);
                        keePassPasswordElement.InnerText = signon.Password;

                        if (!string.IsNullOrEmpty(notes))
                        {
                            // put other stuff in the notes
                            XmlElement keePassNotesElement = keePassDocument.CreateElement("notes");
                            keePassEntryElement.AppendChild(keePassNotesElement);

                            //	keePassNotesElement.InnerText =

                            XmlCDataSection cd = keePassDocument.CreateCDataSection(notes);
                            keePassNotesElement.AppendChild(cd);
                        }

                        XmlElement keePassUuidElement = keePassDocument.CreateElement("uuid");
                        keePassEntryElement.AppendChild(keePassUuidElement);
                        keePassUuidElement.InnerText = Guid.NewGuid().ToString().Replace("-", "").ToLower(); // condensed guid

                        XmlElement keePassImageElement = keePassDocument.CreateElement("image");
                        keePassEntryElement.AppendChild(keePassImageElement);
                        keePassImageElement.InnerText = IconId.ToString();


                        XmlElement keePassCreatedElement = keePassDocument.CreateElement("creationtime");
                        keePassEntryElement.AppendChild(keePassCreatedElement);
                        keePassCreatedElement.InnerText = signon.TimeCreated?.ToString("yyyy-MM-ddTHH:mm:ssK") ?? now;

                        XmlElement keePassModifiedElement = keePassDocument.CreateElement("lastmodtime");
                        keePassEntryElement.AppendChild(keePassModifiedElement);
                        keePassModifiedElement.InnerText = signon.TimePasswordChanged?.ToString("yyyy-MM-ddTHH:mm:ssK") ?? now;

                        XmlElement keePassAccessedElement = keePassDocument.CreateElement("lastaccesstime");
                        keePassEntryElement.AppendChild(keePassAccessedElement);
                        keePassAccessedElement.InnerText = signon.TimeLastUsed?.ToString("yyyy-MM-ddTHH:mm:ssK") ?? now;

                        // so it does not expire
                        XmlElement keePassExpiresElement = keePassDocument.CreateElement("expiretime");
                        keePassEntryElement.AppendChild(keePassExpiresElement);
                        keePassExpiresElement.SetAttribute("expires", "false");
                        keePassExpiresElement.InnerText = "2999-12-28T23:59:59";

                        LogProgress((int) ((double) current * 100 / max));
                    }
                }


                // save the xml. this way the encoding header is included...
                XmlTextWriter writer = new XmlTextWriter(KeePassFile, Encoding.UTF8);
                try
                {
                    writer.Formatting = Formatting.Indented;
                    keePassDocument.Save(writer);
                }
                finally
                {
                    writer.Close();
                }

                ThreadFinished(null);


            }
            catch (Exception ex)
            {
                ThreadFinished(ex);
            }

        }

        #endregion

        #region GUI Events to Thread start Generators

        /// <summary>
        /// gathers the required data then starts the appropriate thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartClickEventHandler(object sender, EventArgs e)
        {
            LogProgress(0); // reset the progress bar

            if (groupTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("A group is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (thread != null)
                {
                    StopThread();
                    startButton.Text = "Start";
                    //		this.progressBar1.Visible = false;
                    settingsTab.Enabled = true;
                }
                else
                {
                    GetTitles = scrapeTitlesCheckBox.Checked;
                    GenerateAutoType = autoTypeCheckBox.Checked;
                    GroupName = groupTextBox.Text.Trim();
                    IconId = iconComboBox.SelectedIndex;
                    FirefoxMasterPassword = passwordTextBox.Text;



                    if (importFirefoxRadioButton.Checked)
                    {
                        if (profileComboBox.SelectedItem != null)
                        {
                            ProfilePath = ((FirefoxProfileInfo)profileComboBox.SelectedItem).AbsolutePath;
                        }
                        else
                        {
                            MessageBox.Show("No Profile Selected. Use Load More Profiles", "Profile Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        var saveFileDialog = new SaveFileDialog
                        {
                            Title = "Save KeePass file as...",
                            Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*",
                            FilterIndex = 1,
                            RestoreDirectory = true,
                            DefaultExt = "xml"
                        };


                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            KeePassFile = saveFileDialog.FileName;
                            thread = new Thread(GenerateUsingFirefox);
                        }
                    }
                    else
                    {
                        var openFileDialog1 = new OpenFileDialog
                        {
                            Title = "Select the exported Firefox password file",
                            Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*",
                            FilterIndex = 1,
                            RestoreDirectory = true
                        };


                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            FirefoxFile = openFileDialog1.FileName;

                            var saveFileDialog = new SaveFileDialog
                            {
                                Title = "Save KeePass file as...",
                                Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*",
                                FilterIndex = 1,
                                RestoreDirectory = true,
                                DefaultExt = "xml"
                            };


                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                KeePassFile = saveFileDialog.FileName;

                                thread = new Thread(GenerateUsingExport);
                            }
                        }
                    }

                    if (thread != null)
                    {
                        thread.Name = "Converter";
                //		this.progressBar1.Visible = true;
                        thread.Start();

                        startButton.Text = "Stop";
                        settingsTab.Enabled = false;
                    }
                }
            }
        }
        #endregion

        #region GUI Events

        private void HomeLinkClickedEventHandler(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://websiteadvantage.com.au/Firefox-KeePass-Password-Import#utm_source=keepassfirefox&utm_medium=application&utm_content=link&utm_campaign=converter-" + Version);
        }

        /// <summary>
        /// closes the window after making sure the thread has stopped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelClickEventHandler(object sender, EventArgs e)
        {
            StopThread();
            Close();
        }

        private void ImportFirefoxChangedEventHandler(object sender, EventArgs e)
        {
            firefoxSettings.Enabled = importFirefoxRadioButton.Checked;
        }

        private void ExtensionLinkClickedEventHandler(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://addons.mozilla.org/en-US/firefox/addon/2848");
        }

        private void HelpClickEventHandler(object sender, EventArgs e)
        {
            Process.Start("https://websiteadvantage.com.au/Firefox-KeePass-Password-Import#utm_source=keepassfirefox&utm_medium=application&utm_content=help&utm_campaign=converter-" + Version);
        }

        private void PluginLinkClickedEventHandler(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://keepass.info/plugins.html#xmlimport");
        }

        private void Form1LoadEventHandler(object sender, EventArgs e)
        {
            LoggerService.Initialise();

            List<FirefoxProfileInfo> profiles = FirefoxProfileInfo.FindFirefoxProfileInfos();
            profileComboBox.DataSource = profiles;
            profileComboBox.DisplayMember = "Name";

            Text = $"Web Site Advantage Firefox to KeePass Converter ({Version})";

            foreach (FirefoxProfileInfo profile in profiles)
            {
                if (profile.Default)
                {
                    this.profileComboBox.SelectedItem = profile;
                    break;
                }
            }

        }

        private void FindProfilesClickEventHandler(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Yes - If you wish to load profiles via the profiles ini file."+ Environment.NewLine+
                "No  - To directly select a profiles folder.",
                "Load Profiles ini file?",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);


            if (result == DialogResult.Yes)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.Title = "Select a Firefox Profiles.ini file";
                openFileDialog1.Filter = "INI files (*.ini)|*.ini|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                //   openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    List<FirefoxProfileInfo> list = (List<FirefoxProfileInfo>)profileComboBox.DataSource;
                    FirefoxProfileInfo.FindFirefoxProfileInfosFromIniFile(openFileDialog1.FileName, list);

                    // get it to refresh!
                    profileComboBox.DataSource = null;
                    profileComboBox.DataSource = list;
                }
            }

            if (result == DialogResult.No)
            {
                FolderBrowserDialog openFolderDialog1 = new FolderBrowserDialog();

                openFolderDialog1.Description = "Select a Firefox Profile folder";
                openFolderDialog1.ShowNewFolderButton = false;


                if (openFolderDialog1.ShowDialog() == DialogResult.OK)
                {

                    List<FirefoxProfileInfo> list = (List<FirefoxProfileInfo>)this.profileComboBox.DataSource;
                    FirefoxProfileInfo profile = new FirefoxProfileInfo();

                    profile.Name = openFolderDialog1.SelectedPath.Substring(openFolderDialog1.SelectedPath.LastIndexOf(@"\")+1);
                    profile.Path = openFolderDialog1.SelectedPath;
                    profile.Default = false;
                    profile.IsRelative = false;

                    list.Add(profile);

                    // get it to refresh!
                    this.profileComboBox.DataSource = null;
                    this.profileComboBox.DataSource = list;
                }
            }
        }

        private void DonateClickEventHandler(object sender, EventArgs e)
        {
            Process.Start("https://websiteadvantage.com.au/Firefox-KeePass-Password-Import#utm_source=keepassfirefox&utm_medium=application&utm_content=help&utm_campaign=converterdonate-" + Version);
        }

        #endregion
    }
}
