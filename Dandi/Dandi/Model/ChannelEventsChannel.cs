using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dandi.Model
{
    public class ChannelEventsChannel : BindableBase, ICloneable
    {
        // Channel - Event의 Channel, ※ 클래스 이름 수정 필요 ※

        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _explain = string.Empty;
        public string Explain
        {
            get => _explain;
            set => SetProperty(ref _explain, value);
        }

        private string create_User = string.Empty;
        public string Create_User
        {
            get => create_User;
            set => SetProperty(ref create_User, value);
        }

        private string _color = string.Empty;
        public string Color
        {
            get => _color;
            set => SetProperty(ref _color, value);
        }

        private string school_Id = string.Empty;
        public string School_Id
        {
            get => school_Id;
            set => SetProperty(ref school_Id, value);
        }

        private bool _isPublic;
        public bool IsPublic
        {
            get => _isPublic;
            set => SetProperty(ref _isPublic, value);
        }
                    
        private DateTime _createdAt;
        public DateTime CreatedAt
        {
            get => _createdAt;
            set => SetProperty(ref _createdAt, value);
        }

        private string _thumbNail = string.Empty;
        public string ThubNail
        {
            get => _thumbNail;
            set => SetProperty(ref _thumbNail, value);
        }

        public object Clone()
        {
            return new ChannelEventsChannel
            {
                Id = this.Id,
                Name = this.Name,
                Explain = this.Explain,
                Create_User = this.Create_User,
                Color = this.Color,
                School_Id = this.School_Id,
                IsPublic = this.IsPublic,
                CreatedAt = this.CreatedAt,
                ThubNail = this.ThubNail
            };
        }
    }
}
