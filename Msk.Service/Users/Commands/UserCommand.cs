using MediatR;
using Msk.Domain.Shared;
using Msk.Domain.Token;
using Msk.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Msk.Domain.Users.Adress;

namespace Msk.Service.Users.Commands
{
    public class UserCreateCommand : IRequest<Response>
    {
        public string Name { get; set; }
        public string Password { get;  set; }
        public UserCreateAdressCommand? Adress { get; set; }
        public UserCreateContactCommand Contact { get; set; }

        public static implicit operator User(UserCreateCommand dto)
           => new User(dto.Name,dto.Password);
    }

    public class UserCreateAdressCommand : IRequest<Response>
    {

        public int Postcode { get;  set; }
        public string City { get;  set; }
        public string District { get;  set; }
        public string PublicPlace { get;  set; }
        public int Number { get;  set; }
        public string? Complement { get;  set; }
        public string State { get;  set; }
        public string Country { get;  set; }
        public string? ReferencPoint { get;  set; }
     //   public string UserID { get;  set; }

    }
    public class UserCreateContactCommand : IRequest<Response> {
    
        public int Cell { get;  set; }
        public string Email { get;  set; }
       

    }
    public class UserUpdateCommand : IRequest<Response>
    {

    }
    public class UserDeleteCommand : IRequest<Response>
    {

    }
}
