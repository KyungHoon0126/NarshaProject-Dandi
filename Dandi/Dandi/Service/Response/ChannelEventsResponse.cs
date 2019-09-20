using Dandi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dandi.Service.Response
{
    public class ChannelEventsResponse
    {
        private List<ChannelEvents> _channelEvents;

        [JsonProperty("events")]

        public List<ChannelEvents> ChannelEvents 
        {
            get => _channelEvents;
            set
            {
                _channelEvents = value;
            }
        }
    }
}