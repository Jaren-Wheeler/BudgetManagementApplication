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

namespace BudgetManager.view
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

        public void displayTitle(string title)
        {
            Model db = new Model();
            string budgetTitle = (string)db.retrieveBudget(title);
            lblBudgetTitle.Content = budgetTitle;

        }
    }
}
