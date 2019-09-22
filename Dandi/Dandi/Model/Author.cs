using Newtonsoft.Json;
using Prism.Mvvm;
using System;

namespace Dandi.Model
{
    public class Author : BindableBase, ICloneable
    {
        // Channel - Event의 events의 author
        
        private string _userid;
        [JsonProperty("user_id")]
        public string UserId
        {
            get => _userid;
            set => SetProperty(ref _userid, value);
        }

        private string _userName;
        [JsonProperty("user_name")]
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        public object Clone()
        {
            return new Author
            {
                UserId = this.UserId,
                UserName = this.UserName
            };
        }
    }
}