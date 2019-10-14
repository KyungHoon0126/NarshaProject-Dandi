using Dandi.Model;
using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// TODO : 모델로 옮기기

namespace Dandi.Service.Response
{
    public class channels // events
    {
        public List<channel> channel;  //[0][1]
    }

    public class channel : BindableBase, ICloneable
    {
        private int _id;
        [JsonProperty("id")]
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _name = string.Empty;
        [JsonProperty("name")]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _explain = string.Empty;
        [JsonProperty("explain")]
        public string Explain
        {
            get => _explain;
            set => SetProperty(ref _explain, value);
        }

        private string create_User = string.Empty;
        [JsonProperty("create_user")]
        public string Create_User
        {
            get => create_User;
            set => SetProperty(ref create_User, value);
        }

        private string _color = string.Empty;
        [JsonProperty("color")]
        public string Color
        {
            get => _color;
            set => SetProperty(ref _color, value);
        }

        private string school_Id = string.Empty;
        [JsonProperty("school_id")]
        public string School_Id
        {
            get => school_Id;
            set => SetProperty(ref school_Id, value);
        }

        private Boolean _isPublic;
        [JsonProperty("isPublic")]
        public Boolean IsPublic
        {
            get => _isPublic;
            set => SetProperty(ref _isPublic, value);
        }

        private DateTime _createdAt;
        [JsonProperty("createdAt")]
        public DateTime CreatedAt
        {
            get => _createdAt;
            set => SetProperty(ref _createdAt, value);
        }

        public string _thumbNail = string.Empty;
        [JsonProperty("thumbnail")]
        public string ThumbNail
        {
            get => _thumbNail;
            set => SetProperty(ref _thumbNail, value);
        }

        public object Clone()
        {
            return new channel
            {
                Id = this.Id,
                Name = this.Name,
                Explain = this.Explain,
                Create_User = this.Create_User,
                Color = this.Color,
                School_Id = this.School_Id,
                IsPublic = this.IsPublic,
                CreatedAt = this.CreatedAt,
                ThumbNail = this.ThumbNail
            };
        }
    }

    //public class channel
    //{
    //    private List<channel> _channel;

    //    [JsonProperty("channel")]

    //    public List<channel> Channel
    //    {
    //        get => _channel;
    //        set
    //        {
    //            _channel = value;
    //        }
    //    }
    //}
}