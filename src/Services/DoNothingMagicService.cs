using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Services
{
    public sealed class DoNothingMagicService : IMagicService
    {
        public void DoWork()
        {
            // Do nothing! :)
        }
    }
}
