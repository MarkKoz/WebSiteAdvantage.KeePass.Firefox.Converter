namespace WebSiteAdvantage.KeePass.Firefox.Converter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupTextBox = new System.Windows.Forms.TextBox();
            this.groupLabel = new System.Windows.Forms.Label();
            this.settingsTab = new System.Windows.Forms.TabControl();
            this.settingsPage = new System.Windows.Forms.TabPage();
            this.methodSettings = new System.Windows.Forms.GroupBox();
            this.extensionLink = new System.Windows.Forms.LinkLabel();
            this.importXmlRadioButton = new System.Windows.Forms.RadioButton();
            this.importFirefoxRadioButton = new System.Windows.Forms.RadioButton();
            this.scraperSettings = new System.Windows.Forms.GroupBox();
            this.scrapeTitlesCheckBox = new System.Windows.Forms.CheckBox();
            this.warningContainer = new System.Windows.Forms.GroupBox();
            this.warningMessage = new System.Windows.Forms.Label();
            this.keePassSettings = new System.Windows.Forms.GroupBox();
            this.importNotesCheckBox = new System.Windows.Forms.CheckBox();
            this.autoTypeCheckBox = new System.Windows.Forms.CheckBox();
            this.groupNote = new System.Windows.Forms.Label();
            this.keePassLogo = new System.Windows.Forms.PictureBox();
            this.iconComboBox = new System.Windows.Forms.ComboBox();
            this.iconLabel = new System.Windows.Forms.Label();
            this.firefoxSettings = new System.Windows.Forms.GroupBox();
            this.findProfilesButton = new System.Windows.Forms.Button();
            this.profileComboBox = new System.Windows.Forms.ComboBox();
            this.profileLabel = new System.Windows.Forms.Label();
            this.firefoxLogo = new System.Windows.Forms.PictureBox();
            this.passwordNote = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.homeLink = new System.Windows.Forms.LinkLabel();
            this.description = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.ListBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.pluginLink = new System.Windows.Forms.LinkLabel();
            this.donateButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.settingsTab.SuspendLayout();
            this.settingsPage.SuspendLayout();
            this.methodSettings.SuspendLayout();
            this.scraperSettings.SuspendLayout();
            this.warningContainer.SuspendLayout();
            this.keePassSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keePassLogo)).BeginInit();
            this.firefoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.firefoxLogo)).BeginInit();
            this.SuspendLayout();
            //
            // groupTextBox
            //
            this.groupTextBox.Location = new System.Drawing.Point(106, 18);
            this.groupTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.groupTextBox.Name = "groupTextBox";
            this.groupTextBox.Size = new System.Drawing.Size(113, 20);
            this.groupTextBox.TabIndex = 12;
            this.groupTextBox.Text = "General";
            //
            // groupLabel
            //
            this.groupLabel.AutoSize = true;
            this.groupLabel.Location = new System.Drawing.Point(17, 21);
            this.groupLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.groupLabel.Name = "groupLabel";
            this.groupLabel.Size = new System.Drawing.Size(36, 13);
            this.groupLabel.TabIndex = 11;
            this.groupLabel.Text = "Group";
            //
            // settingsTab
            //
            this.settingsTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsTab.Controls.Add(this.settingsPage);
            this.settingsTab.Location = new System.Drawing.Point(12, 101);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.SelectedIndex = 0;
            this.settingsTab.Size = new System.Drawing.Size(512, 443);
            this.settingsTab.TabIndex = 19;
            //
            // settingsPage
            //
            this.settingsPage.Controls.Add(this.methodSettings);
            this.settingsPage.Controls.Add(this.scraperSettings);
            this.settingsPage.Controls.Add(this.keePassSettings);
            this.settingsPage.Controls.Add(this.firefoxSettings);
            this.settingsPage.Location = new System.Drawing.Point(4, 22);
            this.settingsPage.Name = "settingsPage";
            this.settingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.settingsPage.Size = new System.Drawing.Size(504, 417);
            this.settingsPage.TabIndex = 0;
            this.settingsPage.Text = "Settings";
            this.settingsPage.UseVisualStyleBackColor = true;
            //
            // methodSettings
            //
            this.methodSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.methodSettings.Controls.Add(this.extensionLink);
            this.methodSettings.Controls.Add(this.importXmlRadioButton);
            this.methodSettings.Controls.Add(this.importFirefoxRadioButton);
            this.methodSettings.Location = new System.Drawing.Point(3, 6);
            this.methodSettings.Name = "methodSettings";
            this.methodSettings.Size = new System.Drawing.Size(492, 81);
            this.methodSettings.TabIndex = 31;
            this.methodSettings.TabStop = false;
            this.methodSettings.Text = "Method";
            //
            // extensionLink
            //
            this.extensionLink.AutoSize = true;
            this.extensionLink.Location = new System.Drawing.Point(263, 46);
            this.extensionLink.Name = "extensionLink";
            this.extensionLink.Size = new System.Drawing.Size(178, 13);
            this.extensionLink.TabIndex = 2;
            this.extensionLink.TabStop = true;
            this.extensionLink.Text = "Firefox Password Exporter Extension";
            this.extensionLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ExtensionLinkClickedEventHandler);
            //
            // importXmlRadioButton
            //
            this.importXmlRadioButton.AutoSize = true;
            this.importXmlRadioButton.Location = new System.Drawing.Point(15, 44);
            this.importXmlRadioButton.Name = "importXmlRadioButton";
            this.importXmlRadioButton.Size = new System.Drawing.Size(257, 17);
            this.importXmlRadioButton.TabIndex = 1;
            this.importXmlRadioButton.Text = "Read the data from a password file generated by ";
            this.importXmlRadioButton.UseVisualStyleBackColor = true;
            //
            // importFirefoxRadioButton
            //
            this.importFirefoxRadioButton.AutoSize = true;
            this.importFirefoxRadioButton.Checked = true;
            this.importFirefoxRadioButton.Location = new System.Drawing.Point(15, 20);
            this.importFirefoxRadioButton.Name = "importFirefoxRadioButton";
            this.importFirefoxRadioButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.importFirefoxRadioButton.Size = new System.Drawing.Size(204, 17);
            this.importFirefoxRadioButton.TabIndex = 0;
            this.importFirefoxRadioButton.TabStop = true;
            this.importFirefoxRadioButton.Text = "Directly use Firefox to gather the data.";
            this.importFirefoxRadioButton.UseVisualStyleBackColor = true;
            this.importFirefoxRadioButton.CheckedChanged += new System.EventHandler(this.ImportFirefoxChangedEventHandler);
            //
            // scraperSettings
            //
            this.scraperSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scraperSettings.Controls.Add(this.scrapeTitlesCheckBox);
            this.scraperSettings.Controls.Add(this.warningContainer);
            this.scraperSettings.Location = new System.Drawing.Point(3, 316);
            this.scraperSettings.Name = "scraperSettings";
            this.scraperSettings.Size = new System.Drawing.Size(492, 92);
            this.scraperSettings.TabIndex = 30;
            this.scraperSettings.TabStop = false;
            this.scraperSettings.Text = "Internet Access";
            //
            // scrapeTitlesCheckBox
            //
            this.scrapeTitlesCheckBox.AutoSize = true;
            this.scrapeTitlesCheckBox.Location = new System.Drawing.Point(20, 19);
            this.scrapeTitlesCheckBox.Name = "scrapeTitlesCheckBox";
            this.scrapeTitlesCheckBox.Size = new System.Drawing.Size(156, 17);
            this.scrapeTitlesCheckBox.TabIndex = 24;
            this.scrapeTitlesCheckBox.Text = "Get Titles from the websites";
            this.scrapeTitlesCheckBox.UseVisualStyleBackColor = true;
            //
            // warningContainer
            //
            this.warningContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.warningContainer.BackColor = System.Drawing.Color.Transparent;
            this.warningContainer.Controls.Add(this.warningMessage);
            this.warningContainer.ForeColor = System.Drawing.Color.Red;
            this.warningContainer.Location = new System.Drawing.Point(327, 19);
            this.warningContainer.Name = "warningContainer";
            this.warningContainer.Size = new System.Drawing.Size(152, 62);
            this.warningContainer.TabIndex = 23;
            this.warningContainer.TabStop = false;
            this.warningContainer.Text = "Warning";
            //
            // warningMessage
            //
            this.warningMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.warningMessage.ForeColor = System.Drawing.Color.Maroon;
            this.warningMessage.Location = new System.Drawing.Point(3, 16);
            this.warningMessage.Name = "warningMessage";
            this.warningMessage.Size = new System.Drawing.Size(146, 43);
            this.warningMessage.TabIndex = 20;
            this.warningMessage.Text = "You have to trust me if you allow this plugin to access the internet!";
            //
            // keePassSettings
            //
            this.keePassSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keePassSettings.Controls.Add(this.importNotesCheckBox);
            this.keePassSettings.Controls.Add(this.autoTypeCheckBox);
            this.keePassSettings.Controls.Add(this.groupNote);
            this.keePassSettings.Controls.Add(this.keePassLogo);
            this.keePassSettings.Controls.Add(this.iconComboBox);
            this.keePassSettings.Controls.Add(this.iconLabel);
            this.keePassSettings.Controls.Add(this.groupTextBox);
            this.keePassSettings.Controls.Add(this.groupLabel);
            this.keePassSettings.Location = new System.Drawing.Point(3, 208);
            this.keePassSettings.Name = "keePassSettings";
            this.keePassSettings.Size = new System.Drawing.Size(492, 102);
            this.keePassSettings.TabIndex = 29;
            this.keePassSettings.TabStop = false;
            this.keePassSettings.Text = "KeePass";
            //
            // importNotesCheckBox
            //
            this.importNotesCheckBox.AutoSize = true;
            this.importNotesCheckBox.Checked = true;
            this.importNotesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.importNotesCheckBox.Location = new System.Drawing.Point(157, 79);
            this.importNotesCheckBox.Name = "importNotesCheckBox";
            this.importNotesCheckBox.Size = new System.Drawing.Size(124, 17);
            this.importNotesCheckBox.TabIndex = 34;
            this.importNotesCheckBox.Text = "Include Import Notes";
            this.importNotesCheckBox.UseVisualStyleBackColor = true;
            //
            // autoTypeCheckBox
            //
            this.autoTypeCheckBox.AutoSize = true;
            this.autoTypeCheckBox.Checked = true;
            this.autoTypeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoTypeCheckBox.Location = new System.Drawing.Point(20, 79);
            this.autoTypeCheckBox.Name = "autoTypeCheckBox";
            this.autoTypeCheckBox.Size = new System.Drawing.Size(131, 17);
            this.autoTypeCheckBox.TabIndex = 25;
            this.autoTypeCheckBox.Text = "Add Auto Type entries";
            this.autoTypeCheckBox.UseVisualStyleBackColor = true;
            //
            // groupNote
            //
            this.groupNote.AutoSize = true;
            this.groupNote.Location = new System.Drawing.Point(225, 20);
            this.groupNote.Name = "groupNote";
            this.groupNote.Size = new System.Drawing.Size(163, 13);
            this.groupNote.TabIndex = 33;
            this.groupNote.Text = "(created by KeePass if unknown)";
            //
            // keePassLogo
            //
            this.keePassLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.keePassLogo.Image = global::WebSiteAdvantage.KeePass.Firefox.Converter.Properties.Resources.keepasslogo_512;
            this.keePassLogo.Location = new System.Drawing.Point(394, 15);
            this.keePassLogo.Name = "keePassLogo";
            this.keePassLogo.Size = new System.Drawing.Size(89, 81);
            this.keePassLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.keePassLogo.TabIndex = 32;
            this.keePassLogo.TabStop = false;
            //
            // iconComboBox
            //
            this.iconComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.iconComboBox.FormattingEnabled = true;
            this.iconComboBox.Items.AddRange(new object[] {
            "Key",
            "World",
            "Warning",
            "NetworkServer",
            "MarkedDirectory",
            "UserCommunication",
            "Parts",
            "Notepad",
            "WorldSocket",
            "Identity",
            "PaperReady",
            "Digicam",
            "IRCommunication",
            "MultiKeys",
            "Energy",
            "Scanner",
            "WorldStar",
            "CdRom",
            "Monitor",
            "EMail",
            "Configuration",
            "ClipboardReady",
            "PaperNew",
            "Screen",
            "EnergyCareful",
            "EMailBox",
            "Disk",
            "Drive",
            "PaperQ",
            "TerminalEncrypted",
            "Console",
            "Printer",
            "ProgramIcons",
            "Run",
            "Settings",
            "WorldComputer ",
            "Archive",
            "Homebanking",
            "DriveWindows",
            "Clock",
            "EMailSearch",
            "PaperFlag",
            "Memory",
            "TrashBin",
            "Note",
            "Expired",
            "Info",
            "Package",
            "Folder",
            "FolderOpen",
            "FolderPackage",
            "LockOpen",
            "PaperLocked",
            "Checked",
            "Pen",
            "Thumbnail",
            "Book",
            "List",
            "UserKey",
            "Tool",
            "Home",
            "Star",
            "None",
            "SortUpArrow",
            "SortDownArrow",
            "Count"});
            this.iconComboBox.Location = new System.Drawing.Point(106, 43);
            this.iconComboBox.Name = "iconComboBox";
            this.iconComboBox.Size = new System.Drawing.Size(113, 21);
            this.iconComboBox.TabIndex = 16;
            //
            // iconLabel
            //
            this.iconLabel.AutoSize = true;
            this.iconLabel.Location = new System.Drawing.Point(17, 46);
            this.iconLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.iconLabel.Name = "iconLabel";
            this.iconLabel.Size = new System.Drawing.Size(28, 13);
            this.iconLabel.TabIndex = 15;
            this.iconLabel.Text = "Icon";
            //
            // firefoxSettings
            //
            this.firefoxSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.firefoxSettings.Controls.Add(this.findProfilesButton);
            this.firefoxSettings.Controls.Add(this.profileComboBox);
            this.firefoxSettings.Controls.Add(this.profileLabel);
            this.firefoxSettings.Controls.Add(this.firefoxLogo);
            this.firefoxSettings.Controls.Add(this.passwordNote);
            this.firefoxSettings.Controls.Add(this.passwordLabel);
            this.firefoxSettings.Controls.Add(this.passwordTextBox);
            this.firefoxSettings.Location = new System.Drawing.Point(3, 93);
            this.firefoxSettings.Name = "firefoxSettings";
            this.firefoxSettings.Size = new System.Drawing.Size(492, 109);
            this.firefoxSettings.TabIndex = 28;
            this.firefoxSettings.TabStop = false;
            this.firefoxSettings.Text = "Firefox";
            //
            // findProfilesButton
            //
            this.findProfilesButton.Image = global::WebSiteAdvantage.KeePass.Firefox.Converter.Properties.Resources.openfolderHS;
            this.findProfilesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.findProfilesButton.Location = new System.Drawing.Point(258, 19);
            this.findProfilesButton.Name = "findProfilesButton";
            this.findProfilesButton.Size = new System.Drawing.Size(130, 23);
            this.findProfilesButton.TabIndex = 34;
            this.findProfilesButton.Text = "Load More Profiles...";
            this.findProfilesButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.findProfilesButton.UseVisualStyleBackColor = true;
            this.findProfilesButton.Click += new System.EventHandler(this.FindProfilesClickEventHandler);
            //
            // profileComboBox
            //
            this.profileComboBox.FormattingEnabled = true;
            this.profileComboBox.Location = new System.Drawing.Point(100, 19);
            this.profileComboBox.Name = "profileComboBox";
            this.profileComboBox.Size = new System.Drawing.Size(152, 21);
            this.profileComboBox.TabIndex = 33;
            //
            // profileLabel
            //
            this.profileLabel.AutoSize = true;
            this.profileLabel.Location = new System.Drawing.Point(6, 22);
            this.profileLabel.Name = "profileLabel";
            this.profileLabel.Size = new System.Drawing.Size(36, 13);
            this.profileLabel.TabIndex = 32;
            this.profileLabel.Text = "Profile";
            //
            // firefoxLogo
            //
            this.firefoxLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.firefoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.firefoxLogo.Image = global::WebSiteAdvantage.KeePass.Firefox.Converter.Properties.Resources.firefox_128_509;
            this.firefoxLogo.Location = new System.Drawing.Point(394, 14);
            this.firefoxLogo.Name = "firefoxLogo";
            this.firefoxLogo.Size = new System.Drawing.Size(89, 89);
            this.firefoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.firefoxLogo.TabIndex = 31;
            this.firefoxLogo.TabStop = false;
            //
            // passwordNote
            //
            this.passwordNote.AutoSize = true;
            this.passwordNote.Location = new System.Drawing.Point(100, 69);
            this.passwordNote.Name = "passwordNote";
            this.passwordNote.Size = new System.Drawing.Size(256, 13);
            this.passwordNote.TabIndex = 26;
            this.passwordNote.Text = "(required if you have set a master password in firefox)";
            //
            // passwordLabel
            //
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(6, 49);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(88, 13);
            this.passwordLabel.TabIndex = 22;
            this.passwordLabel.Text = "Master Password";
            //
            // passwordTextBox
            //
            this.passwordTextBox.Location = new System.Drawing.Point(100, 46);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(288, 20);
            this.passwordTextBox.TabIndex = 21;
            //
            // closeButton
            //
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(469, 581);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(55, 23);
            this.closeButton.TabIndex = 21;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CancelClickEventHandler);
            //
            // homeLink
            //
            this.homeLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.homeLink.AutoSize = true;
            this.homeLink.BackColor = System.Drawing.Color.White;
            this.homeLink.Location = new System.Drawing.Point(476, 73);
            this.homeLink.Name = "homeLink";
            this.homeLink.Size = new System.Drawing.Size(35, 13);
            this.homeLink.TabIndex = 27;
            this.homeLink.TabStop = true;
            this.homeLink.Text = "Home";
            this.homeLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.HomeLinkClickedEventHandler);
            //
            // description
            //
            this.description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.description.BackColor = System.Drawing.SystemColors.Window;
            this.description.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.Location = new System.Drawing.Point(20, 22);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(491, 51);
            this.description.TabIndex = 0;
            this.description.Text = "This tool will read password data stored in Firefox and create a file suitable fo" +
    "r importing into KeePass using the XML import plugin.";
            //
            // header
            //
            this.header.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.header.FormattingEnabled = true;
            this.header.Location = new System.Drawing.Point(12, 13);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(511, 82);
            this.header.TabIndex = 29;
            //
            // progressBar
            //
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 550);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(508, 23);
            this.progressBar.TabIndex = 31;
            //
            // pluginLink
            //
            this.pluginLink.AutoSize = true;
            this.pluginLink.BackColor = System.Drawing.Color.White;
            this.pluginLink.Location = new System.Drawing.Point(21, 73);
            this.pluginLink.Name = "pluginLink";
            this.pluginLink.Size = new System.Drawing.Size(138, 13);
            this.pluginLink.TabIndex = 32;
            this.pluginLink.TabStop = true;
            this.pluginLink.Text = "KeePass XML Import Plugin";
            this.pluginLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PluginLinkClickedEventHandler);
            //
            // donateButton
            //
            this.donateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.donateButton.Image = global::WebSiteAdvantage.KeePass.Firefox.Converter.Properties.Resources.beer3;
            this.donateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.donateButton.Location = new System.Drawing.Point(76, 581);
            this.donateButton.Name = "donateButton";
            this.donateButton.Size = new System.Drawing.Size(114, 23);
            this.donateButton.TabIndex = 33;
            this.donateButton.Text = "Buy me a Beer...";
            this.donateButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.donateButton.UseVisualStyleBackColor = true;
            this.donateButton.Click += new System.EventHandler(this.DonateClickEventHandler);
            //
            // helpButton
            //
            this.helpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.helpButton.Image = global::WebSiteAdvantage.KeePass.Firefox.Converter.Properties.Resources.Help;
            this.helpButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.helpButton.Location = new System.Drawing.Point(12, 581);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(60, 23);
            this.helpButton.TabIndex = 30;
            this.helpButton.Text = "Help...";
            this.helpButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.HelpClickEventHandler);
            //
            // startButton
            //
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.Image = global::WebSiteAdvantage.KeePass.Firefox.Converter.Properties.Resources.FormRunHS;
            this.startButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.startButton.Location = new System.Drawing.Point(352, 581);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(112, 23);
            this.startButton.TabIndex = 16;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartClickEventHandler);
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 615);
            this.Controls.Add(this.donateButton);
            this.Controls.Add(this.pluginLink);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.homeLink);
            this.Controls.Add(this.description);
            this.Controls.Add(this.header);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.settingsTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(544, 621);
            this.Name = "Form1";
            this.Text = "Web Site Advantage Firefox to KeePass Converter";
            this.Load += new System.EventHandler(this.Form1LoadEventHandler);
            this.settingsTab.ResumeLayout(false);
            this.settingsPage.ResumeLayout(false);
            this.methodSettings.ResumeLayout(false);
            this.methodSettings.PerformLayout();
            this.scraperSettings.ResumeLayout(false);
            this.scraperSettings.PerformLayout();
            this.warningContainer.ResumeLayout(false);
            this.keePassSettings.ResumeLayout(false);
            this.keePassSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keePassLogo)).EndInit();
            this.firefoxSettings.ResumeLayout(false);
            this.firefoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.firefoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox groupTextBox;
        private System.Windows.Forms.Label groupLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TabControl settingsTab;
        private System.Windows.Forms.TabPage settingsPage;
        private System.Windows.Forms.GroupBox firefoxSettings;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.GroupBox keePassSettings;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ComboBox iconComboBox;
        private System.Windows.Forms.Label iconLabel;
        private System.Windows.Forms.Label passwordNote;
        private System.Windows.Forms.GroupBox scraperSettings;
        private System.Windows.Forms.CheckBox autoTypeCheckBox;
        private System.Windows.Forms.CheckBox scrapeTitlesCheckBox;
        private System.Windows.Forms.GroupBox warningContainer;
        private System.Windows.Forms.Label warningMessage;
        private System.Windows.Forms.LinkLabel homeLink;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.ListBox header;
        private System.Windows.Forms.GroupBox methodSettings;
        private System.Windows.Forms.RadioButton importXmlRadioButton;
        private System.Windows.Forms.RadioButton importFirefoxRadioButton;
        private System.Windows.Forms.LinkLabel extensionLink;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.PictureBox firefoxLogo;
        private System.Windows.Forms.PictureBox keePassLogo;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label groupNote;
        private System.Windows.Forms.LinkLabel pluginLink;
        private System.Windows.Forms.ComboBox profileComboBox;
        private System.Windows.Forms.Label profileLabel;
        private System.Windows.Forms.Button findProfilesButton;
        private System.Windows.Forms.Button donateButton;
        private System.Windows.Forms.CheckBox importNotesCheckBox;
    }
}
