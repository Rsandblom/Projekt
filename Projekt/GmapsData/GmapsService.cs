using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.GmapsData
{
    public class GmapsService : IGmapsService
    {
        private readonly IOptions<GmapsSettings> _gmapsSettings;

        public GmapsService(IOptions<GmapsSettings> gmapsSettings)
        {
            _gmapsSettings = gmapsSettings;
        }

        public string GetGmapsAPIandKey()
        {
            return _gmapsSettings.Value.GmapsAPIandKey;
        }
    }
}
