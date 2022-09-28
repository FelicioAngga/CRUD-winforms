using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTest.API
{
    public class WeatherModelData
    {

        public class weather
        {
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class main
        {
            public double temp { get; set; }
        }

        public class root 
        {
            public main main { get; set; }
            public List<weather> weather { get;set; }
        }

    }
}
