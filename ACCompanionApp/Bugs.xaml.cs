using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AppLibrary;

namespace ACCompanionApp
{
    /// <summary>
    /// Interaction logic for Bugs.xaml
    /// </summary>
    public partial class Bugs : Page
    {
        // lists to add into
        List<int> bugNum = new List<int>();
        List<int> bugPics = new List<int>();
        List<string> bugNames = new List<string>();
        string Month;

        // getting the player info
        static string[] playerArr = File.ReadAllLines("player.txt");
        User player = new User(playerArr[0], playerArr[1], playerArr[2]);

        // array of months
        string[] months = new string[]
            {
                "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
            };


        public Bugs()
        {
            InitializeComponent();

            // Setting the current month, and displaying current date and time
            DateTimeBug.Content = $"The current date and time is {DateTime.Now.ToString()}";
            if (DateTime.Now.ToString("MM") == "01")
            {
                Month = "January";
            }
            else if (DateTime.Now.ToString("MM") == "02")
            {
                Month = "February";
            }
            else if (DateTime.Now.ToString("MM") == "03")
            {
                Month = "March";
            }
            else if (DateTime.Now.ToString("MM") == "04")
            {
                Month = "April";
            }
            else if (DateTime.Now.ToString("MM") == "05")
            {
                Month = "May";
            }
            else if (DateTime.Now.ToString("MM") == "06")
            {
                Month = "June";
            }
            else if (DateTime.Now.ToString("MM") == "07")
            {
                Month = "July";
            }
            else if (DateTime.Now.ToString("MM") == "08")
            {
                Month = "August";
            }
            else if (DateTime.Now.ToString("MM") == "09")
            {
                Month = "September";
            }
            else if (DateTime.Now.ToString("MM") == "10")
            {
                Month = "October";
            }
            else if (DateTime.Now.ToString("MM") == "11")
            {
                Month = "November";
            }
            else if (DateTime.Now.ToString("MM") == "12")
            {
                Month = "December";
            }

            DateTimeBug.Content += $"\n Bugs available in {Month}:";

        }

        // Creating a list of bugIDs of the bugs currently in season (for each hemisphere)
        // Starts check by if available all year, then narrowing down by each month it appears
        private async Task CurrentBug(int bugID)
        {

            var bugAvil = await BugProcessorAvail.LoadBugAvil(bugID);
            if (bugAvil.AllYear == true)
            {
                bugNum.Add(bugID);
            }
            else
            {
                if (player.GetHemisphere() == "North")
                {
                    if (bugAvil.MonthNorth.Length <= 2)
                    {
                        var bugMonth = months[Int32.Parse(bugAvil.MonthNorth) - 1];
                        if (bugMonth == Month)
                        {
                            bugNum.Add(bugID);
                        }
                    }
                    else if (bugAvil.MonthNorth.Length <= 5)
                    {
                        string[] dateArr = bugAvil.MonthNorth.Split('-');
                        if (Int32.Parse(dateArr[0]) < Int32.Parse(dateArr[1]))
                        {
                            List<string> bugMonths = new List<string>();
                            for (int j = Int32.Parse(dateArr[0]) - 1; j < Int32.Parse(dateArr[1]); j++)
                            {
                                bugMonths.Add(months[j]);
                            }
                            foreach (string m in bugMonths)
                            {
                                if (m == Month)
                                {
                                    bugNum.Add(bugID);
                                }
                            }
                        }
                        else if (Int32.Parse(dateArr[0]) > Int32.Parse(dateArr[1]))
                        {
                            List<string> bugMonths = new List<string>();
                            for (int k = Int32.Parse(dateArr[0]) - 1; k <= 11; k++)
                            {
                                bugMonths.Add(months[k]);
                            }
                            for (int l = 0; l < Int32.Parse(dateArr[1]); l++)
                            {
                                bugMonths.Add(months[l]);
                            }
                            foreach (string n in bugMonths)
                            {
                                if (n == Month)
                                {
                                    bugNum.Add(bugID);
                                }
                            }
                        }
                    }
                    else if (bugAvil.MonthNorth.Length <= 8)
                    {
                        string[] multiMonths = bugAvil.MonthNorth.Split(' ');
                        string[] dateArrFirst = multiMonths[0].Split('-');
                        if (Int32.Parse(dateArrFirst[0]) < Int32.Parse(dateArrFirst[1]))
                        {
                            List<string> bugMonths = new List<string>();
                            for (int a = Int32.Parse(dateArrFirst[0]) - 1; a < Int32.Parse(dateArrFirst[1]); a++)
                            {
                                bugMonths.Add(months[a]);
                            }
                            foreach (string t in bugMonths)
                            {
                                if (t == Month)
                                {
                                    bugNum.Add(bugID);
                                }
                            }
                        }
                        else if (Int32.Parse(dateArrFirst[0]) > Int32.Parse(dateArrFirst[1]))
                        {
                            List<string> bugMonths = new List<string>();
                            for (int p = Int32.Parse(dateArrFirst[0]) - 1; p <= 11; p++)
                            {
                                bugMonths.Add(months[p]);
                            }
                            for (int q = 0; q < Int32.Parse(dateArrFirst[1]); q++)
                            {
                                bugMonths.Add(months[q]);
                            }
                            foreach (string h in bugMonths)
                            {
                                if (h == Month)
                                {
                                    bugNum.Add(bugID);
                                }
                            }
                        }
                        if (months[Int32.Parse(multiMonths[2]) - 1] == Month)
                        {
                            bugNum.Add(bugID);
                        }
                    }
                    else if (bugAvil.MonthNorth.Length >= 9)
                    {
                        string[] multiMonths = bugAvil.MonthNorth.Split(' ');
                        string[] dateArrFirst = multiMonths[0].Split('-');
                        string[] dateArrSecond = multiMonths[2].Split('-');
                        if (Int32.Parse(dateArrFirst[0]) < Int32.Parse(dateArrFirst[1]))
                        {
                            List<string> bugMonths = new List<string>();
                            for (int a = Int32.Parse(dateArrFirst[0]) - 1; a < Int32.Parse(dateArrFirst[1]); a++)
                            {
                                bugMonths.Add(months[a]);
                            }
                            foreach (string t in bugMonths)
                            {
                                if (t == Month)
                                {
                                    bugNum.Add(bugID);
                                }
                            }
                        }
                        else if (Int32.Parse(dateArrFirst[0]) > Int32.Parse(dateArrFirst[1]))
                        {
                            List<string> bugMonths = new List<string>();
                            for (int p = Int32.Parse(dateArrFirst[0]) - 1; p <= 11; p++)
                            {
                                bugMonths.Add(months[p]);
                            }
                            for (int q = 0; q < Int32.Parse(dateArrFirst[1]); q++)
                            {
                                bugMonths.Add(months[q]);
                            }
                            foreach (string h in bugMonths)
                            {
                                if (h == Month)
                                {
                                    bugNum.Add(bugID);
                                }
                            }
                        }
                        if (Int32.Parse(dateArrSecond[0]) < Int32.Parse(dateArrSecond[1]))
                        {
                            List<string> bugMonths = new List<string>();
                            for (int b = Int32.Parse(dateArrSecond[0]) - 1; b < Int32.Parse(dateArrSecond[1]); b++)
                            {
                                bugMonths.Add(months[b]);
                            }
                            foreach (string y in bugMonths)
                            {
                                if (y == Month)
                                {
                                    bugNum.Add(bugID);
                                }
                            }
                        }
                        else if (Int32.Parse(dateArrSecond[0]) > Int32.Parse(dateArrSecond[1]))
                        {
                            List<string> bugMonths = new List<string>();
                            for (int c = Int32.Parse(dateArrSecond[0]) - 1; c <= 11; c++)
                            {
                                bugMonths.Add(months[c]);
                            }
                            for (int d = 0; d < Int32.Parse(dateArrSecond[1]); d++)
                            {
                                bugMonths.Add(months[d]);
                            }
                            foreach (string g in bugMonths)
                            {
                                if (g == Month)
                                {
                                    bugNum.Add(bugID);
                                }
                            }
                        }
                    }
                }
                if (player.GetHemisphere() == "South")
                {
                    if (bugAvil.MonthSouth.Length <= 2)
                    {
                        var bugMonth = months[Int32.Parse(bugAvil.MonthSouth) - 1];
                        if (bugMonth == Month)
                        {
                            bugNum.Add(bugID);
                        }
                    }
                    else if (bugAvil.MonthSouth.Length <= 5)
                    {
                        string[] dateArr = bugAvil.MonthSouth.Split('-');
                        if (Int32.Parse(dateArr[0]) < Int32.Parse(dateArr[1]))
                        {
                            List<string> bugMonths = new List<string>();
                            for (int j = Int32.Parse(dateArr[0]) - 1; j < Int32.Parse(dateArr[1]); j++)
                            {
                                bugMonths.Add(months[j]);
                            }
                            foreach (string m in bugMonths)
                            {
                                if (m == Month)
                                {
                                    bugNum.Add(bugID);
                                }
                            }
                        }
                        else if (Int32.Parse(dateArr[0]) > Int32.Parse(dateArr[1]))
                        {
                            List<string> bugMonths = new List<string>();
                            for (int k = Int32.Parse(dateArr[0]) - 1; k <= 11; k++)
                            {
                                bugMonths.Add(months[k]);
                            }
                            for (int l = 0; l < Int32.Parse(dateArr[1]); l++)
                            {
                                bugMonths.Add(months[l]);
                            }
                            foreach (string n in bugMonths)
                            {
                                if (n == Month)
                                {
                                    bugNum.Add(bugID);
                                }
                            }
                        }
                    }
                    else if (bugAvil.MonthSouth.Length <= 8)
                    {
                        string[] multiMonths = bugAvil.MonthSouth.Split(' ');
                        string[] dateArrFirst = multiMonths[0].Split('-');
                        if (Int32.Parse(dateArrFirst[0]) < Int32.Parse(dateArrFirst[1]))
                        {
                            List<string> bugMonths = new List<string>();
                            for (int a = Int32.Parse(dateArrFirst[0]) - 1; a < Int32.Parse(dateArrFirst[1]); a++)
                            {
                                bugMonths.Add(months[a]);
                            }
                            foreach (string t in bugMonths)
                            {
                                if (t == Month)
                                {
                                    bugNum.Add(bugID);
                                }
                            }
                        }
                        else if (Int32.Parse(dateArrFirst[0]) > Int32.Parse(dateArrFirst[1]))
                        {
                            List<string> bugMonths = new List<string>();
                            for (int p = Int32.Parse(dateArrFirst[0]) - 1; p <= 11; p++)
                            {
                                bugMonths.Add(months[p]);
                            }
                            for (int q = 0; q < Int32.Parse(dateArrFirst[1]); q++)
                            {
                                bugMonths.Add(months[q]);
                            }
                            foreach (string h in bugMonths)
                            {
                                if (h == Month)
                                {
                                    bugNum.Add(bugID);
                                }
                            }
                        }
                        if (months[Int32.Parse(multiMonths[2]) - 1] == Month)
                        {
                            bugNum.Add(bugID);
                        }
                    }
                    else if (bugAvil.MonthSouth.Length >= 9)
                    {
                        string[] multiMonths = bugAvil.MonthSouth.Split(' ');
                        string[] dateArrFirst = multiMonths[0].Split('-');
                        string[] dateArrSecond = multiMonths[2].Split('-');
                        if (Int32.Parse(dateArrFirst[0]) < Int32.Parse(dateArrFirst[1]))
                        {
                            List<string> bugMonths = new List<string>();
                            for (int a = Int32.Parse(dateArrFirst[0]) - 1; a < Int32.Parse(dateArrFirst[1]); a++)
                            {
                                bugMonths.Add(months[a]);
                            }
                            foreach (string t in bugMonths)
                            {
                                if (t == Month)
                                {
                                    bugNum.Add(bugID);
                                }
                            }
                        }
                        else if (Int32.Parse(dateArrFirst[0]) > Int32.Parse(dateArrFirst[1]))
                        {
                            List<string> bugMonths = new List<string>();
                            for (int p = Int32.Parse(dateArrFirst[0]) - 1; p <= 11; p++)
                            {
                                bugMonths.Add(months[p]);
                            }
                            for (int q = 0; q < Int32.Parse(dateArrFirst[1]); q++)
                            {
                                bugMonths.Add(months[q]);
                            }
                            foreach (string h in bugMonths)
                            {
                                if (h == Month)
                                {
                                    bugNum.Add(bugID);
                                }
                            }
                        }
                        if (Int32.Parse(dateArrSecond[0]) < Int32.Parse(dateArrSecond[1]))
                        {
                            List<string> bugMonths = new List<string>();
                            for (int b = Int32.Parse(dateArrSecond[0]) - 1; b < Int32.Parse(dateArrSecond[1]); b++)
                            {
                                bugMonths.Add(months[b]);
                            }
                            foreach (string y in bugMonths)
                            {
                                if (y == Month)
                                {
                                    bugNum.Add(bugID);
                                }
                            }
                        }
                        else if (Int32.Parse(dateArrSecond[0]) > Int32.Parse(dateArrSecond[1]))
                        {
                            List<string> bugMonths = new List<string>();
                            for (int c = Int32.Parse(dateArrSecond[0]) - 1; c <= 11; c++)
                            {
                                bugMonths.Add(months[c]);
                            }
                            for (int d = 0; d < Int32.Parse(dateArrSecond[1]); d++)
                            {
                                bugMonths.Add(months[d]);
                            }
                            foreach (string g in bugMonths)
                            {
                                if (g == Month)
                                {
                                    bugNum.Add(bugID);
                                }
                            }
                        }
                    }
                }
            }

        }

        // puts the bug names into the scroll block text
        private async Task PullBug(int bugID)
        {
            var bug = await BugProcessor.LoadBug(bugID);
            bugBlock.Content += $"\n {bug.NameEn.ToUpper()} ";
        }

        // adds the names of the bugs to a list, for the labels (picture section)
        private async Task ForBugPics(int bugID)
        {
            var bug = await BugProcessor.LoadBug(bugID);
            bugNames.Add(bug.NameEn);
        }



        private async void GridLoad(object sender, RoutedEventArgs e)
        {
            // running through all 80 bugs to check if current
            for (int i = 1; i <= 80; i++)
            {
               await CurrentBug(i);
            }

            // writing names of all current bugs to scroll block
            foreach (int f in bugNum)
            {
                await PullBug(f);
            }

            // pulls the bugID for the first 6 bugs in the list (for the pictures)
            for (int p = 0; p <= 5; p++)
            {
                bugPics.Add(bugNum[p]);
            }

            // pulling the names of the bugs for the pictures
            foreach (int g in bugPics)
            {
                await ForBugPics(g);
            }

            // adding images with names of the first 6 bugs available
            var uriSource0 = new Uri($"http://acnhapi.com/icons/bugs/{bugNum[0]}");
            Bug00.Source = new BitmapImage(uriSource0);
            Text00.Text = $"{bugNames[0].ToUpper()}";

            var uriSource1 = new Uri($"http://acnhapi.com/icons/bugs/{bugNum[1]}");
            Bug01.Source = new BitmapImage(uriSource1);
            Text01.Text = $"{bugNames[1].ToUpper()}";

            var uriSource2 = new Uri($"http://acnhapi.com/icons/bugs/{bugNum[2]}");
            Bug02.Source = new BitmapImage(uriSource2);
            Text02.Text = $"{bugNames[2].ToUpper()}";

            var uriSource3 = new Uri($"http://acnhapi.com/icons/bugs/{bugNum[3]}");
            Bug03.Source = new BitmapImage(uriSource3);
            Text03.Text = $"{bugNames[3].ToUpper()}";

            var uriSource4 = new Uri($"http://acnhapi.com/icons/bugs/{bugNum[4]}");
            Bug04.Source = new BitmapImage(uriSource4);
            Text04.Text = $"{bugNames[4].ToUpper()}";

            var uriSource5 = new Uri($"http://acnhapi.com/icons/bugs/{bugNum[5]}");
            Bug05.Source = new BitmapImage(uriSource5);
            Text05.Text = $"{bugNames[5].ToUpper()}";
        }

        // navigate back to the home page
        private void GoHome(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new HomePage());
        }
    }
}
