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

namespace BudgetManager.view
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class mainPageView : Window
    {
        public mainPageView()
        {
            InitializeComponent();
        }

        // handles click event of create new budget button
        private void btnNewBudget_Click(object sender, RoutedEventArgs e)
        {
            string newBudgetName = txtNewBudgetName.Text; // user input
            if (newBudgetName == "")
            {
                MessageBox.Show("You must enter a name for your budget.");
            } 
            else
            {

                // hide all existing elements on the page
                lblTitle.Visibility = Visibility.Collapsed;
                lblNewBudget.Visibility = Visibility.Collapsed;
                lblNewBudgetName.Visibility = Visibility.Collapsed;
                txtNewBudgetName.Visibility = Visibility.Collapsed;
                btnNewBudget.Visibility = Visibility.Collapsed;
                lblExistingBudget.Visibility = Visibility.Collapsed;
                txtExistingBudget.Visibility = Visibility.Collapsed;
                btnExistingBudget.Visibility = Visibility.Collapsed;

                frmBudgetOverview.Navigate(new budgetOverview()); // open budgetOverview.xaml page
            }
           
        }

        // handles click event of opening existing budget button
        private void btnExistingBudget_Click(object sender, RoutedEventArgs e)
        {
            string existingBudgetName = txtExistingBudget.Text; //user input
            if (existingBudgetName == "")
            {
                MessageBox.Show("You must enter a budget name.");
            }
        }
    }
}