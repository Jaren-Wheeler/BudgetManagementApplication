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
using System.Reflection.Metadata.Ecma335;

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

        //method to insert the budgets
        public bool insertBudget(string budgetName)
        {
            using (var connection = new SQLiteConnection($"Data Source={dbFile};Version=3"))
            {
                connection.Open();

                string rowCount = "SELECT COUNT(*) FROM Budget WHERE budget_name = @budgetName"; // counts rows matching query to see if budget name exists
                using (var command = new SQLiteCommand(rowCount, connection))
                {
                    command.Parameters.AddWithValue("@budgetName", budgetName);
                    long count = (long)command.ExecuteScalar();

                    if (count == 0)
                    {
                        string insert = "INSERT INTO Budget (budget_name) VALUES (@budgetName)"; // sql command to insert into budget table.
                        using (var insCommand = new SQLiteCommand(insert, connection))
                        {
                            insCommand.Parameters.AddWithValue("@budgetName", budgetName); // add budget name from the inputted budget name parameter
                            insCommand.ExecuteNonQuery();
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        // method to retrieve existing budget
        public string retrieveBudget(string input)
        {
            string budgetName = null; // initialize budget name

            using (var connection = new SQLiteConnection($"Data Source={dbFile};Version=3"))
            {
                connection.Open();
                string rowCount = "SELECT COUNT(*) FROM Budget WHERE budget_name = @input"; // counts the number of rows matching the budget_name

                using (var command = new SQLiteCommand(rowCount, connection))
                {
                    command.Parameters.AddWithValue("@input", input);
                    long count = (long)command.ExecuteScalar(); // returns count of rows that match the retrieve query

                    // checks if count is > 0 (i.e. that the budget exists). If yes, it queries for the budgetName, otherwise it returns the budget name as null
                    if (count > 0)
                    {
                        string retrieve = "SELECT budget_name FROM Budget WHERE budget_name = @input"; // query for the budget name
                        using (var retrieveCommand = new SQLiteCommand(retrieve,connection))
                        {
                            retrieveCommand.Parameters.AddWithValue("@input", input);
                            budgetName = (string)retrieveCommand.ExecuteScalar(); // retrieve a single budget from database and store as a string
                        }
                    } 
                    else
                    {
                        budgetName = null;
                    }
                   
                }
            }
            return budgetName;
        }

        // input budget info to the database
        public void inputInfo()
        {

        }


        // create a category
        public void createCategory(string categoryName)
        {
            using (var connection = new SQLiteConnection($"Data Source={dbFile};Version=3"))
            {
                connection.Open();
                string insertCategory = "INSERT INTO Category (cat_name) VALUES (@categoryName)"; // query for inserting a category
            }
        }

        // retrieve info about a category from the database
        public void retrieveCategory()
        {

        }

        // input a new item into the database
        public void createItem()
        {
            
        }

        // retrieve info about an item from the database
        public void retrieveItem()
        {

        }
    }

}
