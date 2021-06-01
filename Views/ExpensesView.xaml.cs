using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TrackYourTax.DataObjects;
using TrackYourTax.Enums;

namespace TrackYourTax.Views
{
    /// <summary>
    /// Interaction logic for ExpensesView.xaml
    /// </summary>
    public partial class ExpensesView : UserControl
    {
        public ExpensesView()
        {
            InitializeComponent();
            McDataGrid.ItemsSource = Repository.Access.Expenses;


        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Expenses expenses = (Expenses)McDataGrid.SelectedItem;
            Repository.Access.Expenses.Remove(expenses);
            McDataGrid.Items.Refresh();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            Repository.Access.Expenses.Add(new Expenses(){Comment="Studiengebühren", Amount=300, Date = DateTime.Now, Category = ExpensesCategory.WerbungskostenSonstige});
            McDataGrid.Items.Refresh();

        }

    }
}
