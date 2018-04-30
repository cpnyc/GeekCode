using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Transactions;
using Newtonsoft.Json;

namespace GeekCode
{
    public class Element
    {
        public Distance distance;
        public Duration duration;

        public class Distance
        {
            public string text;
            public string value;
        }

        public class Duration
        {
            public string text;
            public string value;
        }
    }

    public class Elements
    {
        public Element[] elements;
    }   

    public class TravelData
    {
        public string[] destination_addresses;
        public string[] origin_addresses;
        public Elements[] rows;

    }

    public class DistanceCalculator
    {
        public double getTotalMilesTraveled(List<Tuple<string, string>> addressList)
        {
            string origin = string.Empty;
            string destination = string.Empty;
            double totalDistanceTraveled = 0;

            foreach (var addressPair in addressList)
            {
                origin = addressPair.Item1;
                destination = addressPair.Item2;
                totalDistanceTraveled = totalDistanceTraveled + getDistance(origin, destination);
            }

            return totalDistanceTraveled;
        }

        private double getDistance(String origin, String destination)
        {
            
            String url = "https://maps.googleapis.com/maps/api/distancematrix/json" + "?origins=" + origin + "&destinations=" + destination + "&mode=driving&sensor=false&language=en&units=imperial";
            

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var jsonStr = httpClient.GetStringAsync(url).Result;
                    var travelData = JsonConvert.DeserializeObject<TravelData>(jsonStr);
                    return convertToMiles(travelData.rows[0].elements[0].distance.text);
                }
                catch (System.Exception e)
                {
                    Debug.WriteLine("Error getting distance", e);
                }
            }

            return 0;
        }

        private double convertToMiles(string miles)
        {
            miles = miles.Replace(" mi", "");
            double result = 0;
            Double.TryParse(miles, out result);
            return result;
        }
    }
}
