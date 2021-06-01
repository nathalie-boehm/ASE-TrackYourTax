using System.Windows.Controls;
using TrackYourTax.BusinessLogicDomain;

namespace TrackYourTax.Views
{
    /// <summary>
    /// Interaction logic for TrackingView.xaml
    /// </summary>
    public partial class ElsterView : UserControl
    {
        public ElsterView()
        {
            InitializeComponent();
        }

        private void ElsterInput_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var builder = new ElsterInputBuilder();
            var director = new ElsterInputDirector(builder);
            director.ConstructElsterInput();
            builder.Build();
        }
    }
}
