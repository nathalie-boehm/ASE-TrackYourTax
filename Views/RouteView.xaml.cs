using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TrackYourTax.DataObjects;
using TrackYourTax.Enums;

namespace TrackYourTax.Views
{
    /// <summary>
    /// Interaction logic for RouteView.xaml
    /// </summary>
    public partial class RouteView : UserControl
    {
        public RouteView()
        {
            InitializeComponent();
            McDataGrid.ItemsSource = Repository.Access.Routes;
        }

        
    }
}
