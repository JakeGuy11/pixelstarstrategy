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
        public int[] LayoutArray = new int[10];
        public int[] myMaxHPArray = new int[10];
        public double[] myHPArray = new double[10];
        public int[] myMaxRoomsArray = new int[10];
        public int[] myRoomsArray = new int[10];
        public int[] myMaxCrewArray = new int[10];
        public int[] myCrewArray = new int[10];
        public int[] opMaxHPArray = new int[10];
        public double[] opHPArray = new double[10];
        public int[] opMaxRoomsArray = new int[10];
        public int[] opRoomsArray = new int[10];
        public int[] opMaxCrewArray = new int[10];
        public int[] opCrewArray = new int[10];
        public double[] timeArray = new double[10];
        //Array to hold the scores
        public double[] scores = new double[10];
        //Array to hold the frequencies of appearences of each layout
        public int[] freq = new int[10];
        //Variable to hold the best layout number
        public int optimalLayout = 0;

        #endregion

        //Runs at start
        #region Init

        //Runs at start
        public d_form()
        {
            //Initializes all GUI components
            InitializeComponent();
            //Inits a new Log file
            try
            {
                File.Create(LogPath).Close();
                Log("=============");
                Log("Beginning Log");
                Log("=============");
            }
            catch
            {
                Directory.CreateDirectory(Path);
                File.Create(LogPath).Close();
                Log("=============");
                Log("Beginning Log");
                Log("=============");
            }
            if (!File.Exists(InfoPath))
            {
                File.Create(InfoPath).Close();
            }
            //Try reading from the Priority preference file
        }

        #endregion

        //The big stuff, calculations, etc.
        #region Main Functions
        
        //doing all calculations and displaying the best option
        private void UpdateAnalyze(object sender, EventArgs e)
        {
            Log("==================");
            Log("UPDATE AND ANALYZE");
            Log("==================");
            Log("Starting the UPDATE phase");
            //Create new priority preference object
            PriorityPref myPri = new PriorityPref();
            //Setting the object to the values of the sliders
            myPri.pri_hp = d_priHPSlider.Value;
            myPri.pri_time = d_priTimeSlider.Value;
            myPri.pri_rooms = d_priRoomSlider.Value;
            myPri.pri_crew = d_priCrewSlider.Value;
            Log("Updated priorities from object(HP,Time,Rooms,Crew): " + myPri.pri_hp + ", " + myPri.pri_time + ", " + myPri.pri_rooms + ", " + myPri.pri_crew);
            //Set the globals so we can do the math we need to with it
            PriorityHP = myPri.pri_hp;
            PriorityTime = myPri.pri_time;
            PriorityRoom = myPri.pri_rooms;
            PriorityCrew = myPri.pri_crew;
            Log("Updated priorities from globals(HP,Time,Rooms,Crew): " + PriorityHP + ", " + PriorityTime + ", " + PriorityRoom + ", " + PriorityCrew);
            //Create new MatchInfo to read the JSON with the match data
            MatchInfo myMatch = new MatchInfo();
            //Deserialize, now we have a MatchInfo with all the saved data
            myMatch = JsonConvert.DeserializeObject<MatchInfo>(File.ReadAllText(InfoPath));
            //If anything fails, it'll be because myMatch is null (no user data)
            try
            {
                //Write all the info we need to variables so we don't keep referencing the object
                LayoutArray = myMatch.inf_Layout;
                Log("Layouts: " + string.Join(", ", LayoutArray));
                myHPArray = myMatch.inf_myHP;
                Log("My HPs: " + string.Join(", ", myHPArray));
                myRoomsArray = myMatch.inf_myRoomsDest;
                Log("My Rooms: " + string.Join(", ", myRoomsArray));
                myCrewArray = myMatch.inf_myCrewKilled;
                Log("My Crew: " + string.Join(", ", myCrewArray));
                opHPArray = myMatch.inf_opHP;
                Log("OP HPs: " + string.Join(", ", opHPArray));
                opRoomsArray = myMatch.inf_opRoomsDest;
                Log("OP Rooms: " + string.Join(", ", opRoomsArray));
                opCrewArray = myMatch.inf_opCrewKilled;
                Log("OP Crew: " + string.Join(", ", opCrewArray));
                timeArray = myMatch.inf_timePercent;
                Log("Times: " + string.Join(", ", timeArray));
                Log("Insert monologue about how stupid I am for forgetting to write the Max elements from the object to the variables :\\");
                myMaxHPArray = myMatch.inf_myMaxHP;
                Log("My Max HPs: " + string.Join(", ", myMaxHPArray));
                myMaxRoomsArray = myMatch.inf_myMaxRooms;
                Log("My Max Rooms: " + string.Join(", ", myMaxRoomsArray));
                myMaxCrewArray = myMatch.inf_myMaxCrew;
                Log("My Max Crews: " + string.Join(", ", myMaxCrewArray));
                opMaxHPArray = myMatch.inf_opMaxHP;
                Log("OP Max HPs: " + string.Join(", ", opMaxHPArray));
                opMaxRoomsArray = myMatch.inf_opMaxRooms;
                Log("OP Max Rooms: " + string.Join(", ", opMaxRoomsArray));
                opMaxCrewArray = myMatch.inf_opMaxCrew;
                Log("OP Max Crews: " + string.Join(", ", opMaxCrewArray));
                //Now we have everything we need! Time to have our AI algorithm calculate the outcome!
                Log("UPDATE Phase Complete");
                Log("Beggining Analyze Phase");
                
                int myFirstBlankElement = FirstBlankElement(myMatch);
                //Now we go through it as many times as there are entries in the JSON
                for(int i = 0; i < myFirstBlankElement; i++)
                {
                    //Get the old value. We will be doing all the math the the variable so we don't want to loose it
                    double oldVal = scores[LayoutArray[i]];
                    Log("oldVal: " + oldVal.ToString());
                    //First operation, so we don't add, we set. But we set it to (myHPPercent-(opHPPercent/2))*HP priority
                    //For the rest, we just add to it using the AI algorithms we set. I'll keep the algorithm to myself for now ;) (Unless you can look at it and understand)
                    scores[LayoutArray[i]] = ((myHPArray[i]/myMaxHPArray[i])-opHPArray[i]/opMaxHPArray[i]/2)*PriorityHP;
                    Log("HP Score: " + (((myHPArray[i] / myMaxHPArray[i]) - opHPArray[i] / opMaxHPArray[i] / 2) * PriorityHP).ToString());
                    scores[LayoutArray[i]] += (opRoomsArray[i] / opMaxRoomsArray[i]) - myRoomsArray[i] / myMaxRoomsArray[i] * PriorityRoom;
                    Log("Room Score: " + ((opRoomsArray[i] / opMaxRoomsArray[i]) - myRoomsArray[i] / myMaxRoomsArray[i] * PriorityRoom).ToString());
                    scores[LayoutArray[i]] += (myCrewArray[i] / myMaxCrewArray[i]) - opCrewArray[i] / opMaxCrewArray[i]/2 * PriorityCrew;
                    Log("Crew Score: " + ((myCrewArray[i] / myMaxCrewArray[i]) - opCrewArray[i] / opMaxCrewArray[i] / 2 * PriorityCrew).ToString());
                    scores[LayoutArray[i]] += timeArray[i] * PriorityTime;
                    Log("Time Score: " + (timeArray[i] * PriorityTime).ToString());
                    //Add the old value to get a culmitave score. We will average this later.
                    scores[LayoutArray[i]] += oldVal;
                    Log("Score for Layout " + LayoutArray[i] + ": " + scores[LayoutArray[i]].ToString());
                }
                Log("Score Array: " + string.Join(", ", scores));
                //Now we have a filled score array. 2 Things left: Averaging the scores (for number of layout inputs) and finding the highest score
                //Let's average the scores
                //Find out how many entries there are with each layout num
                for(int j = 0; j < 9; j++)
                {
                    //Increase the frequency of each layout element
                    freq[LayoutArray[j]]++;
                }
                Log("Frequency Array: " + string.Join(", ", freq));
                //Finally we can average the scores
                for(int k = 0; k <= 9; k++)
                {
                    if(freq[k] != 0) scores[k] = scores[k] / freq[k];
                }
                Log("Corrected Score Array: " + string.Join(", ", scores));
                //Set the optimal layout to the highest score!
                optimalLayout = scores.ToList().IndexOf(scores.Max());
                Log("Best Layout: " + optimalLayout.ToString());
                //Clear the frequency array and score array
                freq = new int[10];
                scores = new double[10];
                Log("Cleared Arrays");
                //Write the best layout to the UI
                d_labelLabel.Text = "Optimal Layout:";
                d_bestLayoutLabel.Text = "Layout #" + optimalLayout.ToString();
                Log("Updated UI");
                Log("============================");
                Log("Update And Analyze Complete!");
                Log("============================");
            }
            //No user data, let them know
            catch
            {
                DialogResult result = MessageBox.Show("You have not added any matches. Please add at least one match and try again.",
                    "No User Data",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information);
                Log("========================================");
                Log("Update And Analyze Complete With Errors!");
                Log("========================================");
            }
        }

        #endregion

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
            //Let the user know that their data will be overwritten
            DialogResult result = MessageBox.Show("This action will overwrite your previous priority data. Are you sure you want to continue?",
                "Save Warning",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information);
            //If they are ok with it, start writing
            if (result == System.Windows.Forms.DialogResult.OK)
            {
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
            } //If they don't want their data overwritten, do nothing, let them keep going
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
            //If all slots are occupied, let them know
            if (FirstBlankElement(myMatch) == -1)
            {
                //Tell the user all slots are used
                DialogResult result = MessageBox.Show("You have submitted the maximum amount of matches. Please clear all data.",
                    "Matches Exceeded",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Log("Matches Exceeded");
            }
            //If -1 is not returned, there are available slots. Continue with the parsing
            else
            {
                Log("Matches not exceeded, continuing");
                //Add the current values
                //Get a variable with the first blank element, just so we don't keep checking
                int firstBlankElement = FirstBlankElement(myMatch);
                Log("First blank element: " + firstBlankElement);
                //Just in case any of the data was put in wrong, we don't want to crash the app
                try
                {
                    //Set the first blank element of the arrays in the MatchInfo to the values the user has entered
                    myMatch.inf_Layout[firstBlankElement] = Int16.Parse(d_layoutNum.Value.ToString());
                    myMatch.inf_myMaxHP[firstBlankElement] = Int16.Parse(d_myMaxHP.Text);
                    myMatch.inf_myHP[firstBlankElement] = Double.Parse(d_myHPBox.Text);
                    myMatch.inf_myMaxRooms[firstBlankElement] = Int16.Parse(d_maxRooms.Value.ToString());
                    myMatch.inf_myRoomsDest[firstBlankElement] = Int16.Parse(d_myRoomsDestroyed.Value.ToString());
                    myMatch.inf_myMaxCrew[firstBlankElement] = Int16.Parse(d_maxCrew.Value.ToString());
                    myMatch.inf_myCrewKilled[firstBlankElement] = Int16.Parse(d_myCrewKilled.Value.ToString());
                    myMatch.inf_opMaxHP[firstBlankElement] = Int16.Parse(d_opMaxHP.Text);
                    myMatch.inf_opHP[firstBlankElement] = Double.Parse(d_opHP.Text);
                    myMatch.inf_opMaxRooms[firstBlankElement] = Int16.Parse(d_opMaxRooms.Value.ToString());
                    myMatch.inf_opRoomsDest[firstBlankElement] = Int16.Parse(d_opRoomsBox.Value.ToString());
                    myMatch.inf_opMaxCrew[firstBlankElement] = Int16.Parse(d_opMaxCrew.Value.ToString());
                    myMatch.inf_opCrewKilled[firstBlankElement] = Int16.Parse(d_opCrewBox.Value.ToString());
                    Log("Wrote UI values to MatchData");
                    //Do a bunch of math to find out how much was left it took as a percent, 100% being 3:00, 0% being 0:00. Round this down to 4 decimal places
                    myMatch.inf_timePercent[firstBlankElement] = Math.Round(((Double.Parse(d_timeMins.Text) * 60) + Double.Parse(d_timeSecs.Text)) / 180, 4);
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
                    LayoutArray = myMatch.inf_Layout;
                    myMaxHPArray = myMatch.inf_myMaxHP;
                    myHPArray = myMatch.inf_myHP;
                    myMaxRoomsArray = myMatch.inf_myMaxRooms;
                    myRoomsArray = myMatch.inf_myRoomsDest;
                    myMaxCrewArray = myMatch.inf_myMaxCrew;
                    myCrewArray = myMatch.inf_myCrewKilled;
                    opMaxHPArray = myMatch.inf_opMaxHP;
                    opHPArray = myMatch.inf_opHP;
                    opMaxRoomsArray = myMatch.inf_opMaxRooms;
                    opRoomsArray = myMatch.inf_opRoomsDest;
                    opMaxCrewArray = myMatch.inf_opMaxCrew;
                    opCrewArray = myMatch.inf_opCrewKilled;
                    timeArray = myMatch.inf_timePercent;
                    Log("Wrote object data to variables");
                }
                //This means the data was formatted incorrectly by the user
                catch
                {
                    //Let them know the info was formatted wrong
                    DialogResult result = MessageBox.Show("One of the parameters is formatted incorrectly. Please fix and try again.",
                        "Data Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    Log("Data formatted incorrectly");
                }
            }
            Log("===================");
            Log("Match Data Written!");
            Log("===================");
        }

        //Check what element of the array is the first one unused
        private int FirstBlankElement(MatchInfo matchData)
        {
            //By default, return -1. This will only happen if all other slots are occupied.
            int retVal = -1;
            //Go through each slot, check if it is unused. If so, return the element # of the first unused slot. TODO: Make this more efficient
            if (matchData.inf_Layout[0] == 0) retVal = 0;
            else if (matchData.inf_Layout[1] == 0) retVal = 1;
            else if (matchData.inf_Layout[2] == 0) retVal = 2;
            else if (matchData.inf_Layout[3] == 0) retVal = 3;
            else if (matchData.inf_Layout[4] == 0) retVal = 4;
            else if (matchData.inf_Layout[5] == 0) retVal = 5;
            else if (matchData.inf_Layout[6] == 0) retVal = 6;
            else if (matchData.inf_Layout[7] == 0) retVal = 7;
            else if (matchData.inf_Layout[8] == 0) retVal = 8;
            else if (matchData.inf_Layout[9] == 0) retVal = 9;
            return retVal;
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
    }

    //Have a class that we can use to create our Info JSON
    public class MatchInfo
    {
        public int[] inf_Layout = new int[10];
        public int[] inf_myMaxHP = new int[10];
        public double[] inf_myHP = new double[10];
        public int[] inf_myMaxRooms = new int[10];
        public int[] inf_myRoomsDest = new int[10];
        public int[] inf_myMaxCrew = new int[10];
        public int[] inf_myCrewKilled = new int[10];
        public int[] inf_opMaxHP = new int[10];
        public double[] inf_opHP = new double[10];
        public int[] inf_opMaxRooms = new int[10];
        public int[] inf_opRoomsDest = new int[10];
        public int[] inf_opMaxCrew = new int[10];
        public int[] inf_opCrewKilled = new int[10];
        public double[] inf_timePercent = new double[10];
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