using Prism.Mvvm;

namespace Dandi.Model
{
    public class Event : BindableBase
    {
        private string _userid = string.Empty;
        public string UserId
        {
            get => _userid;
            set
            {
                SetProperty(ref _userid, value);
            }
        }

        private string _username = string.Empty;
        public string UserName
        {
            get => _username;
            set
            {
                SetProperty(ref _username, value);
            }
        }

        private string _useremail = string.Empty;
        public string UserEmail
        {
            get => _useremail;
            set
            {
                SetProperty(ref _useremail, value);
            }
        }

        private string _school = string.Empty;
        public string School
        {
            get => _school;
            set
            {
                SetProperty(ref _school, value);
            }
        }

        // private integer _schoolgrade = integer.Empty;
        //public string SchoolGrade
        //{
        //    get => _schoolgrade;
        //    set
        //    {
        //        SetProperty(ref _schoolgrade, value);
        //    }
        //}

        // private integer _schoolclass = integer.Empty;
        //public string SchoolClass
        //{
        //    get => _schoolclass;
        //    set
        //    {
        //        SetProperty(ref _schoolclass, value);
        //    }
        //}

        private string _profilepic = string.Empty;
        public string ProfilePic
        {
            get => _profilepic;
            set
            {
                SetProperty(ref _profilepic, value);
            }
        }

        //private integer _id = integer.Empty;
        //public string Id
        //{
        //    get => _id;
        //    set
        //    {
        //        SetProperty(ref _id, value);
        //    }
        //}

        //private integer _channelid = integer.Empty;
        //public string ChannelId
        //{
        //    get => _channelid;
        //    set
        //    {
        //        SetProperty(ref _channelid, value);
        //    }
        //}
        
        private string _title = string.Empty;
        public string Title
        {
            get => _title;
            set
            {
                SetProperty(ref _title, value);
            }
        }

        private string _startdate = "yyyy-mm-dd";
        public string StartDate
        {
            get => _startdate;
            set
            {
                SetProperty(ref _startdate, value);
            }
        }

        private string _endate = "yyyy-mm-dd";
        public string EndDate
        {
            get => _endate;
            set
            {
                SetProperty(ref _endate, value);
            }
        }
    }
}