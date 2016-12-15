using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(WeatherForcastApi.Startup))]

namespace WeatherForcastApi
{
    public class Startup
    {

        //private BackgroundProcess _backgroundProcess;
        public void Configuration(IAppBuilder app)
        {


            //_backgroundProcess = new BackgroundProcess(new Temperature(), new TemperatureEntitiesEntities());

            app.Map("/signalr", map =>
             {
                 map.UseCors(CorsOptions.AllowAll);
                 var hubConfiguration = new HubConfiguration
                 {
                     EnableJSONP = true,
                     EnableJavaScriptProxies = true
                 };

                 map.RunSignalR(hubConfiguration);
             });


        }
    }
}
