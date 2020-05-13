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
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class NewUser : Page
    {
        public NewUser()
        {
            InitializeComponent();
        }

        private void SubmitUser(object sender, RoutedEventArgs e)
        {
            if (NorthernChk.IsChecked == true)
            {
                var player = new User(userName.Text, islandName.Text, "North");
                string[] playerInfo = { player.GetName(), player.GetIsland(), "North" };
                File.WriteAllLines("player.txt", playerInfo);
                _NavigationFrame.Navigate(new HomePage());
            }
            else if (SouthernChk.IsChecked == true)
            {
                var player = new User(userName.Text, islandName.Text, "South");
                string[] playerInfo = { player.GetName(), player.GetIsland(), "South" };
                File.WriteAllLines("player.txt", playerInfo);
                _NavigationFrame.Navigate(new HomePage());
            }           
        }
    }
}
