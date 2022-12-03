using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msk.Domain.Users
{
    public class TypeAccount
    {
        public User UserID { get; set; }
        public TypeUser Name { get; set; }

    }

    public enum TypeUser
    {
        Visitor,//viditante
        Common,//usuario comum
        UserCompany, //fornecedor cpf
        Company,//fornecedor cnpj
        Delivery // tipo entrega

    }
}
