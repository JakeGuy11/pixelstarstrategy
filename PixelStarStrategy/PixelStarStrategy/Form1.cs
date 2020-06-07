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

        public string Path = @"C:\PixelStarStrategy"; //The major path where everything is stored
        public string PriorityPath = @"C:\PixelStarStrategy\Priority.json"; //Where the priority preferences are stored
        public string InfoPath = @"C:\PixelStarStrategy\MatchInfo.json"; //Where all of the info about the matches are stored
        //Create variables that will hold the priorities of the different aspects evaluated
        public int PriorityHP = 10;
        public int PriorityTime = 10;
        public int PriorityRoom = 10;
        public int PriorityCrew = 10;

        #endregion

        //Runs at start
        #region Init

        //Runs at start
        public d_form()
        {
            //Initializes all GUI components
            InitializeComponent();
        }

        #endregion

        //The big stuff, calculations, etc.
        #region Main Functions
        
        //The 'Big Job', doing all calculations and displaying the best option
        private void UpdateAnalyze(object sender, EventArgs e)
        {
            //Step 1: Making sure the JSON is updated
            #region Update-Read JSON
            //Create new priority preference object
            PriorityPref myPri = new PriorityPref();
            //Setting the object to the values of the sliders
            myPri.pri_hp = d_priHPSlider.Value;
            myPri.pri_time = d_priTimeSlider.Value;
            myPri.pri_rooms = d_priRoomSlider.Value;
            myPri.pri_crew = d_priCrewSlider.Value;
            //Erase the old file
            File.Create(PriorityPath).Close();
            //Serialize and write the new values
            using (var JSONwriter = new StreamWriter(PriorityPath, true))
            {
                string er = "NOT NULL";
                while (er != "")
                {
                    try
                    {
                        JSONwriter.Write(JsonConvert.SerializeObject(myPri));
                        JSONwriter.Close();
                        er = "";
                    }
                    catch (Exception err)
                    {
                        er = err.ToString();
                    }
                }
            }
            //Get them again, deserialize and write back into the PriorityPref Object
            myPri = JsonConvert.DeserializeObject<PriorityPref>(File.ReadAllText(PriorityPath));
            //Write the sliders again with the proper preferences
            d_priHPSlider.Value = myPri.pri_hp;
            d_priTimeSlider.Value = myPri.pri_time;
            d_priRoomSlider.Value = myPri.pri_rooms;
            d_priCrewSlider.Value = myPri.pri_crew;
            //Set the globals so we can do the math we need to with it
            PriorityHP = myPri.pri_hp;
            PriorityTime = myPri.pri_time;
            PriorityRoom = myPri.pri_rooms;
            PriorityCrew = myPri.pri_crew;
            //TODO: Same as above but with all of the match data, will need a lot of parsing!
            #endregion
        }

        #endregion

        //Everything that interacts directly with the JSON or fits closest with it
        #region JSON

        //Priority JSON stuff
        #region Priorities JSON

        //Gets values from the priority sliders and writes them to Priority.json
        private void WritePriPrefs(object sender, EventArgs e)
        {
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
        }

        //Reads from Priority.json and sets the sliders and the globals
        private void GetPriPrefs(object sender, EventArgs e)
        {
            //Create a Priority object and get it from the JSON
            PriorityPref myPri = JsonConvert.DeserializeObject<PriorityPref>(File.ReadAllText(PriorityPath));
            //Set the slider values from the object
            d_priHPSlider.Value = myPri.pri_hp;
            d_priTimeSlider.Value = myPri.pri_time;
            d_priRoomSlider.Value = myPri.pri_rooms;
            d_priCrewSlider.Value = myPri.pri_crew;
            //Set the globals
            PriorityHP = myPri.pri_hp;
            PriorityTime = myPri.pri_time;
            PriorityRoom = myPri.pri_rooms;
            PriorityCrew = myPri.pri_crew;
    }

        #endregion

        //Match Info JSON stuff
        #region Match Info
       
        //Take all user data, put it into the JSON
        private void WriteUserDataToJSON(object sender, EventArgs e)
        {
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
            }
            //Set all of the values from the file into the MatchInfo object
            myMatch = JsonConvert.DeserializeObject<MatchInfo>(File.ReadAllText(InfoPath));
            //If all slots are occupied, let them know
            if (FirstBlankElement(myMatch) == -1)
            {
                //Tell the user all slots are used
                DialogResult result = MessageBox.Show("You have submitted the maximum amount of matches. Please clear all data.",
                    "Matches Exceeded!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            //If -1 is not returned, there are available slots. Continue with the parsing
            else
            {
                //Add the current values
                //Get a variable with the first blank element, just so we don't keep checking
                int firstBlankElement = FirstBlankElement(myMatch);
                //Just in case any of the data was put in wrong, we don't want to crash the app
                try
                {
                    //Set the first blank element of the arrays in the MatchInfo to the values the user has entered
                    myMatch.inf_Layout[firstBlankElement] = Int16.Parse(d_layoutNum.Value.ToString());
                    myMatch.inf_myHP[firstBlankElement] = Double.Parse(d_myHPBox.Text);
                    myMatch.inf_myRoomsDest[firstBlankElement] = Int16.Parse(d_myRoomsDestroyed.Value.ToString());
                    myMatch.inf_myCrewKilled[firstBlankElement] = Int16.Parse(d_myCrewKilled.Value.ToString());
                    myMatch.inf_opHP[firstBlankElement] = Double.Parse(d_opHP.Text);
                    myMatch.inf_opRoomsDest[firstBlankElement] = Int16.Parse(d_opRoomsBox.Value.ToString());
                    myMatch.inf_opCrewKilled[firstBlankElement] = Int16.Parse(d_opCrewBox.Value.ToString());
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
                                //Keep er not ""
                                er = err.ToString();
                            }
                        }
                    }
                    //Set the UI elements back to default
                    d_myHPBox.Text = "00.0";
                    d_myRoomsDestroyed.Text = "0";
                    d_myCrewKilled.Text = "0";
                    d_opHP.Text = "00.0";
                    d_opRoomsBox.Text = "0";
                    d_opCrewBox.Text = "0";
                    d_timeMins.Text = "3";
                    d_timeSecs.Text = "00";
                }
                //This means the data was formatted incorrectly by the user
                catch
                {
                    //Let them know the info was formatted wrong
                    DialogResult result = MessageBox.Show("One of the parameters is formatted incorrectly. Please fix and try again.",
                        "Data Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
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
        }

        #endregion

        #endregion

        
    }

    public class MatchInfo
    {
        public int[] inf_Layout = new int[10];
        public double[] inf_myHP = new double[10];
        public int[] inf_myRoomsDest = new int[10];
        public int[] inf_myCrewKilled = new int[10];
        public double[] inf_opHP = new double[10];
        public int[] inf_opRoomsDest = new int[10];
        public int[] inf_opCrewKilled = new int[10];
        public double[] inf_timePercent = new double[10];
    }

    public class PriorityPref
    {
        public int pri_hp;
        public int pri_time;
        public int pri_rooms;
        public int pri_crew;
    }
}
