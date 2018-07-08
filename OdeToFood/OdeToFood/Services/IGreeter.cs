using Microsoft.Extensions.Configuration;

namespace OdeToFood.Services {

    public interface IGreeter {

        string GetMessageOfTheDay();

    }

    public class MyGreeter : IGreeter {

        private IConfiguration myConfig;

        public MyGreeter(IConfiguration configuration) {

            myConfig = configuration;

        }

        public string GetMessageOfTheDay() {

            return myConfig["Greeting"];

        }

    }

}