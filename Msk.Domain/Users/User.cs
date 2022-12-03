
using Msk.Domain.Token;


namespace Msk.Domain.Users
{
    public class User
    {
        //private readonly List<Contact>? listContacts;
        public User()
        {
           
        }
        public string Id { get;protected set; }
        public string Name { get; protected set; }
        public DateTime Created { get; protected set; }
        public string Password { get; protected set; }
      
        //public List<Contact>? Contacts => listContacts;
        public User(string name, string password)
        {
            //listContacts = new();


            Id = Guid.NewGuid().ToString().ToUpper();
            Name = name;        
            Created = DateTime.Today;          
            Password = password;
            
        }
 

     


    }
 
}
