//VIRTUAL MODE - ABORTED
//ERRORS FOLDER - DONE
//CONFIG AS XML - CONFIG AS TXT DONE
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ICT_Data_Mover
{
    public partial class Form1 : Form
    {
        //Start-Up values    
        public string logPath = "";
        public string serverPath = "";
        private string configFile = "config.txt";
        public string errorFile = "errors.txt";
        //UI related fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        //PASS/FAIL COUNTERS
        int logCounter = 0;
        int passCounter = 0;
        int failCounter = 0;
        int allFailCounter = 0;
        int allPassCounter = 0;
        public string[] filenames;
        public bool parsingOn = false;
        public bool corruptedLog = false;
        public string errorFolder = "errors\\";
        //CONVERT MONTH NUMBER TO NAME
        Dictionary<string, string> months = new Dictionary<string, string>()
        {
            {"JAN", "01"},
            {"FEB", "02"},
            {"MAR", "03"},
            {"APR", "04"},
            {"MAY", "05"},
            {"JUN", "06"},
            {"JUL", "07"},
            {"AUG", "08"},
            {"SEP", "09"},
            {"OCT", "10"},
            {"NOV", "11"},
            {"DEC", "12"}
        };

        //CONFIG FILE
        string appPath = AppDomain.CurrentDomain.BaseDirectory; //sciezka do folderu z plikiem exe
        IniFile config = new IniFile("configuration.ini");

        Timer timer;
        bool timerEnabled = false;

        //CONSTRUCTOR
        public Form1()
        {
            InitializeComponent();
            ReadConfigurationFile();
            UpdateToolStrips(passCounter, allPassCounter, failCounter, allFailCounter);
            random = new Random();
        }
 
        //RETURN LIST OF FILENAMES IN FOLDER, CALLED AFTER EVERY TIMER TICK
        private void LoadLogs(string dirInput, string dirOutput)
        {
            if (Directory.Exists(dirInput) && Directory.Exists(dirOutput))
            {
                filenames = Directory.GetFiles(dirInput);
                string errorFolderCombined = appPath + errorFolder;
                foreach (string filename in filenames)
                {
                    ProcessLog(filename, dirOutput);
                    if (corruptedLog) //if file is incomplete, move to error folder and save info in report
                    {
                        if (!Directory.Exists(errorFolderCombined))
                        {
                            Directory.CreateDirectory(errorFolderCombined);
                        }
                        File.Move(filename, errorFolderCombined+Path.GetFileName(filename));
                    }
                }
            }
            else //if any of folders doesnt exist
            {
                buttonParser.PerformClick();
                MessageBoxButtons buttons1 = MessageBoxButtons.YesNoCancel;
                DialogResult result1;
                result1 = MessageBox.Show("Foldery nie istnieja. Czy chcesz je utworzyc?", "Brak folderu o podanej nazwie", buttons1);
                if (result1 == DialogResult.Yes)
                {
                    try //try to create folder
                    {
                        if (!Directory.Exists(dirInput))
                        {
                            Directory.CreateDirectory(dirInput);
                        }
                        if (!Directory.Exists(dirOutput))
                        {
                            Directory.CreateDirectory(dirOutput);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Nie mozna utworzyc folderu");
                    }
                }
            }
        }

        //PARSE 1 LOG AT A TIME
        public void ProcessLog(string logName, string outputFolder)
        {
            //Husqv_BLDC_G2_SHO285257-20200604-133716-00016.LOG
            //Husqv_BLDC_G2_SHO271541-20200310-200531-00001.LOG
            string cutLogName = "";
            string logYear = "";
            string month = "";
            string logMonth = "";
            string logDay = "";
            string logHour = "";
            string logMin = "";
            string logSeconds = "";
            string lastLine = "";
            string[] lines = File.ReadAllLines(logName);
            string boardStatus = "";
            string boardResult = "";
            string sLogName = "";
            string newLogName = "";
            //zamiast tego tablica ze stringami
            //czy jest funkcja do parsowania daty/godz
            // line.convert.todatetime()
            //public na private
            
            parsingOn = true;
            try
            {
                lastLine = lines[lines.Length - 1];
            }
            //IF LOG IS INCOMPLETE, SKIP
            catch(IndexOutOfRangeException oor)
            {
                SaveErrorToFile(oor.Message);
                PopulateListView(logName, oor.Message, boardStatus);
                if (!Directory.Exists("../error"))
                {
                    Directory.CreateDirectory("../error");
                }
                corruptedLog = true;
                return;
            }
            boardResult = lastLine.Substring(0, 1);                         //PASS / FAIL
            //Husqv_BLDC_G2_SHO285257.LOG_b2
            //"04-JUN-20  19:22:33
            sLogName = logName.Replace(textBox1.Text, "");                  //GET ONLY FILENAME FROM PATH
            cutLogName = sLogName.Substring(1, sLogName.IndexOf(".")-1);    //REMOVE EXTENSION
            //FORMATOWANIE DATY
            var dateIndex = FindSep(lastLine, '-');  
            //GET YEAR, MONTH AND DAY FROM FILE'S LAST LINE
            logYear = lastLine.Substring(dateIndex[1]+1, 2);                
            month = lastLine.Substring(dateIndex[0]+1, 3);
            logMonth = months[month];
            logDay = lastLine.Substring(1, 2);
            //FORMAT TIME
            var timeIndex = FindSep(lastLine, ':');
            logHour = lastLine.Substring(timeIndex[0]-2, 2);
            logMin = lastLine.Substring(timeIndex[0]+1, 2);
            logSeconds = lastLine.Substring(timeIndex[1]+1, 2);
            //CONCATENATE NEW FILENAME
            newLogName = cutLogName + "-" + logYear + logMonth + logDay + "-" + logHour + logMin + logSeconds + ".LOG";
            try
            {
                logCounter++;//do numerowania linii w listView
                File.WriteAllLines(textBox2.Text + "\\" + newLogName, lines);       //WRITE FILE TO DESTINATION LOCATION
                File.Delete(logName);                                               //REMOVE FILE IN SOURCE LOCATION
                //iterowanie liczby pass i fail
                if (boardResult == "\"")
                {
                    passCounter++;
                    boardStatus = "Passed";
                }
                else
                {
                    failCounter++;
                    boardStatus = "Failed";
                }
                PopulateListView(newLogName, "  OK!", boardStatus);
                UpdateToolStrips(passCounter, allPassCounter, failCounter, allFailCounter); //update po kazdym logu
            }
            catch(Exception e)
            {
                PopulateListView(newLogName, e.Message);
                SaveErrorToFile(e.Message);
            }
            parsingOn = false;
        }
 
        //**********OKNO PRZY ZAMYKANIU APLIKACJI*************
        public void ReadConfigurationFile()
        {
            try
            {
                //CHECK IF CONFIG CONTAIN VARIABLES
                if (!config.KeyExists("Local folder", "Paths"))
                {
                    config.Write("Local folder", "C:\\", "Paths");
                }
                if (!config.KeyExists("Server folder", "Paths"))
                {
                    config.Write("Server folder", "C:\\", "Paths");
                }
                if (!config.KeyExists("Passed boards", "Counters"))
                {
                    config.Write("Passed boards", "0", "Counters");
                }
                if (!config.KeyExists("Failed boards", "Counters"))
                {
                    config.Write("Failed boards", "0", "Counters");
                }

                logPath = config.Read("Local folder", "Paths");
                serverPath = config.Read("Server folder", "Paths");
                allPassCounter = int.Parse(config.Read("Passed boards", "Counters"));
                allFailCounter = int.Parse(config.Read("Failed boards", "Counters"));
                textBox1.Text = logPath;
                textBox2.Text = serverPath;
            }
            catch(Exception  e)
            {
                string msg = "Brak uprawnien do utworzenia lub nadpisania pliku configuration.ini. " +
                    "Sprawdz czy aplikacja nie znajduje sie w folderze systemowym( C:\\, C:\\Program Files itp..)";
                SaveErrorToFile(e.Message);
                MessageBox.Show(msg);
            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //NOT IMPLEMENTED
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Enabled = false;
            }
            else
            {
                textBox1.Enabled = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox2.Enabled = false;
            }
            else
            {
                textBox2.Enabled = true;
            }
        }

        private void buttonParser_Click(object sender, EventArgs e)
        {
            if (buttonParser.Text == "ON")
            {
                buttonParser.Text = "OFF";
                buttonParser.BackColor = Color.Orange;
                StopTimer();
            }
            else if (buttonParser.Text == "OFF")
            {
                buttonParser.Text = "ON";
                buttonParser.BackColor = Color.LimeGreen;
                StartTimer();
            }
        }

        public void PopulateListView(string parsedLog, string errCode, string bstat = "")
        {
            //ListViewItem item1 = new ListViewItem(logCounter.ToString());
            //item1.SubItems.Add(parsedLog);
            //item1.SubItems.Add(errCode);
            //item1.SubItems.Add(DateTime.Now.ToLongTimeString());
            //listView1.Items.Insert(0, item1);
            //if (bstat == "Failed")
            //{
            //    listView1.Items[0].BackColor = Color.OrangeRed;
            //}
            //else if (bstat == "Passed")
            //{
            //    listView1.Items[0].BackColor = Color.Lime;
            //}

        }
        public void UpdateToolStrips(int pCounter, int apCounter, int fCounter, int afCounter)
        {
            toolStripStatusLabel1.Text = "Od uruchomienia: " + pCounter + " pass | " + fCounter + " fail";
            toolStripStatusLabel2.Text = "Wszystkie: " + apCounter + " pass | " + afCounter + " fail";
        }
        //CHECKS IF CURRENT PATHS ARE DIFFERENT THAN ONES STORED IN CONFIG FILE
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            string message = "";
            string caption = "";
            if (textBox1.Text != logPath || textBox2.Text != serverPath)
            {
                message = "Plik config rozni sie od sciezek podanych w programie. Czy chcesz zapisac zmiany w pliku config?";
                caption = "Zmieniono sciezke do logow lub serwera";
                MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.Yes)
                {
                    config.Write("Local folder", textBox1.Text, "Paths");
                    config.Write("Server folder", textBox2.Text, "Paths");
                }
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
            allFailCounter += failCounter;
            allPassCounter += passCounter;
            try
            {
                config.Write("Passed boards", allPassCounter.ToString(), "Counters");
                config.Write("Failed boards", allFailCounter.ToString(), "Counters");
            }
            catch
            {
                message = "Brak uprawnien do nadpisania pliku config. Sprawdz czy aplikacja nie znajduje sie w folderze systemowym.";
                SaveErrorToFile(message);
                MessageBox.Show(message);
            }
        }

        //******LOG PARSE TIMER**********
        void Timer_Tick(object sender, EventArgs e)
        {
            LoadLogs(textBox1.Text, textBox2.Text);
        }
        //TIMER FUNCTIONS USED TO CALCULATE TIME BETWEEN MAIN FUNCTION CALLS
        public void StartTimer()
        {
            if (!timerEnabled && !parsingOn)
            {
                timer = new Timer();
                timer.Interval = 10000;
                timer.Tick += Timer_Tick;
                timer.Start();
                timerEnabled = true;
            }
        }

        public void StopTimer()
        {
            timer.Stop();
            timerEnabled = false;
        }

        //FIND SEPARATOR USED IN TEXT
        public List<int> FindSep(string line, char sep)
        {
            //Debug.Assert()
            var separator = new List<int>();
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == sep)
                {
                    separator.Add(i);
                }
            }
            return separator;
        }
        //STORE ERRORS FOR DEBUG
        public void SaveErrorToFile(string errorMessage)
        {
            if (!File.Exists(errorFile))
            {
                File.CreateText(errorFile);
            }
            using (StreamWriter sw = File.AppendText(errorFile))
            {
                sw.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " " + errorMessage);
            }
        }

        //******RESIDUAL CODE********************
        //******CONFIG WCZYTYWANY PRZEZ READCONFIGURATIONFILE***********
        private void LoadConfigFile()
        {
            try
            {
                string currentLine = "";
                FileStream FS = new FileStream(configFile, FileMode.Open);
                using (StreamReader SR = new StreamReader(FS))
                {
                    while (SR.Peek() > 0)
                    {
                        currentLine = SR.ReadLine();
                        if (currentLine.StartsWith("log_path"))
                        {
                            logPath = currentLine.Substring(currentLine.IndexOf("=") + 2);
                        }
                        if (currentLine.StartsWith("server_path"))
                        {
                            serverPath = currentLine.Substring(currentLine.IndexOf("=") + 2);
                        }
                        if (currentLine.StartsWith("All Pass"))
                        {
                            allPassCounter = int.Parse(currentLine.Substring(currentLine.IndexOf(":") + 1));
                        }
                        if (currentLine.StartsWith("All Fail"))
                        {
                            allFailCounter = int.Parse(currentLine.Substring(currentLine.IndexOf(":") + 1));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string message = e.Message;
                SaveErrorToFile(message);
                string caption = "Blad podczas wczytywania";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.OK)
                {
                    try
                    {
                        FileStream FS = new FileStream(configFile, FileMode.Create);
                        FS.Close();
                    }
                    catch (Exception ee)
                    {
                        message = "Brak uprawnien do utworzenia pliku config. Sprawdz czy aplikacja nie znajduje sie w folderze systemowym.   ";
                        SaveErrorToFile(message + ee.Message);
                        MessageBox.Show(message);
                    }
                }
            }
            textBox1.Text = logPath;  //wpisanie sciezek do okien textbox - mozna pozniej zmienic przed wlaczeniem parsowania
            textBox2.Text = serverPath;
        }


        //UI FUNCTIONS
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while(tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(9, 132, 227);
                    previousBtn.ForeColor = Color.Black;
                    previousBtn.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                }
            }
        }

        private void btnParser_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Parser(), sender);
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelForm.Controls.Add(childForm);
            this.panelForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;

        }
    }
}
