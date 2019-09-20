using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dandi.Model
{
    public class SchoolEvents : BindableBase, ICloneable
    {
        private string _title = string.Empty;
        public string Title
        {
            get => _title;
            set
            {
                SetProperty(ref _title, value);
            }
        }

        private DateTime _startdate;
        public DateTime StartDate
        {
            get => _startdate;
            set
            {
                SetProperty(ref _startdate, value);
            }
        }

        private DateTime _enddate;
        public DateTime EndDate
        {
            get => _enddate;
            set
            {
                SetProperty(ref _enddate, value);
            }
        }

        public object Clone()
        {
            return new SchoolEvents
            {
                Title = this.Title,
                StartDate = this.StartDate,
                EndDate = this.EndDate,
            };
        }
    }
}
