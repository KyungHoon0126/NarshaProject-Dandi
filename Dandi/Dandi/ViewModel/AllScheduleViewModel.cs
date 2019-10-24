using Dandi.Model;
using Dandi.Service;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dandi.ViewModel
{
    public class AllScheduleViewModel : BindableBase
    {
        private ScheduleService scheduleService = new ScheduleService();


        private ObservableCollection<ChannelSchedule> _channelScheduleItems = new ObservableCollection<ChannelSchedule>();
        public ObservableCollection<ChannelSchedule> ChannelScheduleItems
        {
            get => _channelScheduleItems;
            set => SetProperty(ref _channelScheduleItems, value);
        }


        private ObservableCollection<JoinedChannel> _joinedChannelItems = new ObservableCollection<JoinedChannel>();
        public ObservableCollection<JoinedChannel> JoinedChannelItems
        {
            get => _joinedChannelItems;
            set => SetProperty(ref _joinedChannelItems, value);
        }


        private ObservableCollection<SchoolSchedule> _schoolScheduleItems = new ObservableCollection<SchoolSchedule>();
        public ObservableCollection<SchoolSchedule> SchoolScheduleItems
        {
            get => _schoolScheduleItems;
            set => SetProperty(ref _schoolScheduleItems, value);
        }


        // 생성자는 Property 밑에 
        public AllScheduleViewModel()
        {

        }

        public async Task LoadDataAsync()
        {
            await GetJoinedChannels();
            await GetSchoolScheduleItems();
        }


        private async Task GetJoinedChannels()
        {
            var resp = await scheduleService.GetJoinedChannel();
            if (resp.Status != 200)
            {
                return;
            }

            JoinedChannelItems = new ObservableCollection<JoinedChannel>(resp.Data.JoinedChannel);
        }


        private async Task GetSchoolScheduleItems()
        {
            var resp = await scheduleService.GetSchoolScheduleItems();
            if (resp.Status != 200)
            {
                return;
            }

            SchoolScheduleItems = new ObservableCollection<SchoolSchedule>(resp.Data.SchoolEvents);
        }

    }
}
