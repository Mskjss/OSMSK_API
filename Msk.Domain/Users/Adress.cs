using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msk.Domain.Users
{
    public class Adress
    {
        [Key]
        public string UserID { get; protected set; }
        public int Postcode { get; protected set; }
        public string City { get; protected set; }
        public string District { get; protected set; }
        //logradouro
        public string PublicPlace { get; protected set; }
        public int Number { get; protected set; }
        public string? Complement { get; protected set; }
        public string State { get; protected set; }
        public string Country { get; protected set; }
        public string? ReferencPoint { get; protected set; }
       
        public Adress(int postcode, string city, string district, string publicPlace, int number, string? complement, string state, string country, string? referencPoint, string userID)
        {
            Postcode = postcode;
            City = city;
            District = district;
            PublicPlace = publicPlace;
            Number = number;
            Complement = complement;
            State = state;
            Country = country;
            ReferencPoint = referencPoint;          
            UserID = userID;
        }
    }
}
