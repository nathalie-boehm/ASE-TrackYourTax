using System.Windows;

namespace TrackYourTax
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            new DataExamples().FillRepository();
        }
    }
}
