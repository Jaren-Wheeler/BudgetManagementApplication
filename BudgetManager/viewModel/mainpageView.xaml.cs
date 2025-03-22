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
using BudgetManager.view;

namespace BudgetManager.viewModel
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

        // method to handle events when page loads
        public void mainPageView_Load(object sender, System.EventArgs e)
        {
            // create Model object and create the database
             Model db = new Model();
             db.initalizeDatabase();
        }

        public void hideFrame()
        {
            frmBudgetOverview.Visibility = Visibility.Collapsed;
        }

        // handles click event of create new budget button
        private void btnNewBudget_Click(object sender, RoutedEventArgs e)
        {
            Model db = new Model();

            string newBudgetName = txtNewBudgetName.Text; // user input
            if (newBudgetName == "")
            {
                MessageBox.Show("You must enter a name for your budget.");
            } 
            else if (!db.insertBudget(newBudgetName))
            {
                MessageBox.Show("A budget with that name already exists");
            }
            else
            {
                
                db.insertBudget(newBudgetName); // insert the budget in the database with the user's budget name

                txtNewBudgetName.Text = "";
            }
           
        }

        // handles click event of opening existing budget button
        private void btnExistingBudget_Click(object sender, RoutedEventArgs e)
        {

            Model db = new Model();
            budgetOverview budgetDashboard = new budgetOverview();
            NavBar navBar = new NavBar();

            string existingBudgetName = txtExistingBudget.Text; //user input
            string title = db.retrieveBudget(existingBudgetName); // grab the budget name from the database

            if (existingBudgetName == "")
            {
                MessageBox.Show("You must enter a budget name.");
            }
            else if (title == null)
            {
                MessageBox.Show("The inputted budget doesn't exist.");
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

                frmBudgetOverview.Navigate(budgetDashboard); // open budgetOverview.xaml page

                navBar.displayTitle(title); // display the budget title in the top corner

            }
        }
    }
}