using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Services
{
    public sealed class DisposableMagicService : IMagicService, IDisposable
    {
        private readonly ILogger<DisposableMagicService> _logger = null;
        public DisposableMagicService(ILogger<DisposableMagicService> logger)
        {
            _logger = logger;

            logger.LogCritical("Activated!!!");
        }
        public void Dispose()
        {
            _logger.LogCritical("Disposed!!!");
        }

        public string GetSecret()
        {
            return "I am a disposable service. I will get disposed when this request is done.";
        }
    }
}
