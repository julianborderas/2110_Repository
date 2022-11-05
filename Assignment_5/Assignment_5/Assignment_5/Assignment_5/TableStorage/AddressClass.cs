using System;
using System.Diagnostics.CodeAnalysis;

namespace Assignment_5.TableStorage
{
    public class AddressClass : IEquatable<AddressClass>
    {
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public AddressClass(string StreetNumber, string City, string PostalCode) 
	    {
            this.StreetNumber = StreetNumber;
            this.City = City;
            this.PostalCode = PostalCode;
        }

        public bool Equals([AllowNull] AddressClass other)
        {
            throw new NotImplementedException();
        }
    }
}


