namespace ICT_Data_Mover
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
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.panelOnOff = new System.Windows.Forms.Panel();
            this.buttonParser = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelListview = new System.Windows.Forms.Panel();
            this.lViewParser = new System.Windows.Forms.ListView();
            this.number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.logName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.errorStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLogs = new System.Windows.Forms.Label();
            this.tBoxLogs = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.tBoxServer = new System.Windows.Forms.TextBox();
            this.metroTabPage4 = new MetroFramework.Controls.MetroTabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.mlblCurrent = new MetroFramework.Controls.MetroLabel();
            this.mlblAll = new MetroFramework.Controls.MetroLabel();
            this.lblAbout = new MetroFramework.Controls.MetroLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.tBoxTimer = new System.Windows.Forms.TextBox();
            this.panelTitleBar.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.panelOnOff.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelListview.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.metroTabPage4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(1367, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(47, 49);
            this.buttonClose.TabIndex = 12;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelTitleBar.Controls.Add(this.label3);
            this.panelTitleBar.Controls.Add(this.buttonClose);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1414, 49);
            this.panelTitleBar.TabIndex = 13;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(655, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 27);
            this.label3.TabIndex = 13;
            this.label3.Text = "Parser ICT";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.metroTabPage1);
            this.tabControl.Controls.Add(this.metroTabPage2);
            this.tabControl.Controls.Add(this.metroTabPage3);
            this.tabControl.Controls.Add(this.metroTabPage4);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.FontWeight = MetroFramework.MetroTabControlWeight.Regular;
            this.tabControl.Location = new System.Drawing.Point(0, 49);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 2;
            this.tabControl.Size = new System.Drawing.Size(1414, 752);
            this.tabControl.TabIndex = 15;
            this.tabControl.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.BackColor = System.Drawing.SystemColors.Menu;
            this.metroTabPage1.Controls.Add(this.panelOnOff);
            this.metroTabPage1.Controls.Add(this.panel1);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(1406, 710);
            this.metroTabPage1.Style = MetroFramework.MetroColorStyle.Black;
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Parser";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // panelOnOff
            // 
            this.panelOnOff.BackColor = System.Drawing.Color.Transparent;
            this.panelOnOff.Controls.Add(this.buttonParser);
            this.panelOnOff.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelOnOff.Location = new System.Drawing.Point(1233, 0);
            this.panelOnOff.Name = "panelOnOff";
            this.panelOnOff.Size = new System.Drawing.Size(173, 710);
            this.panelOnOff.TabIndex = 3;
            // 
            // buttonParser
            // 
            this.buttonParser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.buttonParser.Location = new System.Drawing.Point(3, 615);
            this.buttonParser.Name = "buttonParser";
            this.buttonParser.Size = new System.Drawing.Size(170, 92);
            this.buttonParser.TabIndex = 9;
            this.buttonParser.Text = "OFF";
            this.buttonParser.UseVisualStyleBackColor = false;
            this.buttonParser.Click += new System.EventHandler(this.buttonParser_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelListview);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1227, 710);
            this.panel1.TabIndex = 2;
            // 
            // panelListview
            // 
            this.panelListview.Controls.Add(this.lViewParser);
            this.panelListview.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelListview.Location = new System.Drawing.Point(0, 0);
            this.panelListview.Name = "panelListview";
            this.panelListview.Size = new System.Drawing.Size(1227, 710);
            this.panelListview.TabIndex = 3;
            // 
            // lViewParser
            // 
            this.lViewParser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lViewParser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.number,
            this.logName,
            this.errorStatus,
            this.time});
            this.lViewParser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lViewParser.FullRowSelect = true;
            this.lViewParser.GridLines = true;
            this.lViewParser.HideSelection = false;
            this.lViewParser.Location = new System.Drawing.Point(0, 0);
            this.lViewParser.Name = "lViewParser";
            this.lViewParser.Size = new System.Drawing.Size(1227, 710);
            this.lViewParser.TabIndex = 12;
            this.lViewParser.UseCompatibleStateImageBehavior = false;
            this.lViewParser.View = System.Windows.Forms.View.Details;
            // 
            // number
            // 
            this.number.Text = "Nr";
            this.number.Width = 30;
            // 
            // logName
            // 
            this.logName.Text = "Nazwa pliku";
            this.logName.Width = 600;
            // 
            // errorStatus
            // 
            this.errorStatus.Text = "Status";
            this.errorStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.errorStatus.Width = 440;
            // 
            // time
            // 
            this.time.Text = "Godzina";
            this.time.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.time.Width = 90;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.panel5);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(1406, 710);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Statystyki";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.panelSettings);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(1406, 710);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Ustawienia";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // panelSettings
            // 
            this.panelSettings.BackColor = System.Drawing.Color.Transparent;
            this.panelSettings.Controls.Add(this.tBoxTimer);
            this.panelSettings.Controls.Add(this.label1);
            this.panelSettings.Controls.Add(this.label4);
            this.panelSettings.Controls.Add(this.lblLogs);
            this.panelSettings.Controls.Add(this.tBoxLogs);
            this.panelSettings.Controls.Add(this.lblServer);
            this.panelSettings.Controls.Add(this.tBoxServer);
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSettings.Location = new System.Drawing.Point(0, 0);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(300, 710);
            this.panelSettings.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "LOGOWANIE DANYCH";
            // 
            // lblLogs
            // 
            this.lblLogs.AutoSize = true;
            this.lblLogs.Location = new System.Drawing.Point(8, 56);
            this.lblLogs.Name = "lblLogs";
            this.lblLogs.Size = new System.Drawing.Size(169, 13);
            this.lblLogs.TabIndex = 17;
            this.lblLogs.Text = "Folder z którego pobierane są logi:";
            // 
            // tBoxLogs
            // 
            this.tBoxLogs.Location = new System.Drawing.Point(11, 72);
            this.tBoxLogs.Name = "tBoxLogs";
            this.tBoxLogs.Size = new System.Drawing.Size(266, 20);
            this.tBoxLogs.TabIndex = 16;
            this.tBoxLogs.Text = "C:\\Teradyne\\MEASDATA";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(8, 97);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(244, 13);
            this.lblServer.TabIndex = 18;
            this.lblServer.Text = "Folder do którego zapisywane są logi na serwerze:";
            // 
            // tBoxServer
            // 
            this.tBoxServer.Location = new System.Drawing.Point(11, 113);
            this.tBoxServer.Name = "tBoxServer";
            this.tBoxServer.Size = new System.Drawing.Size(266, 20);
            this.tBoxServer.TabIndex = 19;
            this.tBoxServer.Text = "Z:\\";
            // 
            // metroTabPage4
            // 
            this.metroTabPage4.Controls.Add(this.panel4);
            this.metroTabPage4.Controls.Add(this.panel3);
            this.metroTabPage4.HorizontalScrollbarBarColor = true;
            this.metroTabPage4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.HorizontalScrollbarSize = 10;
            this.metroTabPage4.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage4.Name = "metroTabPage4";
            this.metroTabPage4.Size = new System.Drawing.Size(1406, 710);
            this.metroTabPage4.TabIndex = 3;
            this.metroTabPage4.Text = "O programie";
            this.metroTabPage4.VerticalScrollbarBarColor = true;
            this.metroTabPage4.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.VerticalScrollbarSize = 10;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1339, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(67, 710);
            this.panel4.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.lblAbout);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 710);
            this.panel3.TabIndex = 3;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 143);
            this.label2.TabIndex = 0;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.mlblAll);
            this.panel5.Controls.Add(this.mlblCurrent);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(300, 710);
            this.panel5.TabIndex = 2;
            // 
            // mlblCurrent
            // 
            this.mlblCurrent.AutoSize = true;
            this.mlblCurrent.Location = new System.Drawing.Point(8, 23);
            this.mlblCurrent.Name = "mlblCurrent";
            this.mlblCurrent.Size = new System.Drawing.Size(81, 19);
            this.mlblCurrent.TabIndex = 0;
            this.mlblCurrent.Text = "metroLabel1";
            // 
            // mlblAll
            // 
            this.mlblAll.AutoSize = true;
            this.mlblAll.Location = new System.Drawing.Point(8, 57);
            this.mlblAll.Name = "mlblAll";
            this.mlblAll.Size = new System.Drawing.Size(81, 19);
            this.mlblAll.TabIndex = 1;
            this.mlblAll.Text = "metroLabel1";
            // 
            // lblAbout
            // 
            this.lblAbout.AutoSize = true;
            this.lblAbout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAbout.Location = new System.Drawing.Point(0, 672);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(87, 38);
            this.lblAbout.TabIndex = 1;
            this.lblAbout.Text = "V1.1\r\nZmienione UI";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Co ile sekund parser ma sprawdzać logi:";
            // 
            // tBoxTimer
            // 
            this.tBoxTimer.Location = new System.Drawing.Point(210, 166);
            this.tBoxTimer.Name = "tBoxTimer";
            this.tBoxTimer.Size = new System.Drawing.Size(34, 20);
            this.tBoxTimer.TabIndex = 22;
            this.tBoxTimer.Text = "10";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1414, 801);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parser ICT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.panelOnOff.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelListview.ResumeLayout(false);
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage3.ResumeLayout(false);
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.metroTabPage4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroTabControl tabControl;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private System.Windows.Forms.Panel panelOnOff;
        private System.Windows.Forms.Button buttonParser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelListview;
        private System.Windows.Forms.ListView lViewParser;
        private System.Windows.Forms.ColumnHeader number;
        private System.Windows.Forms.ColumnHeader logName;
        private System.Windows.Forms.ColumnHeader errorStatus;
        private System.Windows.Forms.ColumnHeader time;
        private System.Windows.Forms.TextBox tBoxServer;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblLogs;
        private System.Windows.Forms.TextBox tBoxLogs;
        private MetroFramework.Controls.MetroTabPage metroTabPage4;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private MetroFramework.Controls.MetroLabel mlblCurrent;
        private MetroFramework.Controls.MetroLabel mlblAll;
        private MetroFramework.Controls.MetroLabel lblAbout;
        private System.Windows.Forms.TextBox tBoxTimer;
        private System.Windows.Forms.Label label1;
    }
}

