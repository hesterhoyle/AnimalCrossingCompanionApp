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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            APIHelper.InitializeClient();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists("player.txt"))
            {
                string[] playerArr = File.ReadAllLines("player.txt");
                User player = new User(playerArr[0], playerArr[1], playerArr[2]);
                PrevUserBtn.Content = $"User: {player.GetName()}";
            }
            else
            {
                PrevUserBtn.Visibility = Visibility.Hidden;
                DelUserBtn.Visibility = Visibility.Hidden;
            }
        }

        private void OpenNewUserPage(object sender, RoutedEventArgs e)
        {

            _NavigationFrame.Navigate(new NewUser());

        }

        private void PrevUser(object sender, RoutedEventArgs e)
        {
            if (File.Exists("player.txt"))
            {
                _NavigationFrame.Navigate(new HomePage());
            }
            else
            {
                PrevUserBtn.Visibility = Visibility.Hidden;
                DelUserBtn.Visibility = Visibility.Hidden;
            }
            
        }

        private void DelUser(object sender, RoutedEventArgs e)
        {
            File.Delete("player.txt");
            PrevUserBtn.Visibility = Visibility.Hidden;
            DelUserBtn.Visibility = Visibility.Hidden;
        }
    }
}
