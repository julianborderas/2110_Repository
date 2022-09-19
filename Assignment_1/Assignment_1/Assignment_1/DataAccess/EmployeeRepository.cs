using System;
using System.Collections.Generic;
using System.Text;
using Azure;
using Microsoft.Data.SqlClient;


namespace Assignment_1.DataAccess
{
    public class EmployeeRepository
    {
        private readonly IReadConfiguration readConfiguration;

        public EmployeeRepository(IReadConfiguration readConfiguration)
        {
            this.readConfiguration = readConfiguration;
        }

        /// <summary>
        /// Assignment 1
        /// </summary>
        /// <param name="employee"></param>
        public void Add(Employee employee)
        {

            SqlConnection sqlConnection = new SqlConnection();

            string sqlStatement = String.Format("INSERT into dbo.Employee VALUES('{0}','{1}');", employee.ID, employee.Name);
            SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }

        /// <summary>
        /// Assignment 1
        /// </summary>
        /// <param name="employee"></param>
        public void Delete(Employee employee)
        {
            SqlConnection sqlConnection = new SqlConnection();

            string sqlStatement = String.Format("DELETE from dbo.Employee WHERE ID = @ID");
            SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }

        /// <summary>
        /// Assignment 1
        /// </summary>
        /// <param name="employee"></param>
        public void Get(string idFilter)
        {
            SqlConnection sqlConnection = new SqlConnection();

            string sqlStatement = String.Format("SELECT NAME from dbo.Employee WHERE ID = @ID");
            SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }

        private SqlConnection GetConnection()
        {
            var connString = readConfiguration.GetConnectionString(EnvironmentSettings.DBEnvironment);
            if (string.IsNullOrWhiteSpace(connString))
            {
                throw new Exception("Database Connection string not found");
            }

            var connection = new SqlConnection(connString);

            return connection;
        }
    }
}
