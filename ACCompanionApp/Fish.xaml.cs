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
    /// Interaction logic for Fish.xaml
    /// </summary>
    public partial class Fish : Page
    {
        List<int> fishNum = new List<int>();
        string Month;

        static string[] playerArr = File.ReadAllLines("player.txt");
        User player = new User(playerArr[0], playerArr[1], playerArr[2]);

        string[] months = new string[]
            {
                "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
            };


        public Fish()
        {
            InitializeComponent();
            DateTimeFish.Content = $"The current date and time is {DateTime.Now.ToString()}";
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

            DateTimeFish.Content += $"\n Fish available in {Month}:";
            
        }

        private async Task CurrentFish(int fishID)
        {
            
            var fishAvil = await FishProcessorAvail.LoadFishAvil(fishID);
            if (fishAvil.AllYear == true)
            {
                fishNum.Add(fishID);
            }
            else
            {
                if (player.GetHemisphere() == "North")
                {
                    if (fishAvil.MonthNorth.Length <= 2)
                    {
                        var fishMonth = months[Int32.Parse(fishAvil.MonthNorth) - 1];
                        if (fishMonth == Month)
                        {
                            fishNum.Add(fishID);
                        }
                    }
                    else if (fishAvil.MonthNorth.Length <= 5)
                    {
                        string[] dateArr = fishAvil.MonthNorth.Split('-');
                        if (Int32.Parse(dateArr[0]) < Int32.Parse(dateArr[1]))
                        {
                            List<string> fishMonths = new List<string>();
                            for (int j = Int32.Parse(dateArr[0]) - 1; j < Int32.Parse(dateArr[1]); j++)
                            {
                                fishMonths.Add(months[j]);
                            }
                            foreach (string m in fishMonths)
                            {
                                if (m == Month)
                                {
                                    fishNum.Add(fishID);
                                }
                            }
                        }
                        else if (Int32.Parse(dateArr[0]) > Int32.Parse(dateArr[1]))
                        {
                            List<string> fishMonths = new List<string>();
                            for (int k = Int32.Parse(dateArr[0]) - 1; k <= 11; k++)
                            {
                                fishMonths.Add(months[k]);
                            }
                            for (int l = 0; l < Int32.Parse(dateArr[1]); l++)
                            {
                                fishMonths.Add(months[l]);
                            }
                            foreach (string n in fishMonths)
                            {
                                if (n == Month)
                                {
                                    fishNum.Add(fishID);
                                }
                            }
                        }
                    }
                    else if (fishAvil.MonthNorth.Length > 5)
                    {
                        string[] multiMonths = fishAvil.MonthNorth.Split(' ');
                        string[] dateArrFirst = multiMonths[0].Split('-');
                        string[] dateArrSecond = multiMonths[2].Split('-');
                        if (Int32.Parse(dateArrFirst[0]) < Int32.Parse(dateArrFirst[1]))
                        {
                            List<string> fishMonths = new List<string>();
                            for (int a = Int32.Parse(dateArrFirst[0]) - 1; a < Int32.Parse(dateArrFirst[1]); a++)
                            {
                                fishMonths.Add(months[a]);
                            }
                            foreach (string t in fishMonths)
                            {
                                if (t == Month)
                                {
                                    fishNum.Add(fishID);
                                }
                            }
                        }
                        else if (Int32.Parse(dateArrFirst[0]) > Int32.Parse(dateArrFirst[1]))
                        {
                            List<string> fishMonths = new List<string>();
                            for (int p = Int32.Parse(dateArrFirst[0]) - 1; p <= 11; p++)
                            {
                                fishMonths.Add(months[p]);
                            }
                            for (int q = 0; q < Int32.Parse(dateArrFirst[1]); q++)
                            {
                                fishMonths.Add(months[q]);
                            }
                            foreach (string h in fishMonths)
                            {
                                if (h == Month)
                                {
                                    fishNum.Add(fishID);
                                }
                            }
                        }
                        if (Int32.Parse(dateArrSecond[0]) < Int32.Parse(dateArrSecond[1]))
                        {
                            List<string> fishMonths = new List<string>();
                            for (int b = Int32.Parse(dateArrSecond[0]) - 1; b < Int32.Parse(dateArrSecond[1]); b++)
                            {
                                fishMonths.Add(months[b]);
                            }
                            foreach (string y in fishMonths)
                            {
                                if (y == Month)
                                {
                                    fishNum.Add(fishID);
                                }
                            }
                        }
                        else if (Int32.Parse(dateArrSecond[0]) > Int32.Parse(dateArrSecond[1]))
                        {
                            List<string> fishMonths = new List<string>();
                            for (int c = Int32.Parse(dateArrSecond[0]) - 1; c <= 11; c++)
                            {
                                fishMonths.Add(months[c]);
                            }
                            for (int d = 0; d < Int32.Parse(dateArrSecond[1]); d++)
                            {
                                fishMonths.Add(months[d]);
                            }
                            foreach (string g in fishMonths)
                            {
                                if (g == Month)
                                {
                                    fishNum.Add(fishID);
                                }
                            }
                        }
                    }
                }
                if (player.GetHemisphere() == "South")
                {
                    if (fishAvil.MonthSouth.Length <= 2)
                    {
                        var fishMonth = months[Int32.Parse(fishAvil.MonthSouth) - 1];
                        if (fishMonth == Month)
                        {
                            fishNum.Add(fishID);
                        }
                    }
                    else if (fishAvil.MonthSouth.Length <= 5)
                    {
                        string[] dateArr = fishAvil.MonthSouth.Split('-');
                        if (Int32.Parse(dateArr[0]) < Int32.Parse(dateArr[1]))
                        {
                            List<string> fishMonths = new List<string>();
                            for (int j = Int32.Parse(dateArr[0]) - 1; j < Int32.Parse(dateArr[1]); j++)
                            {
                                fishMonths.Add(months[j]);
                            }
                            foreach (string m in fishMonths)
                            {
                                if (m == Month)
                                {
                                    fishNum.Add(fishID);
                                }
                            }
                        }
                        else if (Int32.Parse(dateArr[0]) > Int32.Parse(dateArr[1]))
                        {
                            List<string> fishMonths = new List<string>();
                            for (int k = Int32.Parse(dateArr[0]) - 1; k <= 11; k++)
                            {
                                fishMonths.Add(months[k]);
                            }
                            for (int l = 0; l < Int32.Parse(dateArr[1]); l++)
                            {
                                fishMonths.Add(months[l]);
                            }
                            foreach (string n in fishMonths)
                            {
                                if (n == Month)
                                {
                                    fishNum.Add(fishID);
                                }
                            }
                        }
                    }
                    else if (fishAvil.MonthSouth.Length > 5)
                    {
                        string[] multiMonths = fishAvil.MonthSouth.Split(' ');
                        string[] dateArrFirst = multiMonths[0].Split('-');
                        string[] dateArrSecond = multiMonths[2].Split('-');
                        if (Int32.Parse(dateArrFirst[0]) < Int32.Parse(dateArrFirst[1]))
                        {
                            List<string> fishMonths = new List<string>();
                            for (int a = Int32.Parse(dateArrFirst[0]) - 1; a < Int32.Parse(dateArrFirst[1]); a++)
                            {
                                fishMonths.Add(months[a]);
                            }
                            foreach (string t in fishMonths)
                            {
                                if (t == Month)
                                {
                                    fishNum.Add(fishID);
                                }
                            }
                        }
                        else if (Int32.Parse(dateArrFirst[0]) > Int32.Parse(dateArrFirst[1]))
                        {
                            List<string> fishMonths = new List<string>();
                            for (int p = Int32.Parse(dateArrFirst[0]) - 1; p <= 11; p++)
                            {
                                fishMonths.Add(months[p]);
                            }
                            for (int q = 0; q < Int32.Parse(dateArrFirst[1]); q++)
                            {
                                fishMonths.Add(months[q]);
                            }
                            foreach (string h in fishMonths)
                            {
                                if (h == Month)
                                {
                                    fishNum.Add(fishID);
                                }
                            }
                        }
                        if (Int32.Parse(dateArrSecond[0]) < Int32.Parse(dateArrSecond[1]))
                        {
                            List<string> fishMonths = new List<string>();
                            for (int b = Int32.Parse(dateArrSecond[0]) - 1; b < Int32.Parse(dateArrSecond[1]); b++)
                            {
                                fishMonths.Add(months[b]);
                            }
                            foreach (string y in fishMonths)
                            {
                                if (y == Month)
                                {
                                    fishNum.Add(fishID);
                                }
                            }
                        }
                        else if (Int32.Parse(dateArrSecond[0]) > Int32.Parse(dateArrSecond[1]))
                        {
                            List<string> fishMonths = new List<string>();
                            for (int c = Int32.Parse(dateArrSecond[0]) - 1; c <= 11; c++)
                            {
                                fishMonths.Add(months[c]);
                            }
                            for (int d = 0; d < Int32.Parse(dateArrSecond[1]); d++)
                            {
                                fishMonths.Add(months[d]);
                            }
                            foreach (string g in fishMonths)
                            {
                                if (g == Month)
                                {
                                    fishNum.Add(fishID);
                                }
                            }
                        }
                    }
                }
            }

        }

        private async Task PullFish(int fishID)
        {
            var fish = await FishProcessor.LoadFish(fishID);
            fishBlock.Content += $"\n {fish.NameEn.ToUpper()} ";
        }

        private async void GridLoad(object sender, RoutedEventArgs e)
        {

            for (int i = 1; i <= 80; i++)
            {
                await CurrentFish(i);
            }

            foreach (int f in fishNum)
            {
                await PullFish(f);
            }
        }

        private void GoHome(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new HomePage());
        }
    }
}
