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

namespace BudgetManager.viewModel
{
    /// <summary>
    /// Interaction logic for budgetOverview.xaml
    /// </summary>
    public partial class budgetOverview : Page
    {
        public budgetOverview()
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

        // opens new form for user to input their net income, budget goals, etc.
        public void btnAddInfo_Click(object sender, RoutedEventArgs e)
        {
           
        }

        // Adds a new category, opening the category window
        public void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {

        }

        // Saves all changes
        public void btnSaveAll_Click(object sender, RoutedEventArgs e)
        {

        }

        // Logs user out of their budget
        public void btnLogOut_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
