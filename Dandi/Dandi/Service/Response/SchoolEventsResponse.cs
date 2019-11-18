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
        private List<SchoolSchedule> _schoolEvents;

        [JsonProperty("events")]

        public List<SchoolSchedule> SchoolEvents
        {
            get => _schoolEvents;   
            set
            {
                _schoolEvents = value;
            }
        }
    }
}
