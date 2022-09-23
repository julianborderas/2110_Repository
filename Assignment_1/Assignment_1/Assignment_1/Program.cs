using System;
using Assignment_1.DataAccess;
using Microsoft.Data.SqlClient;


namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateTable();

            var lairds = new Employee()
            {
                ID = "02034",
                Name = "Julian"
            };

            //Program.Add(lairds);

            //Program.Get(lairds);

            Program.Delete(lairds);


        }

        
        public static void Get(Employee employee)
        {
            var readConfig = new ReadConfiguration();
            var connString = readConfig.GetConnectionString(EnvironmentSettings.DBEnvironment);
            Console.WriteLine(connString); 
	    
	        SqlConnection sqlConnection = new SqlConnection(connString);

            string sqlStatement = String.Format("SELECT NAME from dbo.Employee WHERE ID = 02034");
            SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();

            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}", reader["NAME"]));
                }
            }
            sqlConnection.Close();

        }

        public static void Delete(Employee employee)
        {
            var readConfig = new ReadConfiguration();
            var connString = readConfig.GetConnectionString(EnvironmentSettings.DBEnvironment);
            Console.WriteLine(connString);

            SqlConnection sqlConnection = new SqlConnection(connString);

            string sqlStatement = String.Format("DELETE from dbo.Employee WHERE ID = 02034");
            SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }

        public static void Add(Employee employee)
        {
            var readConfig = new ReadConfiguration();
            var connString = readConfig.GetConnectionString(EnvironmentSettings.DBEnvironment);
            Console.WriteLine(connString);

            SqlConnection sqlConnection = new SqlConnection(connString);

            string sqlStatement = String.Format("INSERT into dbo.Employee VALUES('{0}','{1}');", employee.ID, employee.Name);
            SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

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

