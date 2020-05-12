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
using System.Windows.Shapes;
using AppLibrary;

namespace ACCompanionApp
{
    /// <summary>
    /// Interaction logic for VillagerViewer.xaml
    /// </summary>
    public partial class VillagerViewer : Window
    {
        public VillagerViewer()
        {
            InitializeComponent();
        }

        private async Task PullVillager(int villagerID)
        {
            var villager = await VillagerProcessor.LoadVillager(villagerID);
            txtBlock.Text = $"{villager.NameEn}";

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await PullVillager(1);
        }
    }
}
