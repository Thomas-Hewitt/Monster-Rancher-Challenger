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
    /// Interaction logic for LevelSelectorPage.xaml
    /// </summary>
    public partial class LevelSelectorPage : Page
    {
        public LevelSelectorPage()
        {
            InitializeComponent();
        }

        private async void Click_Click(object sender, RoutedEventArgs e)
        {
            Random rng = new Random();
            int min = 0;
            int max = 0;
            if (Min.Text != "")
                min = int.Parse(Min.Text);
            if (Max.Text != "")
                max = int.Parse(Max.Text);

            if (min < max && max > 0)
            {
                int randtime = rng.Next(5, 20);
                for (int i = 0; i < randtime; i++)
                {
                    Level.Text = rng.Next(min, max).ToString();
                    await Task.Delay(25);
                }
                Level.Text = rng.Next(min, max).ToString();
            }
            else
            {
                Level.Text = "Invalid bounds";
            }
        }
    }
}
