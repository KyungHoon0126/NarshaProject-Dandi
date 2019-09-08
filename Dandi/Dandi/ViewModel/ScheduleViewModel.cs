using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dandi.ViewModel
{
    public class ScheduleViewModel : BindableBase
    {
        // JsonGet으로 받아오는 일정들을 받는 변수를 넣어줄 것.
        private string _personalschedule = "";
        public string PersonalSchedule
        {
            get => _personalschedule;
            set
            {
                SetProperty(ref _personalschedule, value);
            }
        }

        // JsonGet으로 받아오는 일정들을 받는 변수를 넣어줄 것.
        private string _publicschedule = "";
        public string PublicSchedule
        {
            get => _publicschedule;
            set
            {
                SetProperty(ref _publicschedule, value);
            }
        }
    }
}
