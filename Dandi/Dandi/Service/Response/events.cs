using Dandi.Model;
using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dandi.Service.Response
{
    public class eventes // events
    {
        public List<events> events;//[0][1]
    }
    public class events : BindableBase
    {
        private int _id;
        [JsonProperty("id")]
        public int Id
        {
            get => _id; 
            set => SetProperty(ref _id, value);
        }

        private string _title = string.Empty;
        [JsonProperty("title")]
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private DateTime start_Date;
        [JsonProperty("start_date")]
        public DateTime Start_Date
        {
            get => start_Date;
            set => SetProperty(ref start_Date, value);
        }

        private DateTime end_Date;
        [JsonProperty("end_date")]
        public DateTime End_Date
        {
            get => end_Date;
            set => SetProperty(ref end_Date, value);
        }

        private string _content = string.Empty;
        [JsonProperty("content")]
        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }

        private int _channelId;
        [JsonProperty("channel_id")]
        public int ChannelId
        {
            get => _channelId;
            set => SetProperty(ref _channelId, value);
        }

        private author _author;
        public author Author
        {
            get => _author;
            set => SetProperty(ref _author, value);
        }

        private channel _channel;
        public channel Channel
        {
            get => _channel;
            set => SetProperty(ref _channel, value);
        }
    }
}