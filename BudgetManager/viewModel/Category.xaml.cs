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
    /// Interaction logic for category.xaml
    /// </summary>
    public partial class Category : Page
    {
        private Model db; // call the model.
        public Category()
        {
            InitializeComponent();
          
        }

        // create a category button when the user clicks create new category. Show it on the dashboard
        public void btnCreateCategory_Click(object sender, RoutedEventArgs e)
        {

            // db.createCategory(txtCategoryName.Text); // insert the category into the database
            budgetOverview dashboard = budgetOverview.CurrentOverviewInstance; // finds current instance of budgetOverview to update

            if (dashboard != null)
            {
                dashboard.addCategoryButton(txtCategoryName.Text); // calls method from budgetOverview.xaml.cs
                dashboard.stckExistingCategoryNav.UpdateLayout();
                MessageBox.Show("success");
            }
            else
            {
                MessageBox.Show("error");
            }
        }

    }
}
