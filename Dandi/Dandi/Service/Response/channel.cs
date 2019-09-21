using Dandi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dandi.Service.Response
{
    public class channel
    {
        private List<Model.channel> _channel;

        [JsonProperty("channel")]

        public List<Model.channel> Channel
        {
            get => _channel;
            set
            {
                _channel = value;
            }
        }
    }
}