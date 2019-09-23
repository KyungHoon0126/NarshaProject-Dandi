using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dandi.Model
{
    // 사용자 각각 채널의 모든 일정을 받는 곳

    public class ChannelSchedule : BindableBase, ICloneable
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _title = string.Empty;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private DateTime start_Date;
        public DateTime Start_Date
        {
            get => start_Date;
            set => SetProperty(ref start_Date, value);
        }

        private DateTime end_Date;
        public DateTime End_Date
        {
            get => end_Date;
            set => SetProperty(ref end_Date, value);
        }

        private string _content = string.Empty;
        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }

        private Author _author = new Author();
        public Author Author
        {
            get => _author;
            set => SetProperty(ref _author, value);
        }

        public object Clone()
        {
            return new ChannelSchedule
            {
                Id = this.Id,
                Title = this.Title,
                Start_Date = this.Start_Date,
                End_Date = this.End_Date,
                Content = this.Content,
                Author = (Author)Author.Clone()
            };
        }
    }
}