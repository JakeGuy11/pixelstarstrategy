using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json; //Take this, it's dangerous to go alone! https://www.newtonsoft.com/json/help/html/DeserializeObject.htm

namespace PixelStarStrategy
{
    public partial class d_form : Form
    {

        //Keep all the big vars here
        #region Globals

        //The major path where everything is stored
        public string Path = @"C:\PixelStarStrategy";
        //Where the priority preferences are stored
        public string PriorityPath = @"C:\PixelStarStrategy\Priority.json";
        //Where all of the info about the matches are stored
        public string InfoPath = @"C:\PixelStarStrategy\MatchInfo.json";
        //Where the log file will be stored
        public string LogPath = @"C:\PixelStarStrategy\log.psslog";
        //Create variables that will hold the priorities of the different aspects evaluated
        public int PriorityHP = 10;
        public int PriorityTime = 10;
        public int PriorityRoom = 10;
        public int PriorityCrew = 10;
        //Create variables to store all match data so we don't have to reference the JSON every time
        public List<int> LayoutList;
        public List<int> myMaxHPList;
        public List<double> myHPList;
        public List<int> myMaxRoomsList;
        public List<int> myRoomsList;
        public List<int> myMaxCrewList;
        public List<int> myCrewList;
        public List<int> opMaxHPList;
        public List<double> opHPList;
        public List<int> opMaxRoomsList;
        public List<int> opRoomsList;
        public List<int> opMaxCrewList;
        public List<int> opCrewList;
        public List<double> timeList;
        //Create the variable for holding scores
        public List<double> scores;
        //Array to hold the frequencies of appearences of each layout
        public List<int> freq;
        //Variable to hold the best layout number
        public int optimalLayout = 0;

        #endregion

        //Runs at start
        public d_form()
        {
            //Initializes all GUI components
            InitializeComponent();
            //Inits a new Log file
            try
            {
                //If the directory exists, create our log file
                File.Create(LogPath).Close();
                Log("=============");
                Log("Beginning Log");
                Log("=============");
            }
            catch
            {
                //Our directory does not exist. Create it and begin logging
                Directory.CreateDirectory(Path);
                File.Create(LogPath).Close();
                Log("=============");
                Log("Beginning Log");
                Log("=============");
                DialogResult result = MessageBox.Show("Welcome to Pixel StarStrategy! Beta v. 0.2.3",
                    "Welcome!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            //If our match data file doesn't exist, create it. We don't do this with priority because we're creating a new one anyways, never adding to it.
            if (!File.Exists(InfoPath))
            {
                File.Create(InfoPath).Close();
            }
        }

        //doing all calculations and displaying the best option
        private void UpdateAnalyze(object sender, EventArgs e)
        {
            Log("==================");
            Log("UPDATE AND ANALYZE");
            Log("==================");
            Log("Starting the UPDATE phase");
            //Create object for Priorities
            PriorityPref myPri = new PriorityPref();
            try
            {
                //If it exists, it will be taken from the JSON
                myPri = JsonConvert.DeserializeObject<PriorityPref>(File.ReadAllText(PriorityPath));
                //Update the slider values
                d_priHPSlider.Value = myPri.pri_hp;
                d_priTimeSlider.Value = myPri.pri_time;
                d_priRoomSlider.Value = myPri.pri_rooms;
                d_priCrewSlider.Value = myPri.pri_crew;
            }
            catch
            {
                //If the JSON doesn't exist, take it from the sliders
                myPri.pri_hp = d_priHPSlider.Value;
                myPri.pri_time = d_priTimeSlider.Value;
                myPri.pri_rooms = d_priRoomSlider.Value;
                myPri.pri_crew = d_priCrewSlider.Value;
            }
            Log("Updated priorities from object(HP,Time,Rooms,Crew): " + myPri.pri_hp + ", " + myPri.pri_time + ", " + myPri.pri_rooms + ", " + myPri.pri_crew);
            //Save the values from our object to variables
            PriorityHP = myPri.pri_hp;
            PriorityTime = myPri.pri_time;
            PriorityRoom = myPri.pri_rooms;
            PriorityCrew = myPri.pri_crew;
            Log("Updated priorities from globals(HP,Time,Rooms,Crew): " + PriorityHP + ", " + PriorityTime + ", " + PriorityRoom + ", " + PriorityCrew);
            Log("Beginning analyzation");
            try
            {
                MatchInfo myMatch = new MatchInfo();
                //Deserialize, now we have a MatchInfo with all the saved data
                myMatch = JsonConvert.DeserializeObject<MatchInfo>(File.ReadAllText(InfoPath));
                LayoutList = myMatch.inf_Layout;
                Log("Layouts: " + string.Join(", ", LayoutList));
                myHPList = myMatch.inf_myHP;
                Log("My HPs: " + string.Join(", ", myHPList));
                myRoomsList = myMatch.inf_myRoomsDest;
                Log("My Rooms: " + string.Join(", ", myRoomsList));
                myCrewList = myMatch.inf_myCrewKilled;
                Log("My Crew: " + string.Join(", ", myCrewList));
                opHPList = myMatch.inf_opHP;
                Log("OP HPs: " + string.Join(", ", opHPList));
                opRoomsList = myMatch.inf_opRoomsDest;
                Log("OP Rooms: " + string.Join(", ", opRoomsList));
                opCrewList = myMatch.inf_opCrewKilled;
                Log("OP Crew: " + string.Join(", ", opCrewList));
                timeList = myMatch.inf_timePercent;
                Log("Times: " + string.Join(", ", timeList));
                Log("Insert monologue about how stupid I am for forgetting to write the Max elements from the object to the variables :\\");
                myMaxHPList = myMatch.inf_myMaxHP;
                Log("My Max HPs: " + string.Join(", ", myMaxHPList));
                myMaxRoomsList = myMatch.inf_myMaxRooms;
                Log("My Max Rooms: " + string.Join(", ", myMaxRoomsList));
                myMaxCrewList = myMatch.inf_myMaxCrew;
                Log("My Max Crews: " + string.Join(", ", myMaxCrewList));
                opMaxHPList = myMatch.inf_opMaxHP;
                Log("OP Max HPs: " + string.Join(", ", opMaxHPList));
                opMaxRoomsList = myMatch.inf_opMaxRooms;
                Log("OP Max Rooms: " + string.Join(", ", opMaxRoomsList));
                opMaxCrewList = myMatch.inf_opMaxCrew;
                Log("OP Max Crews: " + string.Join(", ", opMaxCrewList));
                //Now we have everything we need! Time to have our AI algorithm calculate the outcome!
                Log("UPDATE Phase Complete");
                Log("Beggining Analyze Phase");

                int myFirstBlankElement = FirstBlankElement(myMatch);
                //Create the variable for holding scores and frequencies
                double[] scoreArray = new double[LayoutList.Max()];
                scores = scoreArray.ToList();
                int[] freqArray = new int[LayoutList.Max()];
                freq = freqArray.ToList();
                //Now we go through it as many times as there are entries in the JSON
                for (int i = 0; i < myFirstBlankElement; i++)
                {
                    double oldVal;
                    try { oldVal = scores[LayoutList[i] - 1]; } catch { oldVal = 0; }
                    //First operation, so we don't add, we set. But we set it to (myHPPercent-(opHPPercent/2))*HP priority
                    //For the rest, we just add to it using the AI algorithms we set. I'll keep the algorithm to myself for now ;) (Unless you can look at it and understand)
                    scores[LayoutList[i] - 1] = ((myHPList[i] / myMaxHPList[i]) - opHPList[i] / opMaxHPList[i] / 2) * PriorityHP;
                    scores[LayoutList[i] - 1] += (opRoomsList[i] / opMaxRoomsList[i]) - myRoomsList[i] / myMaxRoomsList[i] * PriorityRoom;
                    scores[LayoutList[i] - 1] += (myCrewList[i] / myMaxCrewList[i]) - opCrewList[i] / opMaxCrewList[i] / 2 * PriorityCrew;
                    scores[LayoutList[i] - 1] += timeList[i] * PriorityTime;
                    //Add the old value to get a culmitave score. We will average this later.
                    scores[LayoutList[i] - 1] += oldVal;
                    Log("Score for Layout " + LayoutList[i] + ": " + scores[LayoutList[i] - 1].ToString());
                }
                Log("Score Array: " + string.Join(", ", scores));
                //Now we have a filled score array. 2 Things left: Averaging the scores (for number of layout inputs) and finding the highest score
                //Let's average the scores
                //Find out how many entries there are with each layout num
                for (int j = 0; j < myFirstBlankElement; j++)
                {
                    //Increase the frequency of each layout element
                    freq[LayoutList[j] - 1]++;
                }
                Log("Frequency Array: " + string.Join(", ", freq));
                //Finally we can average the scores
                for (int k = 0; k < freq.Count; k++)
                {
                    if (freq[k] != 0) scores[k] = scores[k] / freq[k];
                }
                Log("Corrected Score Array: " + string.Join(", ", scores));
                //Set the optimal layout to the highest score!
                optimalLayout = scores.IndexOf(scores.Max());
                optimalLayout++;
                Log("Best Layout: " + optimalLayout.ToString());
                //Clear the frequency array and score array
                freq.Clear();
                scores.Clear();
                Log("Cleared Arrays");
                //Write the best layout to the UI
                d_labelLabel.Text = "Optimal Layout:";
                d_bestLayoutLabel.Text = "Layout #" + optimalLayout.ToString();
                Log("Updated UI");
                Log("============================");
                Log("Update And Analyze Complete!");
                Log("============================");
            }
            catch
            {
                //If we get an error, it's most likely because everything is null (no entries) so tell them to enter data
                DialogResult result = MessageBox.Show("It Appears you have not enetered any match data. Please save at least one entry and try again. If you believe this is a mistake, please clear all match data and re-enter your matches.",
                    "No Match Data",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information);
                Log("========================================");
                Log("Update And Analyze Complete With Errors!");
                Log("========================================");
            }
        }

        //Everything that interacts directly with the JSON or fits closest with it
        #region JSON

        //Priority JSON stuff
        #region Priorities JSON

        //Gets values from the priority sliders and writes them to Priority.json
        private void WritePriPrefs(object sender, EventArgs e)
        {
            Log("===================");
            Log("Writting Priorities");
            Log("===================");
            //Create priority object to write values to
            PriorityPref myPri = new PriorityPref();
            //Set the attributes to the values of the sliders
            myPri.pri_hp = d_priHPSlider.Value;
            myPri.pri_time = d_priTimeSlider.Value;
            myPri.pri_rooms = d_priRoomSlider.Value;
            myPri.pri_crew = d_priCrewSlider.Value;
            //Create the file or make it blank
            File.Create(PriorityPath).Close();
            //Write the values to the actual json
            using (var JSONwriter = new StreamWriter(PriorityPath, true))
            {
                //Create a new string, can be literally any value except for ""
                string er = "NOT NULL";
                //This keeps retrying until there is no error
                while(er != "")
                {
                    try
                    {
                        //Serialize, write to JSON
                        JSONwriter.Write(JsonConvert.SerializeObject(myPri));
                        JSONwriter.Close();
                        //Set er to "" so we exit the loop
                        er = "";
                    }
                    //If we do get an error
                    catch(Exception err)
                    {
                        //Keep er not ""
                        er = err.ToString();
                    }
                }
            }
            //Set the globals from the Priority object
            PriorityHP = myPri.pri_hp;
            PriorityTime = myPri.pri_time;
            PriorityRoom = myPri.pri_rooms;
            PriorityCrew = myPri.pri_crew;
            Log("===================");
            Log("Priorities Written!");
            Log("===================");
        }

        //Reads from Priority.json and sets the sliders and the globals
        private void GetPriPrefs(object sender, EventArgs e)
        {
            try
            {
                Log("==================");
                Log("Getting Priorities");
                Log("==================");
                //Create a Priority object and get it from the JSON
                PriorityPref myPri = JsonConvert.DeserializeObject<PriorityPref>(File.ReadAllText(PriorityPath));
                Log("Pulled priorites from file");
                //Set the slider values from the object
                d_priHPSlider.Value = myPri.pri_hp;
                d_priTimeSlider.Value = myPri.pri_time;
                d_priRoomSlider.Value = myPri.pri_rooms;
                d_priCrewSlider.Value = myPri.pri_crew;
                Log("Set slider values");
                //Set the globals
                PriorityHP = myPri.pri_hp;
                PriorityTime = myPri.pri_time;
                PriorityRoom = myPri.pri_rooms;
                PriorityCrew = myPri.pri_crew;
                Log("Set variables");
                Log("====================");
                Log("Priorities Recieved!");
                Log("====================");
            }
            catch
            {
                //If it fails, they have no saved priorities (the file is empty/doesn't exist)
                DialogResult result = MessageBox.Show("You have no saved priorities",
                    "No Saved Priorities",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        #endregion

        //Match Info JSON stuff
        #region Match Info
       
        //Take all user data, put it into the JSON
        private void WriteUserDataToJSON(object sender, EventArgs e)
        {
            Log("==========================");
            Log("Writing Match Data To JSON");
            Log("==========================");
            //Create new, blank MatchInfo object
            MatchInfo myMatch = new MatchInfo();
            //Make sure the file is not blank. If it is, write a bunch of blank values to it.
            if (!File.Exists(InfoPath) || new FileInfo(InfoPath).Length == 0)
            {
                //It the file doesn't exist or is blank so we create a new blank one just in case
                File.Create(InfoPath).Close();
                //Set the JSON to the blank arrays
                using (var JSONwriter = new StreamWriter(InfoPath, true))
                {
                    //Create a new string, can be literally any value except for ""
                    string er = "NOT NULL";
                    //This keeps retrying until there is no error
                    while (er != "")
                    {
                        try
                        {
                            //Serialize, write to JSON
                            JSONwriter.Write(JsonConvert.SerializeObject(myMatch));
                            JSONwriter.Close();
                            //Set er to "" so we exit the loop
                            er = "";
                        }
                        //If we do get an error
                        catch (Exception err)
                        {
                            //Keep er not ""
                            er = err.ToString();
                        }
                    }
                }
                Log("Created new JSON for matches");
            }
            else
            {
                Log("Match JSON already exists");
            }
            //Set all of the values from the file into the MatchInfo object
            myMatch = JsonConvert.DeserializeObject<MatchInfo>(File.ReadAllText(InfoPath));
            //Add the values the user has entered in to the lists
            myMatch.inf_Layout.Add(Int16.Parse(d_layoutNum.Value.ToString()));
            myMatch.inf_myMaxHP.Add(Int16.Parse(d_myMaxHP.Text));
            myMatch.inf_myHP.Add(Double.Parse(d_myHPBox.Text));
            myMatch.inf_myMaxRooms.Add(Int16.Parse(d_maxRooms.Value.ToString()));
            myMatch.inf_myRoomsDest.Add(Int16.Parse(d_myRoomsDestroyed.Value.ToString()));
            myMatch.inf_myMaxCrew.Add(Int16.Parse(d_maxCrew.Value.ToString()));
            myMatch.inf_myCrewKilled.Add(Int16.Parse(d_myCrewKilled.Value.ToString()));
            myMatch.inf_opMaxHP.Add(Int16.Parse(d_opMaxHP.Text));
            myMatch.inf_opHP.Add(Double.Parse(d_opHP.Text));
            myMatch.inf_opMaxRooms.Add(Int16.Parse(d_opMaxRooms.Value.ToString()));
            myMatch.inf_opRoomsDest.Add(Int16.Parse(d_opRoomsBox.Value.ToString()));
            myMatch.inf_opMaxCrew.Add(Int16.Parse(d_opMaxCrew.Value.ToString()));
            myMatch.inf_opCrewKilled.Add(Int16.Parse(d_opCrewBox.Value.ToString()));
            Log("Wrote UI values to MatchData");
            //Do a bunch of math to find out how much was left it took as a percent, 100% being 3:00, 0% being 0:00. Round this down to 4 decimal places
            myMatch.inf_timePercent.Add(Math.Round(((Double.Parse(d_timeMins.Text) * 60) + Double.Parse(d_timeSecs.Text)) / 180, 4));
            //Clear the file, put everything back in it
            File.Create(InfoPath).Close();
            using (var JSONwriter = new StreamWriter(InfoPath, true))
            {
                //Create a new string, can be literally any value except for ""
                string er = "NOT NULL";
                //This keeps retrying until there is no error
                while (er != "")
                {
                    try
                    {
                        //Serialize, write to JSON
                        JSONwriter.Write(JsonConvert.SerializeObject(myMatch));
                        JSONwriter.Close();
                        //Set er to "" so we exit the loop
                        er = "";
                    }
                    //If we do get an error
                    catch (Exception err)
                    {
                        //Keep er anything but ""
                        er = err.ToString();
                    }
                }
                Log("Wrote MatchData to JSON");
            }
            //Burn all JSON elements to our globals so we don't reference the JSON every time
            LayoutList = myMatch.inf_Layout;
            myMaxHPList = myMatch.inf_myMaxHP;
            myHPList = myMatch.inf_myHP;
            myMaxRoomsList = myMatch.inf_myMaxRooms;
            myRoomsList = myMatch.inf_myRoomsDest;
            myMaxCrewList = myMatch.inf_myMaxCrew;
            myCrewList = myMatch.inf_myCrewKilled;
            opMaxHPList = myMatch.inf_opMaxHP;
            opHPList = myMatch.inf_opHP;
            opMaxRoomsList = myMatch.inf_opMaxRooms;
            opRoomsList = myMatch.inf_opRoomsDest;
            opMaxCrewList = myMatch.inf_opMaxCrew;
            opCrewList = myMatch.inf_opCrewKilled;
            timeList = myMatch.inf_timePercent;
            Log("Wrote object data to variables");
            Log("===================");
            Log("Match Data Written!");
            Log("===================");
        }

        //Check what element of the array is the first one unused
        private int FirstBlankElement(MatchInfo matchData)
        {
            //return the length, so we know how many times to go through the for loops
            return matchData.inf_Layout.Count();
        }

        //Clear the Info JSON File
        private void ClearMatchData(object sender, EventArgs e)
        {
            //Create blank file at the path it exists
            File.Create(InfoPath).Close();
            Log("Match Data Cleared");
        }

        #endregion

        #endregion

        //Just logs a string to LogPath, nothing to see here
        private void Log(string s)
        {
            using (var JSONwriter = new StreamWriter(LogPath, true))
            {
                string er = "NOT NULL";
                while (er != "")
                {
                    try
                    {
                        JSONwriter.WriteLine(DateTime.Now.ToString() + ": " + s);
                        JSONwriter.Close();
                        er = "";
                    }
                    catch (Exception err)
                    {
                        er = err.ToString();
                    }
                }
            }
        }

        //Draw our custom tabControl
        private void d_tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            //Create some brushes
            Brush blackBrush;
            Brush txtBrush;
            //Create a string format for our text
            StringFormat string_format;

            //Init and set the brushes
            blackBrush = Brushes.Black;
            txtBrush = Brushes.Gold;
            //Init the string Format
            string_format = new StringFormat();

            //Degine and draw a rectangle for each of our tabs
            Rectangle tab_rect = d_tabControl.GetTabRect(e.Index);

            e.Graphics.FillRectangle(blackBrush, tab_rect);

            //Define and draw a rectangle for the top part of the tabControl that will otherwise be white
            Rectangle topRect = new Rectangle();
            topRect.Width = 359;
            topRect.Height = 23;
            topRect.X = 225;
            
            e.Graphics.FillRectangle(blackBrush, topRect);

            //Define and draw a rectangle to hide the ugly white borders
            Rectangle botRect = new Rectangle();
            botRect.Width = 585;
            botRect.Height = 471;
            botRect.Y = 25;

            e.Graphics.FillRectangle(blackBrush, botRect);

            //Define a new rectangle where we will put our new text
            RectangleF layout_rect = new RectangleF(tab_rect.Left + 3, tab_rect.Y + 3, tab_rect.Width - 2 * 3, tab_rect.Height - 2 * 3);

            //Set allignment of the text
            string_format.Alignment = StringAlignment.Center;
            string_format.LineAlignment = StringAlignment.Center;
            //Draw the text
            e.Graphics.DrawString(d_tabControl.TabPages[e.Index].Text, e.Font, txtBrush, layout_rect, string_format);


        }

    }

    //Have a class that we can use to create our Info JSON
    public class MatchInfo
    {
        public List<int> inf_Layout = new List<int>();
        public List<int> inf_myMaxHP = new List<int>();
        public List<double> inf_myHP = new List<double>();
        public List<int> inf_myMaxRooms = new List<int>();
        public List<int> inf_myRoomsDest = new List<int>();
        public List<int> inf_myMaxCrew = new List<int>();
        public List<int> inf_myCrewKilled = new List<int>();
        public List<int> inf_opMaxHP = new List<int>();
        public List<double> inf_opHP = new List<double>();
        public List<int> inf_opMaxRooms = new List<int>();
        public List<int> inf_opRoomsDest = new List<int>();
        public List<int> inf_opMaxCrew = new List<int>();
        public List<int> inf_opCrewKilled = new List<int>();
        public List<double> inf_timePercent = new List<double>();
    }

    //Have a class that we can use to create our Priority JSON
    public class PriorityPref
    {
        public int pri_hp;
        public int pri_time;
        public int pri_rooms;
        public int pri_crew;
    }
}