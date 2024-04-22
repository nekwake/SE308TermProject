using SE308TermProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SE308TermProject
{
    public partial class Form1 : Form
    {
        private TypeAUser typeAUser;
        private TypeBUser typeBUser;

        public Form1()
        {
            InitializeComponent();
            // Create TypeAUser and TypeBUser objects
            typeAUser = new TypeAUser("Data Source=DESKTOP-J084HA2\\SQLEXPRESS;Initial Catalog=AdventureWorks2012;Integrated Security=True");
            typeBUser = new TypeBUser("Data Source=DESKTOP-J084HA2\\SQLEXPRESS;Initial Catalog=AdventureWorks2012;Integrated Security=True");
        }

        private void btnRunSimulation_Click(object sender, EventArgs e)
        {
            // Start the simulation
            int numberOfTypeAUsers = Convert.ToInt32(numTypeAUsers.Value);
            int numberOfTypeBUsers = Convert.ToInt32(numTypeBUsers.Value);

            // Start Type A user's processes
            for (int i = 0; i < numberOfTypeAUsers; i++)
            {
                // Start Type A user's processes asynchronously
                RunTypeAUserTransactionsAsync();
            }

            // Start Type B user's processes
            for (int i = 0; i < numberOfTypeBUsers; i++)
            {
                // Start Type B user's processes asynchronously
                RunTypeBUserTransactionsAsync();
            }
        }

        private async void RunTypeAUserTransactionsAsync()
        {
            // Start Type A user's processes asynchronously
            await Task.Run(() =>
            {
                typeAUser.RunTransactions(10); // 100 process for each user şimdilik 10
            });
        }

        private async void RunTypeBUserTransactionsAsync()
        {
            // Start Type B user's processes asynchronously
            await Task.Run(() =>
            {
                typeBUser.RunTransactions(10); // 100 process for each user şimdilik 10
            });
        }
    }
}


