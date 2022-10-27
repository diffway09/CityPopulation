namespace CityPopulation.Models
{
    public class Stat
    {
        public double? Level { get; set; }
        public double? Population { get; set; }

        public int CityPopulation => Convert.ToInt32(Population ?? 0);
    }
}