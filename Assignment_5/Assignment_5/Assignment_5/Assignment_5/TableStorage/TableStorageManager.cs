using System;
using Azure.Data.Tables;
using System.Collections.Generic;
using System.Text;

namespace Assignment_5.TableStorage
{
    public class TableStorageManager
    {
        private static string connectionString = "DefaultEndpointsProtocol=https;AccountName=storage091622;AccountKey=b1wvHMgkM3aU/3a51EcxAU3K1ptimD5od5lSpZdLrr0cG0eAByySpkKVyJtSlECbr1Sgeh20KVhb+AStz/XXgg==;EndpointSuffix=core.windows.net";
    
	    public void Add(Restaurant restaurant) {

            var tableServiceClient= new TableServiceClient(TableStorageManager.connectionString);
            var tableClient = tableServiceClient.GetTableClient(tableName: "Restaurants");
            var res = tableClient.AddEntity<Restaurant>(restaurant);
	    }
	   
	    public Restaurant Get(string restaurantID, string nameID) {
            var tableServiceClient = new TableServiceClient(TableStorageManager.connectionString);
            var tableClient = tableServiceClient.GetTableClient(tableName: "Restaurants");
            var restaurantAccount = tableClient.GetEntity<Restaurant>(
            partitionKey:restaurantID,
            rowKey: nameID
		    );

            return restaurantAccount;
	    } 

        public IEnumerable<Restaurant> Query(string restaurantID) {
            var tableServiceClient = new TableServiceClient(TableStorageManager.connectionString);
            var tableClient = tableServiceClient.GetTableClient(tableName: "Restaurants");

            var restaurantAccounts = tableClient.Query<Restaurant>(x => x.PartitionKey == restaurantID);

            return restaurantAccounts;

        }
    }
}


