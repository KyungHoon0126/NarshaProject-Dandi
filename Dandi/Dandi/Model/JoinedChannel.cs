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
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _userId = string.Empty;
        public string UserId
        {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }

        private bool _isAllowed;
        public bool IsAllowed
        {
            get => _isAllowed;
            set => SetProperty(ref _isAllowed, value);
        }

        private bool _pushNotify;
        public bool PushNotify
        {
            get => _pushNotify;
            set => SetProperty(ref _pushNotify, value);
        }

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
