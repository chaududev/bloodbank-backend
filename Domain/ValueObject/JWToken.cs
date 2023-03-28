using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObject
{
    public class JWToken
    {
        public string Token { get; private set; }
        public DateTime Expires { get; private set; }

        public JWToken()
        {
        }

        public JWToken(string token, DateTime expires)
        {
            Token = token;
            Expires = expires;
        }
    }
}
