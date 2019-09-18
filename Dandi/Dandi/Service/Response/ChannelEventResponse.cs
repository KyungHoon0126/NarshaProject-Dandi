using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dandi.Model
{
    public class EventResponse
    {
        private List<ChannelEvent> _events;
        public List<ChannelEvent> Events 
        {
            get => _events;
            set
            {
                _events = value;
            }
        }
    }
}