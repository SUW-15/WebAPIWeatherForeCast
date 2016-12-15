using Microsoft.AspNet.SignalR;
using WeatherForcastApi.Models;

namespace WeatherForcastApi.Hubs
{
    public class TemperatureHub : Hub
    {
        public void BroadCastTemperature(Temperature temperature)
        {

            Clients.All.receiveTemperature(temperature);

        }




    }
}