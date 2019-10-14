using Dandi.Model;
using Dandi.Service.Response;
using Prism.Mvvm;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNetwork;
using TNetwork.Data;

namespace Dandi.ViewModel
{
    public class SchoolEventsViewModel : BindableBase
    {
        private ObservableCollection<SchoolEvents> _schoolEventsItems = new ObservableCollection<SchoolEvents>();
        public ObservableCollection<SchoolEvents> SchoolEventsItems
        {
            get => _schoolEventsItems;
            set => SetProperty(ref _schoolEventsItems, value);
        }

        public NetworkManager networkManager = new NetworkManager();

        public async Task SetSchoolEventsList()
        {
            TResponse<SchoolEventsResponse> resp = new TResponse<SchoolEventsResponse>();
            // TODO : DandiService로 묶어서 따로 빼놓기
            resp = await networkManager.GetResponse<SchoolEventsResponse>("school/events?year=2019&month=" + DateTime.Now.Month, Method.GET, null);
            
            if (resp != null && resp.Status == 200 && resp.Data != null)
            {
                try
                {
                    foreach (var item in resp.Data.SchoolEvents)
                    {
                        SchoolEventsItems.Add((SchoolEvents)item.Clone());
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine("SchoolEvents LoadDataAsync ERROR : " + e.Message);
                }
            }
        }
    }
}