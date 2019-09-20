using Dandi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dandi.Service.Response
{
    public class SchoolEventsResponse
    {
        private List<SchoolEvents> _schoolEvents;

        [JsonProperty("events")]

        public List<SchoolEvents> SchoolEvents
        {
            get => _schoolEvents;
            set
            {
                _schoolEvents = value;
            }
        }
    }
}
