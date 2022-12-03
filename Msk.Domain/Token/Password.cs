using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSystem.Security.Cryptography;

namespace Msk.Domain.Token
{
    [Keyless]
    public class Password
    {
        public string Encoded { get; }

        public Password(string password)
        {
            Encoded = EncodePassword(password);
        }

        public Password()
        {
        }

        public static implicit operator Password(string password) => new Password(password);

        public  string EncodePassword(string password)
        {
            string result;
            var bytes = Encoding.Unicode.GetBytes(password);

            using (var stream = new MemoryStream())
            {
                stream.WriteByte(0);

                using (var sha256 = new SHA256Managed())
                {
                    var hash = sha256.ComputeHash(bytes);
                    stream.Write(hash, 0, hash.Length);

                    bytes = stream.ToArray();
                    result = Convert.ToBase64String(bytes);
                }

            }
            return result;
        }
        public string GenerationCode()
        {
            string numeroAleatorio = "";
            var random = new Random();
            var possibilidades = Enumerable.Range(0, 10).ToList();
            var resultado = possibilidades.OrderBy(number => random.Next()).Take(10).ToArray();
            return numeroAleatorio = String.Join("", resultado);
        }
        public void ChangePassword(string newPassword, string newPasswordConfirmation)
        {
            if (newPassword == "" || newPasswordConfirmation == "")
            {
                throw new Exception("Valor de Campo Não pode ser Vazio");
            }

            _ = new Password(newPassword);

        }


    }
}
