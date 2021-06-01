using System.Windows.Controls;
using TrackYourTax.BusinessLogicUseCase;

namespace TrackYourTax.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private ExpenseObservation _observer = new ExpenseObservation();
        public HomeView()
        {
            InitializeComponent();
            SetCommercialProgressBar();
        }

        protected void SetCommercialProgressBar()
        {
            CommercialProgress.Value = _observer.GetCommercialCostProgress();
        }
    }
}
