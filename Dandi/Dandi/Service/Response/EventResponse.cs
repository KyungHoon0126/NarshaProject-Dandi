using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dandi.Model
{
    public class EventResponse
    {
        private List<Event> _events;
        public List<Event> Events 
        {
            get => _events;
            set
            {
                _events = value;
            }
        }
    }

    public class EventUserInformation : BindableBase
    {
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
    }
}