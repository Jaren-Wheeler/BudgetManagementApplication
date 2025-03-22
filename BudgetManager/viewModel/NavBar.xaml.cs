using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BudgetManager.viewModel;

namespace BudgetManager.view
{
    /// <summary>
    /// Interaction logic for NavBar.xaml
    /// </summary>
    public partial class NavBar : UserControl
    {
        public NavBar()
        {
            InitializeComponent();
        }

        // display the title of the budget inputted by the user
        public void displayTitle(string title)
        {
            Model db = new Model(); // model object
            string budgetTitle = (string)db.retrieveBudget(title); // retrieve the title from the retrieveBudget method in the model class
            lblBudgetTitle.Content = budgetTitle;
        }

        // home button to go back to budget dashboard
        public void btnHome_Click(object sender, RoutedEventArgs e)
        {
            //frmCategory.Navigate(new budgetOverview());
        }

        // opens new form for user to input their net income, budget goals, etc.
        public void btnAddInfo_Click(object sender, RoutedEventArgs e)
        {
            //frmInformation.Navigate(new BudgetInfo());
        }

        // Adds a new category, opening the category window
        public void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            //frmCategory.Content = null;
           // frmCategory.Navigate(new Category());
        }

        // Saves all changes
        public void btnSaveAll_Click(object sender, RoutedEventArgs e)
        {

        }

        // Logs user out of their budget and returns to home page
        public void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Are you sure you want to log out?", "Attention", MessageBoxButton.YesNo);
        }
    }
}

