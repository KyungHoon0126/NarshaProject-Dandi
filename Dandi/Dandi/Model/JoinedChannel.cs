using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dandi.Model
{
    public class JoinedChannel : BindableBase, ICloneable
    {
        // Channel의 JoinedChannel

        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _name;
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
            set => SetProperty(ref _isPublic, IsPublic);
        }

        private DateTime _dateTime;
        public DateTime DateTime
        {
            get => _dateTime;
            set => SetProperty(ref _dateTime, value);
        }

        private DateTime createdAt;
        public DateTime CreatedAt
        {
            get => createdAt;
            set => SetProperty(ref createdAt, value);
        }
                
                "createdAt": datetime,
        private string _thumbNail;
        public string ThubmNail
        {
            get => _thumbNail;
            set => SetProperty(ref _thumbNail, value);
        }

        public object Clone()
        {
            return new JoinedChannel
            {
                Id = this.Id,
                UserId = this.UserId,
                IsAllowed = this.IsAllowed,
                PushNotify = this.PushNotify,
                ThubmNail = this.ThubmNail
            };
        }
    }
}
