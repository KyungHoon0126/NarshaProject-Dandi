using Dandi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dandi.Service.Response
{
    public class JoinedChannelResponse
    {
        private List<JoinedChannel> _joinedChannel;

        [JsonProperty("joinedChannel")]
        public List<JoinedChannel> JoinedChannel
        {
            get => _joinedChannel;
            set
            {
                _joinedChannel = value;
            }
        }
    }
}
