using Newtonsoft.Json;
using Prism.Mvvm;
using System;

namespace Dandi.Model
{
    public class ChannelEvents : BindableBase, ICloneable
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private int _channelId;
        public int ChannelId
        {
            get => _channelId;
            set => SetProperty(ref _channelId, value);
        }

        private string _title = string.Empty;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }

        private Author _author;
        public Author Author
        {
            get => _author;
            set => SetProperty(ref _author, value);
        }

        public object Clone()
        {
            return new ChannelEvents
            {
                // UserId = this.UserId,
                // UserName = this.UserName,
                // UserEmail = this.UserEmail,
                // School = this.School,
                // SchoolGrade = this.SchoolGrade,
                // SchoolClass = this.SchoolClass,
                // ProfilePic = this.ProfilePic,
                Id = this.Id,
                ChannelId = this.ChannelId,
                Title = this.Title,
                StartDate = this.StartDate,
                EndDate = this.EndDate,
                Author = (Author)this.Author.Clone(),
            };
        }
    }
}