using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ElectionVotes
{
    public partial class Form1 : Form
    {
        //Name: Cameron Nepe
        //ID  : 1262199

        public Form1()
        {
            InitializeComponent();
        }

        List<string> partyName = new List<string>();
        List<int> numberVotes = new List<int>();

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            //Declare variables
            const string FILTER = "CSV Files|*.csv|ALL Files|*.*";
            StreamReader reader;
            string[] csvArray;
            string line = "";
            string party_name = "";
            int number_votes = 0;
            //int seatsInParliment = 0;
            int totalSeatsPerParty = 0;

            //SET the filter for the dialog control
            openFileDialog1.Filter = FILTER;
            //CHECK to see if the user has selected a file to open
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //OPEN the selected file
                reader = File.OpenText(openFileDialog1.FileName);
                //REPEAT while it is not the end of the file
                while (!reader.EndOfStream)
                {
                    try
                    {
                        //Read an entire line from the file
                        line = reader.ReadLine();
                        Console.WriteLine(line);
                        //Split the line storing values in an array
                        csvArray = line.Split(',');
                        if (csvArray.Length == 2)
                        {
                            //Extract the values from the list into separate variables
                            party_name = (csvArray[0]);
                            number_votes = int.Parse(csvArray[1]);

                            //Add the values to the lists
                            partyName.Add(party_name);
                            numberVotes.Add(number_votes);

                            ////Display values into listBox
                            listBoxDisplay.Items.Add(party_name.PadRight(20) + number_votes + totalSeatsPerParty);
                        }
                        else
                        {
                            Console.WriteLine("Error: " + line);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error: " + line);
                    }
                }                
            }
            else
            {
                Console.WriteLine("This is the wrong file");
            }

            // Calculate how many seats a party would get based on the number of votes
            // Get the total votes
            int total_votes = numberVotes.Sum();
            // Seats in Parliment
            int parlimentSeats = 120;
            // Divide the total number of votes by parliment seats
            int votes_needed = total_votes / parlimentSeats;

            Console.WriteLine(votes_needed);

            for (int i = 0; i <= partyName.Count; i++)
            {
                //how many seats each party gained
                totalSeatsPerParty = numberVotes.Sum() / votes_needed;
                //seatsInParliment = numberVotes[i] / total_votes;
                //Console.WriteLine(seatsInParliment);
            }
        }
    }
}
