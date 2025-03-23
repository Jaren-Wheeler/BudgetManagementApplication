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
    public partial class budgetOverview : Page
    {
        public static budgetOverview CurrentOverviewInstance { get; private set; }
        public budgetOverview()
        {
            InitializeComponent();
            Model db = new Model(); // call the model
            CurrentOverviewInstance = this;

            NavBarControl.btnHome.Click += btnHome_Click;
            NavBarControl.btnAddInfo.Click += btnAddInfo_Click;
            NavBarControl.btnAddCategory.Click += btnAddCategory_Click;
            NavBarControl.btnSaveAll.Click += btnSaveAll_Click;
            NavBarControl.btnLogOut.Click += btnLogOut_Click;
        }


        // home button to go back to budget dashboard
        public void btnHome_Click(object sender, RoutedEventArgs e)
        {
            if (!(frmCategory.Content is budgetOverview))
            {
                frmCategory.Navigate(new budgetOverview());
            }
        }

        // opens new form for user to input their net income, budget goals, etc.
        public void btnAddInfo_Click(object sender, RoutedEventArgs e)
        {
            removeDashboardView(); // remove items from dashboard if navigating from there
            frmCategory.Content = null; // set the content of the category page to null if navigating from there
            frmInformation.Navigate(new BudgetInfo()); // open the information page
        }

        // Adds a new category, opening the category window. Logic same as add info method
        public void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            removeDashboardView();
            frmInformation.Content = null;
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

        // removes elements from the dashboard when a nav bar is clicked.
        public void removeDashboardView()
        {
            lblBudgetInfo.Visibility = Visibility.Collapsed;
            lblCategoryInfo.Visibility = Visibility.Collapsed;
            lblGraphicalInfo.Visibility = Visibility.Collapsed;
            bdBudgetInfo.Visibility = Visibility.Collapsed;
            bdCategoryInfo.Visibility = Visibility.Collapsed;
            bdGraphicalInfo.Visibility = Visibility.Collapsed;
        }


        // dynamically add a button to the category section of the dashboard
        public void addCategoryButton(string categoryName)
        {
            
            Button categoryBtn = new Button
            {
                Content = categoryName,
                Width = 100,
                Height = 40,
                Margin = new Thickness(10)
            };

            stckExistingCategoryNav.Children.Add(categoryBtn); // add the button to the home page

        }
  
    }
}


