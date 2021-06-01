using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TrackYourTax.DataObjects;
using TrackYourTax.Enums;

namespace TrackYourTax.Views
{
    /// <summary>
    /// Interaction logic for LocationView.xaml
    /// </summary>
    public partial class LocationView : UserControl
    {
        public LocationView()
        {
            InitializeComponent();
            McDataGrid.ItemsSource = Repository.Access.Locations;


        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Location location = (Location)McDataGrid.SelectedItem;
            Repository.Access.Locations.Remove(location);
            McDataGrid.Items.Refresh();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            Repository.Access.Locations.Add(new Location()
            {
                Name = "Add Name",
                LocationCategory = LocationCategory.ErsteTaetigkeitsstaette,
            });
            McDataGrid.Items.Refresh();

        }
    }
}
