using Msk.Domain.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msk.Domain.Shared
{
    public class Response:Tokens
    {
        public string user { get; set; }
      //  public string password{ get; set; }
        public int cod { get; set; }
    }
}
