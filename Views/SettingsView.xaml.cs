using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TrackYourTax.DataObjects;
using TrackYourTax.Enums;

namespace TrackYourTax.Views
{  
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
            McDataGrid.ItemsSource = Repository.Access.Settings;


        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = (Settings)McDataGrid.SelectedItem;
            Repository.Access.Settings.Remove(settings);
            McDataGrid.Items.Refresh();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            Repository.Access.Settings.Add(new Settings()
            {
                Year=2020,
                KilometerPrice = 30,
                CateringAdditionalExpenses = 14,
                CommercialFlatCharge = 1000,
            });
            McDataGrid.Items.Refresh();

        }
    }
}
