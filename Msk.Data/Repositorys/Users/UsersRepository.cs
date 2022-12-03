using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Msk.Data.Context;
using Msk.Data.Contracts.Users;
using Msk.Domain.Token;
using Msk.Domain.Users;


namespace Msk.Data.Repositorys.Users
{
    public class UsersRepository : IUsersRepository
    {
       private readonly PostgreContext _postegrecontext;
      

        public UsersRepository(PostgreContext postegrecontext)
        {
            _postegrecontext = postegrecontext;
        }
        public UserRefreshTokens AddUserRefreshTokens(UserRefreshTokens user)
        {
            _postegrecontext.userrefreshtokens.AddAsync(user);
           _postegrecontext.SaveChanges();
            return user;
        }
        public  User AddUser(User user)
        {
            _postegrecontext.user.AddAsync(user);
           _postegrecontext.SaveChanges();
            return user;
        }

        public  Adress AddAdress(Adress adress)
        {
            _postegrecontext.adress.AddAsync(adress);
            _postegrecontext.SaveChanges();
            return adress;
           
        }
        public  Contact AddContact(Contact contact)
        {
            _postegrecontext.contact.AddAsync(contact);
            _postegrecontext.SaveChanges();
            return contact;
        }
        public void DeleteUserRefreshTokens(string username, string refreshToken)
        {
            var item = _postegrecontext.userrefreshtokens.FirstOrDefault(x => x.UserName == username && x.RefreshToken == refreshToken);
            if (item != null)
            {                
                _postegrecontext.userrefreshtokens.Remove(item);
            }
        }
        public UserRefreshTokens GetSavedRefreshTokens(string username, string refreshtoken)
        {
            return _postegrecontext.userrefreshtokens.FirstOrDefault(x => x.UserName == username && x.RefreshToken == refreshtoken && x.IsActive == true);
        }
        public async Task<bool> IsValidUserAsync(string name)
        {
            return _postegrecontext.user.Where(x => x.Name.Equals(name)).IgnoreQueryFilters().Count() > 0;
        }
        public int SaveCommit()
        {
            return _postegrecontext.SaveChanges();
        }

    }
}
