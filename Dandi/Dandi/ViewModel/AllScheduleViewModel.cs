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


        // 원본, 전체
        private ObservableCollection<ChannelSchedule> _channelScheduleItems = new ObservableCollection<ChannelSchedule>();
        public ObservableCollection<ChannelSchedule> ChannelScheduleItems
        {
            get => _channelScheduleItems;
            set => SetProperty(ref _channelScheduleItems, value);
        }


        // 원본 필터링
        private ObservableCollection<ChannelSchedule> _selectedChannelScheduleItems = new ObservableCollection<ChannelSchedule>();
        public ObservableCollection<ChannelSchedule> SelectedChannelScheduleItems
        {
            get => _selectedChannelScheduleItems;
            set => SetProperty(ref _selectedChannelScheduleItems, value);
        }


        // 채널 조회
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


        private JoinedChannel _selectedChannel = new JoinedChannel();
        public JoinedChannel SelectedChannel
        {
            get => _selectedChannel;
            set
            {
                SetProperty(ref _selectedChannel, value);
            }
        }


        public void SetSelectedChannelSchedule()
        {
            if(JoinedChannelItems.IndexOf(SelectedChannel) == 0)
            {
                ObservableCollection<ChannelSchedule> channelSchedules = new ObservableCollection<ChannelSchedule>();
                for(int i = 0; i < SchoolScheduleItems.Count; i++)
                {
                    var newItem = new ChannelSchedule();
                    newItem.Title = SchoolScheduleItems[i].Title;
                    newItem.Start_Date = SchoolScheduleItems[i].StartDate;
                    channelSchedules.Add(newItem);
                }
                ChannelScheduleItems = channelSchedules;
                return;
            }
            var items = ChannelScheduleItems.Where(x => x.Id == SelectedChannel.Id).ToList();
            // 선택된 채널의 일정을 보여준다.
            SelectedChannelScheduleItems = new ObservableCollection<ChannelSchedule>(items);
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
            JoinedChannel newItem = new JoinedChannel();
            newItem.Name = "학사일정";
            newItem.Explain = "";
            JoinedChannelItems.Add(newItem);
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
