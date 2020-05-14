using AppLibrary;
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

namespace ACCompanionApp
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        List<int> fishNum = new List<int>();
        List<int> bugNum = new List<int>();

        public HomePage()
        {
            InitializeComponent();
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            // gets the player information, announces the name and island name
            string[] playerArr = File.ReadAllLines("player.txt");
            User player = new User(playerArr[0], playerArr[1], playerArr[2]);
            testText.Text = $"Welcome, {player.GetName()}!";

            // navigate buttons customised for the player
            FishBtn.Content = $"Current fish on {player.GetIsland()}";
            BugBtn.Content = $"Current bugs on {player.GetIsland()}";


            // Generating random current fish and bugs for images
            for (int i = 1; i <= 80; i++)
            {
                await FindFish(i);
            }

            for (int j = 1; j <= 80; j++)
            {
                await FindBugs(j);
            }
            //shuffles the list to make images change each time
            var shuffledFish = fishNum.OrderBy(x => Guid.NewGuid()).ToList();

            var uriSource1 = new Uri($"http://acnhapi.com/icons/fish/{shuffledFish[0]}");
            FishImg01.Source = new BitmapImage(uriSource1);

            var uriSource2 = new Uri($"http://acnhapi.com/icons/fish/{shuffledFish[1]}");
            FishImg02.Source = new BitmapImage(uriSource2);

            var uriSource3 = new Uri($"http://acnhapi.com/icons/fish/{shuffledFish[2]}");
            FishImg03.Source = new BitmapImage(uriSource3);


            var shuffledBugs = bugNum.OrderBy(x => Guid.NewGuid()).ToList();

            var uriSource4 = new Uri($"http://acnhapi.com/icons/bugs/{shuffledBugs[0]}");
            BugImg01.Source = new BitmapImage(uriSource4);

            var uriSource5 = new Uri($"http://acnhapi.com/icons/bugs/{shuffledBugs[1]}");
            BugImg02.Source = new BitmapImage(uriSource5);

            var uriSource6 = new Uri($"http://acnhapi.com/icons/bugs/{shuffledBugs[2]}");
            BugImg03.Source = new BitmapImage(uriSource6);


        }

        private void GoFish(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new Fish());
        }

        private void GoBug(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new Bugs());
        }

        // makes a list of current fish 
        private async Task FindFish(int fishID)
        {
            var fishAvil = await FishProcessorAvail.LoadFishAvil(fishID);
            if (fishAvil.AllYear == true)
            {
                fishNum.Add(fishID);
            }
        }

        // makes a list of current bugs
        private async Task FindBugs(int bugID)
        {
            var BugAvil = await BugProcessorAvail.LoadBugAvil(bugID);
            if (BugAvil.AllYear == true)
            {
                bugNum.Add(bugID);
            }
        }

        // loads pictures when page is navigated away from and back to again
        private async void LoadPics(object sender, RequestBringIntoViewEventArgs e)
        {

            for (int i = 1; i <= 80; i++)
            {
                await FindFish(i);
            }

            for (int j = 1; j <= 80; j++)
            {
                await FindBugs(j);
            }

            var shuffledFish = fishNum.OrderBy(x => Guid.NewGuid()).ToList();

            var uriSource1 = new Uri($"http://acnhapi.com/icons/fish/{shuffledFish[0]}");
            FishImg01.Source = new BitmapImage(uriSource1);

            var uriSource2 = new Uri($"http://acnhapi.com/icons/fish/{shuffledFish[1]}");
            FishImg02.Source = new BitmapImage(uriSource2);

            var uriSource3 = new Uri($"http://acnhapi.com/icons/fish/{shuffledFish[2]}");
            FishImg03.Source = new BitmapImage(uriSource3);


            var shuffledBugs = bugNum.OrderBy(x => Guid.NewGuid()).ToList();

            var uriSource4 = new Uri($"http://acnhapi.com/icons/bugs/{shuffledBugs[0]}");
            BugImg01.Source = new BitmapImage(uriSource4);

            var uriSource5 = new Uri($"http://acnhapi.com/icons/bugs/{shuffledBugs[1]}");
            BugImg02.Source = new BitmapImage(uriSource5);

            var uriSource6 = new Uri($"http://acnhapi.com/icons/bugs/{shuffledBugs[2]}");
            BugImg03.Source = new BitmapImage(uriSource6);

        }

        private void GoVillagers(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new Villagers());
        }
    }
}
