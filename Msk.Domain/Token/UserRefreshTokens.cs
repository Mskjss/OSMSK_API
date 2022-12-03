using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msk.Domain.Token
{
    public class UserRefreshTokens
    {
		
		public string Id { get; protected set; }
		public string UserName { get;protected set; }
		public string RefreshToken { get;protected set; }
		public bool IsActive { get;protected set; } = true;

		public void SetRefreshToken(string id,string username,string refreshtoken) {

			Id = id;
			UserName = username;
			RefreshToken=refreshtoken;
		}
	}
}
