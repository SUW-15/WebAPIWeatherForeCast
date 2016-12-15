using Microsoft.AspNet.SignalR;
using System;
using System.Threading;
using System.Web.Hosting;
using WeatherForcastApi.Hubs;
using WeatherForcastApi.Models;

namespace WeatherForcastApi
{
    public class BackgroundProcess : IRegisteredObject
    {
        private Timer taskTimer;
        private IHubContext hub;
        private Temperature _temp;
        private TemperatureEntitiesEntities _db;

        public BackgroundProcess(Temperature temp, TemperatureEntitiesEntities db)
        {
            HostingEnvironment.RegisterObject(this);

            hub = GlobalHost.ConnectionManager.GetHubContext<TemperatureHub>();

            taskTimer = new Timer(OnTimerElapsed, null, TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(.10));
            _db = db;



        }

        private void OnTimerElapsed(object state)
        {


            hub.Clients.All.broadcastTemperature(DateTime.Now.ToString(), _db.Temperatures);
        }

        public void Stop(bool immediate)
        {
            taskTimer.Dispose();
            HostingEnvironment.UnregisterObject(this);
        }
    }
}