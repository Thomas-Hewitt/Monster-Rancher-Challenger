using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Monster_Rancher_Challenger
{
    /// <summary>
    /// Interaction logic for StatSelectorPage.xaml
    /// </summary>
    public partial class StatSelectorPage : Page
    {
        List<string> stats = new List<string>{ "Lif (Life)", "Pow (Power)", "Def (Defense)", "Ski (Skill)", "Spd (Speed)", "Int (Intelligence)" };
        List<SolidColorBrush> colors = new List<SolidColorBrush> { new SolidColorBrush(Colors.Yellow), new SolidColorBrush(Colors.Red), new SolidColorBrush(Colors.Blue)
        , new SolidColorBrush(Colors.Purple), new SolidColorBrush(Colors.SkyBlue), new SolidColorBrush(Colors.Green) };
        public StatSelectorPage()
        {
            InitializeComponent();
        }

        private async void Click_Click(object sender, RoutedEventArgs e)
        {
            // Randomly select a monster from the randomized list of monsters (Unnecessary, might just index later).
            Random rng = new Random();
            int randtime = rng.Next(5, 20);
            int index = 0;
            for (int i = 0; i < randtime; i++)
            {
                index = rng.Next(0, stats.Count);
                Stat.Text = stats[index];
                Stat.Foreground = colors[index];
                await Task.Delay(25);
            }
            index = rng.Next(0, stats.Count);
            Stat.Text = stats[index];
            Stat.Foreground = colors[index];
        }
    }
}
