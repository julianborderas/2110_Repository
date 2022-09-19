using System;
using Assignment_1.DataAccess;
using Microsoft.Data.SqlClient;


namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateTable();

            var lairds = new Employee()
            {
                ID = "02034",
                Name = "Julian"
            };


        }

        public static void CreateEmployee()
        {
            var lairds = new Employee()
            {
                ID = "02034",
                Name = "Julian"
            };
        }


        public static void CreateTable()
        {
            var readConfig = new ReadConfiguration();
            var connString = readConfig.GetConnectionString(EnvironmentSettings.DBEnvironment);
            Console.WriteLine(connString);

            var sqlConnection = new SqlConnection(connString);

            string sqlStatement = "CREATE TABLE Employee(ID VARCHAR(30) NOT NULL, NAME VARCHAR(50) NOT NULL)";
            SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}

