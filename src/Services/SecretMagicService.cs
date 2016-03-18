using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Services
{
    public sealed class SecretMagicService : IMagicService
    {
        public string GetSecret()
        {
            return "This is a secret. Only I know about this message!";
        }
    }
}
