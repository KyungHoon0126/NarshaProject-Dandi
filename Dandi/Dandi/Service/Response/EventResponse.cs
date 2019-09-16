using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dandi.Model
{
    public class EventResponse
    {
        private List<Event> _events;
        public List<Event> Events 
        {
            get => _events;
            set
            {
                _events = value;
            }
        }
    }
}