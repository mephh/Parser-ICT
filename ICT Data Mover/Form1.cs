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
using System.Runtime.InteropServices;

namespace ICT_Data_Mover
{
    public partial class Form1 : Form
    {
        //Start-Up values    
        public string logPath = "";
        public string serverPath = "";
        private string configFile = "config.txt";
        public string errorFile = "errors.txt";
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
            UpdateStatistics(passCounter, allPassCounter, failCounter, allFailCounter);
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
            sLogName = logName.Replace(tBoxLogs.Text, "");                  //GET ONLY FILENAME FROM PATH
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
                File.WriteAllLines(tBoxServer.Text + "\\" + newLogName, lines);       //WRITE FILE TO DESTINATION LOCATION
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
                UpdateStatistics(passCounter, allPassCounter, failCounter, allFailCounter); //update po kazdym logu
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
                tBoxLogs.Text = logPath;
                tBoxServer.Text = serverPath;
            }
            catch(Exception  e)
            {
                string msg = "Brak uprawnien do utworzenia lub nadpisania pliku configuration.ini. " +
                    "Sprawdz czy aplikacja nie znajduje sie w folderze systemowym( C:\\, C:\\Program Files itp..)";
                SaveErrorToFile(e.Message);
                MessageBox.Show(msg);
            }
        }

        private void buttonParser_Click(object sender, EventArgs e)
        {
            if (buttonParser.Text == "ON")
            {
                buttonParser.Text = "OFF";
                buttonParser.BackColor = Color.FromArgb(192, 57, 43);
                StopTimer();
            }
            else if (buttonParser.Text == "OFF")
            {
                buttonParser.Text = "ON";
                buttonParser.BackColor = Color.FromArgb(39, 174, 96);
                StartTimer();
            }
        }

        public void PopulateListView(string parsedLog, string errCode, string bstat = "")
        {
            ListViewItem item1 = new ListViewItem(logCounter.ToString());
            item1.SubItems.Add(parsedLog);
            item1.SubItems.Add(errCode);
            item1.SubItems.Add(DateTime.Now.ToLongTimeString());
            lViewParser.Items.Insert(0, item1);
            if (bstat == "Failed")
            {
                lViewParser.Items[0].BackColor = Color.FromArgb(192, 57, 43);
            }
            else if (bstat == "Passed")
            {
                lViewParser.Items[0].BackColor = Color.FromArgb(39, 174, 96);
            }

        }
        public void UpdateStatistics(int pCounter, int apCounter, int fCounter, int afCounter)
        {
            mlblCurrent.Text = "Od uruchomienia: " + pCounter + " pass | " + fCounter + " fail";
            mlblAll.Text = "Wszystkie: " + apCounter + " pass | " + afCounter + " fail";
            //toolStripStatusLabel1.Text = "Od uruchomienia: " + pCounter + " pass | " + fCounter + " fail";
            //toolStripStatusLabel2.Text = "Wszystkie: " + apCounter + " pass | " + afCounter + " fail";
        }
        //CHECKS IF CURRENT PATHS ARE DIFFERENT THAN ONES STORED IN CONFIG FILE
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            string message = "";
            string caption = "";
            if (tBoxLogs.Text != logPath || tBoxServer.Text != serverPath)
            {
                message = "Plik config rozni sie od sciezek podanych w programie. Czy chcesz zapisac zmiany w pliku config?";
                caption = "Zmieniono sciezke do logow lub serwera";
                MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.Yes)
                {
                    config.Write("Local folder", tBoxLogs.Text, "Paths");
                    config.Write("Server folder", tBoxServer.Text, "Paths");
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
            LoadLogs(tBoxLogs.Text, tBoxServer.Text);
        }
        //TIMER FUNCTIONS USED TO CALCULATE TIME BETWEEN MAIN FUNCTION CALLS
        public void StartTimer()
        {
            int t;
            try
            {
                t = Convert.ToInt32(tBoxTimer.Text);
            }
            catch
            {
                t = 0;
            }
            if (t < 1)
            {
                t = 1;
                tBoxTimer.Text = "1";
            }
            if (!timerEnabled && !parsingOn)
            {
                timer = new Timer();
                timer.Interval = t*1000;//10000;
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


        //UI FUNCTIONS
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
