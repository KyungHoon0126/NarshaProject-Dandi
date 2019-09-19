using Newtonsoft.Json;
using Prism.Mvvm;
using System;

namespace Dandi.Model
{
    public class ChannelEvent : BindableBase, ICloneable
    {
        //private string _userEmail = string.Empty;
        //public string UserEmail
        //{
        //    get => _userEmail;
        //    set
        //    {
        //        SetProperty(ref _userEmail, value);
        //    }
        //}

        //private string _school = string.Empty;
        //public string School
        //{
        //    get => _school;
        //    set
        //    {
        //        SetProperty(ref _school, value);
        //    }
        //}

        //private int _schoolgrade;
        //public int SchoolGrade
        //{
        //    get => _schoolgrade;
        //    set
        //    {
        //        SetProperty(ref _schoolgrade, value);
        //    }
        //}

        //private int _schoolclass;
        //public int SchoolClass
        //{
        //    get => _schoolclass;
        //    set
        //    {
        //        SetProperty(ref _schoolclass, value);
        //    }
        //}

        //private string _profilepic = string.Empty;
        //public string ProfilePic
        //{
        //    get => _profilepic;
        //    set
        //    {
        //        SetProperty(ref _profilepic, value);
        //    }
        //}

        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                SetProperty(ref _id, value);
            }
        }

        private int _channelId;
        public int ChannelId
        {
            get => _channelId;
            set
            {
                SetProperty(ref _channelId, value);
            }
        }

        private string _title = string.Empty;
        public string Title
        {
            get => _title;
            set
            {
                SetProperty(ref _title, value);
            }
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                SetProperty(ref _startDate, value);
            }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                SetProperty(ref _endDate, value);
            }
        }

        private Author _author;
        public Author Author
        {
            get => _author;
            set => SetProperty(ref _author, value);
        }

        public object Clone()
        {
            return new ChannelEvent
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
                Author = (Author)this.Author.ChannelEventClone(),
            };
        }
    }
}