using Dandi.Model;
using Dandi.Service.Response;
using Prism.Mvvm;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TNetwork;
using TNetwork.Data;

namespace Dandi.ViewModel
{
    public class JoinedChannelViewModel : BindableBase
    {
        // 사용자가 가입한 모든 채널 조회
        private List<JoinedChannel> _joinedChannelItems = new List<JoinedChannel>();
        public List<JoinedChannel> JoinedChannelItems
        {
            get => _joinedChannelItems;
            set => SetProperty(ref _joinedChannelItems, value);
        }


        // 채널 조회 후, 사용자가 가입한 모든 채널들의 events를 넣는 곳
        private ObservableCollection<ChannelSchedule> _allChannelScheduleItems = new ObservableCollection<ChannelSchedule>();
        public ObservableCollection<ChannelSchedule> AllChannelScheduleItems
        {
            get => _allChannelScheduleItems;
            set => SetProperty(ref _allChannelScheduleItems, value);
        }

        // 모든 채널 조회
        public NetworkManager networkManager = new NetworkManager();

        public async Task SetJoinedChannelList()
        {
            TResponse<JoinedChannelResponse> resp = new TResponse<JoinedChannelResponse>();
            
            resp = await networkManager.GetResponse<JoinedChannelResponse>("channel", Method.GET, null);

            if (resp != null && resp.Status == 200 && resp.Data != null)
            {
                try
                {
                    foreach (var item in resp.Data.JoinedChannel)
                    {
                        JoinedChannelItems.Add((JoinedChannel)item.Clone());
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine("JoinedChannelsEvent LoadDataAsync ERROR : " + e.Message);
                }
            }   

            // 사용자가 가입한 채널의 모든 일정 조회 후 Add
            for(int i = 0; i < JoinedChannelItems.Count; i++)
            { // breakpoint
                var res = await networkManager.GetResponse<eventes>("channel-event?channel_id=" + JoinedChannelItems[i].Id, Method.GET, null);

                ChannelSchedule channelSchedule = new ChannelSchedule();

                foreach (var item in res.Data.events)
                {
                    // ChannelEventEvents
                    channelSchedule.Content = item.Content;
                    channelSchedule.End_Date = item.End_Date;
                    channelSchedule.Id = item.Id;
                    channelSchedule.Start_Date = item.Start_Date;
                    channelSchedule.Title = item.Title;
                    channelSchedule.Author.UserId = item.Author.UserId;
                    channelSchedule.Author.UserName = item.Author.UserName;


                    // ChannelEventChannel
                    channelSchedule.Channel.Id = item.Channel.Id;
                    channelSchedule.Channel.Name = item.Channel.Name;
                    channelSchedule.Channel.Explain = item.Channel.Explain;
                    channelSchedule.Channel.Create_User = item.Channel.Create_User;
                    channelSchedule.Channel.Color = item.Channel.Color;
                    channelSchedule.Channel.School_Id = item.Channel.School_Id;
                    channelSchedule.Channel.IsPublic = item.Channel.IsPublic;
                    channelSchedule.Channel.CreatedAt = item.Channel.CreatedAt;
                    channelSchedule.Channel.ThumbNail = item.Channel.ThumbNail;

                    AllChannelScheduleItems.Add((ChannelSchedule)channelSchedule.Clone());
                }
            } // breakpoint

            //JoinedChannelItems.ForEach(async x =>
            //{
            //    await networkManager.GetResponse<JoinedChannelResponse>("channel-event?" + x.Id, Method.GET, null);
            //});
        }
    }
}