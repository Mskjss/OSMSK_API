using Msk.Domain.Token;
using Msk.Domain.Users;

namespace Msk.Data.Contracts.Users
{
    public interface IUsersRepository
    {
		Task<bool> IsValidUserAsync(string name);

		UserRefreshTokens AddUserRefreshTokens(UserRefreshTokens user);
		User AddUser(User user);
		Adress AddAdress(Adress adress);
		Contact AddContact(Contact contact);
		UserRefreshTokens GetSavedRefreshTokens(string username, string refreshtoken);

		void DeleteUserRefreshTokens(string username, string refreshToken);

		int SaveCommit();
	}
}
 