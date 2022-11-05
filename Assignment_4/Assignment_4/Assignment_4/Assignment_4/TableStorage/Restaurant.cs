using System;
using System.Collections.Generic;
using Azure;
using Azure.Data.Tables;
using static Assignment_4.TableStorage.AddressClass;

namespace Assignment_4.TableStorage
{
    public class Restaurant : ITableEntity
    {


        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; } = default;
        public ETag ETag { get; set; } = default;
        public string StreetName { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set;}
        public string ID { get; set; }
        public string Name { get; set; }
        public Decimal Rating { get; set; }
        public string URL { get; set; }
        public string  Phone { get; set; }
        public string Email { get; set; }
        public bool isVegan { get; set; }
        public bool isVegetarian { get; set; }
        public bool isLicensed { get; set; }
        public string Cuisine { get; set; }
        public Double  AvgCost { get; set; }
        public string Calendar { get; set; }
    }
}


