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
        public HomePage()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            string[] playerArr = File.ReadAllLines("player.txt");
            User player = new User(playerArr[0], playerArr[1], playerArr[2]);
            testText.Text = $"Welcome, {player.GetName()}!";

            ResiBtn.Text = $"Residents of {player.GetIsland()}";
        }



        private void ReturnHome(object sender, RoutedEventArgs e)
        {
            //this.Close();
        }

        private void GoFish(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new Fish());
        }
    }
}
