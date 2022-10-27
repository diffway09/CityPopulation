namespace CityPopulation.Models
{
    public class Data
    {
        public string? Id { get; set; }
        public Coord? Coord { get; set; }
        public string? Country { get; set; }
        public Geoname? Geoname { get; set; }
        public List<Dictionary<string, string>>? Langs { get; set; }
        public string? Name { get; set; }
        public Stat? Stat { get; set; }
        public List<Station>? Stations { get; set; }
        public double? Zoom { get; set; }

        public Dictionary<string, string> NameLangs => Langs?.SelectMany(d => d).ToDictionary(e => e.Key, e => e.Value) ?? new Dictionary<string, string>();

    }
}
