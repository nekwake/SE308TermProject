﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SE308TermProject
{
    internal class TypeBUser
    {
        private string connectionString;

        public TypeBUser(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void RunTransactions(int numberOfTransactions)
        {
            for (int i = 0; i < numberOfTransactions; i++)
            {
                DateTime beginTime = DateTime.Now;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SetTransactionIsolationLevel(connection);
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        Random rand = new Random();
                        for (int j = 0; j < 5; j++) // 5 select process
                        {
                            if (rand.NextDouble() < 0.5)
                            {
                                string beginDate = "20110101";
                                string endDate = "20151231";
                                RunSelectQuery(connection, transaction, beginDate, endDate);
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }

                DateTime endTime = DateTime.Now;
                TimeSpan elapsedTime = endTime - beginTime;
                Console.WriteLine("Elapsed time for transaction {0}: {1} milliseconds", i + 1, elapsedTime.TotalMilliseconds);
            }
        }

        private void SetTransactionIsolationLevel(SqlConnection connection)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE";
            command.ExecuteNonQuery();
        }

        private void RunSelectQuery(SqlConnection connection, SqlTransaction transaction, string beginDate, string endDate)
        {
            string selectQuery = "SELECT SUM(Sales.SalesOrderDetail.OrderQty) " +
                                 "FROM Sales.SalesOrderDetail " +
                                 "WHERE UnitPrice > 100 " +
                                 "AND EXISTS (SELECT * FROM Sales.SalesOrderHeader " +
                                 "WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID " +
                                 "AND Sales.SalesOrderHeader.OrderDate BETWEEN @BeginDate AND @EndDate " +
                                 "AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";

            SqlCommand command = new SqlCommand(selectQuery, connection, transaction);
            command.Parameters.AddWithValue("@BeginDate", beginDate);
            command.Parameters.AddWithValue("@EndDate", endDate);

            command.ExecuteNonQuery();
        }
    }
}

