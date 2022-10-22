using System;
namespace Assignment_2.DataAccess
{

    public class Restaurant
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Rating { get; set; }
        public string URL { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public bool isVegan { get; set; }
        public bool isVegetarian { get; set; }
        public bool isLicensed { get; set; }
        public string Cuisine { get; set; }
        public int AvgCost { get; set; }
        public string[] Calendar { get; set; }
    }

    
}

