using CityPopulation.Models;
using Newtonsoft.Json;

namespace CityPopulation.Services
{
    public static class CityPopulationService
    {
        static List<Data> Data { get; }

        static CityPopulationService()
        {
            string jsonString;
            StreamReader reader = File.OpenText(@"current.city.list.json");
            {
                jsonString = reader.ReadToEnd();
            }

            Data = JsonConvert.DeserializeObject<List<Data>>(jsonString) ?? new List<Data>();

        }

        public static List<City> GetTopTenCityPopulation()
        {
            List<City> cities = Data.Select(
                d => new City
                {
                    Country = d.Country!,
                    Name = d.Name!,
                    Population = d.Stat?.CityPopulation ?? 0
                })
                .OrderByDescending(d => d.Population)
                .Take(10)
                .ToList();

            return cities;
        }

        public static List<City> GetPopulationByCity(string city)
        {
            List<City> cities = Data
                .Where(d => d.Name == city || d.NameLangs.ContainsValue(city))
                .Select(
                d => new City
                {
                    Country = d.Country!,
                    Name = d.Name!,
                    Population = d.Stat?.CityPopulation ?? 0
                })
                .ToList();

            return cities;
        }
    }
}
