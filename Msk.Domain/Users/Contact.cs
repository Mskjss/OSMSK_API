using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Msk.Domain.Users
{
    public class Contact
    {
        [Key]
        public string UserID { get; protected set; }
        public int Cell { get; protected set; }
        public string Email { get; protected set; }
        public string Code { get; protected set; }
        public Contact(string userID,int cell,string email)
        {
            UserID = userID;
            Cell = cell;
            Email = email;
            
            
        }

        public Contact()
        {
        }

        public void SetCode(string code)
        {
             Code = code;
           // Id=id;
        }
    
    }
}
