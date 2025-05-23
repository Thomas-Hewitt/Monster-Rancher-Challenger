﻿using System.Diagnostics;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Monster_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("MonsterSelectorPage.xaml", UriKind.Relative));
        }

        private void Stat_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("StatSelectorPage.xaml", UriKind.Relative));
        }

        private void Level_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("LevelSelectorPage.xaml", UriKind.Relative));
        }

        private void Monster_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = e.Uri.AbsoluteUri,
                UseShellExecute = true
            });
            e.Handled = true;
        }

    }
}