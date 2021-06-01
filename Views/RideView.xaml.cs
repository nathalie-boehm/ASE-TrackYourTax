using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TrackYourTax.DataObjects;
using TrackYourTax.Enums;

namespace TrackYourTax.Views
{
    /// <summary>
    /// Interaction logic for RideView.xaml
    /// </summary>
    public partial class RideView : UserControl
    {
        public RideView()
        {
            InitializeComponent();
            McDataGrid.ItemsSource = Repository.Access.Rides;


        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Ride ride = (Ride)McDataGrid.SelectedItem;
            Repository.Access.Rides.Remove(ride);
            McDataGrid.Items.Refresh();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            Repository.Access.Rides.Add(new Ride(){Start = DateTime.Now, End = DateTime.Now});
            McDataGrid.Items.Refresh();

        }

        private void StartStop_Click(object sender, RoutedEventArgs e)
        {
            if (StartStop.Content.Equals("Start"))
            {
                StartStop.Content = "Stop";
                Repository.Access.Rides.Add(new Ride(){Start=DateTime.Now, AttendanceCounter = 1, AbsenceCounter = 0});
                McDataGrid.Items.Refresh();
                return;
            }
            Repository.Access.Rides.Sort();
            var ride = Repository.Access.Rides[0];
            ride.End=DateTime.Now;
            StartStop.Content = "Start";
            McDataGrid.Items.Refresh();
        }
    }
}
