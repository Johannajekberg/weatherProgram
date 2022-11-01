using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weatherProgram
{
    internal class WeatherOfTheDay
    {
        public string Sun { get; set; }
        public string Windy { get; set; }
        public int Temp { get; set; }

        public WeatherOfTheDay(string sun, string windy, int temp)
        {
            Sun = sun;
            Windy = windy;
            Temp = temp;
        }
    }
}
