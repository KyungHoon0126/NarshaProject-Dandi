using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dandi.Model
{
    public class Author : BindableBase, ICloneable
    {
        // Channel - Event의 Events의 Author

        private string _userId = string.Empty;
        public string UserId
        {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }

        private string _userName = string.Empty;
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