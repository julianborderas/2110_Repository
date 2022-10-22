using System;
using Assignment_2.DataAccess;
using Microsoft.Data.SqlClient;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CreateTable();
        }

        public static void CreateTable()
        {
            var readConfig = new ReadConfiguration();
            var connString = readConfig.GetConnectionString(EnvironmentSettings.DBEnvironment);
            Console.WriteLine(connString);

            var sqlConnection = new SqlConnection(connString);

            string sqlStatement = "CREATE TABLE Restaurant(ID VARCHAR(30) NOT NULL, NAME VARCHAR(50) NOT NULL, ADDRESS VARCHAR(50) NOT NULL, RATING TINYBIT(6), PHONE VARCHAR(10), EMAIL VARCHAR(50) NOT NULL, ISVEGAN BOOL, ISVEGETARIAN BOOL, ISLICENSED BOOL, CUISINE VARCHAR(50) NOT NULL, AVGCOST FLOAT(50,2), CALENDAR DATETIME(0)";
            SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}

