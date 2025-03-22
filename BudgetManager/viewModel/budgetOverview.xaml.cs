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
            
            NavBarControl.btnHome.Click += btnHome_Click;
            NavBarControl.btnAddInfo.Click += btnAddInfo_Click;
            NavBarControl.btnAddCategory.Click += btnAddCategory_Click;
            NavBarControl.btnSaveAll.Click += btnSaveAll_Click;
            NavBarControl.btnLogOut.Click += btnLogOut_Click;
        }

      
        // home button to go back to budget dashboard
        public void btnHome_Click(object sender, RoutedEventArgs e)
        {
            frmCategory.Navigate(new budgetOverview());
        }

        // opens new form for user to input their net income, budget goals, etc.
        public void btnAddInfo_Click(object sender, RoutedEventArgs e)
        {
            frmInformation.Navigate(new BudgetInfo());
        }

        // Adds a new category, opening the category window
        public void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            frmCategory.Content = null;
            frmCategory.Navigate(new Category());
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


