using System;
using System.Collections.Generic;
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
    /// Interaction logic for Villagers.xaml
    /// </summary>
    public partial class Villagers : Page
    {
        int SearchedVillager = 0;
        

        public Villagers()
        {
            InitializeComponent();
        }

        private async void SearchVillager(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= 391; i++)
            {
                await PullVillager(i);
            }
            if (SearchedVillager == 0)
            {
                ErrorMessage.Text = "Error: No Villager Found";
            }
            else if (SearchedVillager > 0)
            {
                var villager = await VillagerProcessor.LoadVillager(SearchedVillager);
                ErrorMessage.Text = " ";
                var uriSource0 = new Uri($"http://acnhapi.com/images/villagers/{SearchedVillager}");
                Vill00.Source = new BitmapImage(uriSource0);
                VillagerInfo.Text = $"Name: {villager.NameEn}\nPersonality: {villager.Personality}";
            }
        }

        private async Task PullVillager(int villagerID)
        {
            var villager = await VillagerProcessor.LoadVillager(villagerID);
            if (villager.NameEn.ToUpper() == SearchBar.Text.ToUpper())
            {
                SearchedVillager = villagerID;
            }
        }

        private void GoHome(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new HomePage());
        }

        private async void GridLoaded(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            int r0 = r.Next(392);
            int r1 = r.Next(392);
            int r2 = r.Next(392);
            int r3 = r.Next(392);

            var uriSource1 = new Uri($"http://acnhapi.com/images/villagers/{r0}");
            rVillager0.Source = new BitmapImage(uriSource1);
            var villager1 = await VillagerProcessor.LoadVillager(r0);
            rName0.Text = $"{villager1.NameEn}";

            var uriSource2 = new Uri($"http://acnhapi.com/images/villagers/{r1}");
            rVillager1.Source = new BitmapImage(uriSource2);
            var villager2 = await VillagerProcessor.LoadVillager(r1);
            rName1.Text = $"{villager2.NameEn}";

            var uriSource3 = new Uri($"http://acnhapi.com/images/villagers/{r2}");
            rVillager2.Source = new BitmapImage(uriSource3);
            var villager3 = await VillagerProcessor.LoadVillager(r2);
            rName2.Text = $"{villager3.NameEn}";

            var uriSource4 = new Uri($"http://acnhapi.com/images/villagers/{r3}");
            rVillager3.Source = new BitmapImage(uriSource4);
            var villager4 = await VillagerProcessor.LoadVillager(r3);
            rName3.Text = $"{villager4.NameEn}";
        }
    }
}
