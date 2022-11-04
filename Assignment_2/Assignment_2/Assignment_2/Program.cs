using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Assignment_2.DataAccess;
using Assignment_2.TableStorage;
using Microsoft.Data.SqlClient;
public class AddressClass { };

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //new Program().AddRestaurant();
            //new Program().GetRestaurant();
            new Program().Query();
        }


       

        public void AddRestaurant() {


            var restaurant = new Restaurant()
            {
                PartitionKey = "C001",
                RowKey = "1234567890",
                ID = "0001",
                Name = "Restaurante Delicioso",
                StreetName = "5645 Imperial Street",
                City = "Vancouver",
                PostalCode = "V5S 2T4",
                Rating = 5,
                URL = "www.restaurantedelicioso.com",
                Phone = "604-987-3425",
                Email = "restaurante@delicioso.com",
                isVegan = true,
                isVegetarian = true,
                isLicensed = true,
                Cuisine = "Mexican",
                AvgCost = 25.76,
                Calendar = "Monday - Friday = 8:00AM to 10:30PM"
            };

            new TableStorageManager().Add(restaurant);
	    }

        public void GetRestaurant() {
            new TableStorageManager().Get(
                "C001",
                "1234567890");
	    }

        public void Query() {

            var restaurants = new TableStorageManager().Query("C001");

            foreach (var account in restaurants) {
                Console.WriteLine(string.Format("{0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}-{8}-{9}-{10}-{11}-{12}-{13}-{14}-{15}-{16}", account.PartitionKey, account.RowKey, account.StreetName, account.City, account.PostalCode, account.ID, account.Name, account.Rating, account.URL, account.Phone, account.Email, account.isVegan, account.isVegetarian, account.isLicensed, account.Cuisine, account.AvgCost, account.Calendar));
	        }
	        
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

