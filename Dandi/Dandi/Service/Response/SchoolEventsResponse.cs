using Dandi.Model;
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
