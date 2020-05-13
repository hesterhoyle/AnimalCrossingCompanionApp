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
    /// Interaction logic for Fish.xaml
    /// </summary>
    public partial class Fish : Page
    {
        public Fish()
        {
            InitializeComponent();
            DateTimeFish.Content = $"The current date and time is {DateTime.Now.ToString()}";
        }

        private void CurrentFish()
        {

        }

        private async Task PullFish(int fishID)
        {
            var fish = await FishProcessor.LoadFish(fishID);
            if (fish.Availability == )
            fishBlock.Text += $"{fish.NameEn.ToUpper()} ";
        }

        private async void GridLoad(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= 80; i++)
            {
                await PullFish(i);
            }
        }
    }
}
