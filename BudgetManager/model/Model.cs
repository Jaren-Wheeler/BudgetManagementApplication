using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace BudgetManager
{
    public class Model
    {
        //private string dbFile = "model/data.db";
        private string dbFile = "C:\\Users\\jaren\\Documents\\School\\CPRO 1121-C#.NET\\BudgetManagerApp\\BudgetManager\\BudgetManager\\model\\data.db";

        // method to create the database
        public void initalizeDatabase()
        {
            // use the connection with the database file
            using (var connection = new SQLiteConnection($"Data Source={dbFile};Version=3"))
            {
                connection.Open();

                // sql command to create the database
                string createDB = @"CREATE TABLE IF NOT EXISTS Budget (
                                    budget_id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    budget_name TEXT NOT NULL
                                    );

                                    CREATE TABLE IF NOT EXISTS Category (
                                    cat_id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    cat_name TEXT NOT NULL,
                                    budget_id INTEGER,
                                    FOREIGN KEY (budget_id) REFERENCES Budget(budget_id)
                                    );

                                    CREATE TABLE IF NOT EXISTS Item (
                                    item_id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    item_name TEXT NOT NULL,
                                    price REAL NOT NULL,
                                    cat_id INTEGER,
                                    FOREIGN KEY (cat_id) REFERENCES Category(cat_id)
                                    );";

                // execute the above string
                using (var command = new SQLiteCommand(createDB, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        //method to inset the budgets
        public void insertBudget(string budgetName)
        {
            using (var connection = new SQLiteConnection($"Data Source={dbFile};Version=3"))
            {
                connection.Open();

                string insert = "INSERT INTO Budget (budget_name) VALUES (@budgetName)"; // sql command to insert into budget table.

                using (var command = new SQLiteCommand(insert, connection))
                {
                    command.Parameters.AddWithValue("@budgetName", budgetName); // add budget name from the inputted budget name parameter
                    command.ExecuteNonQuery();
                }
            }
        }
    }

}
