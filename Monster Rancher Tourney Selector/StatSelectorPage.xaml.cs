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

namespace Monster_Rancher_Tourney_Selector
{
    /// <summary>
    /// Interaction logic for StatSelectorPage.xaml
    /// </summary>
    public partial class StatSelectorPage : Page
    {
        List<string> stats = new List<string>{ "Lif (Life)", "Pow (Power)", "Def (Defense)", "Ski (Skill)", "Spd (Speed)", "Int (Intelligence)" };
        public StatSelectorPage()
        {
            InitializeComponent();
        }

        private void Click_Click(object sender, RoutedEventArgs e)
        {
            // Randomly select a monster from the randomized list of monsters (Unnecessary, might just index later).
            Random rng = new Random();
            Stat.Text = stats[rng.Next(0, stats.Count)];
        }
    }
}
