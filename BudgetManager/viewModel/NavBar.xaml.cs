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
    }

}