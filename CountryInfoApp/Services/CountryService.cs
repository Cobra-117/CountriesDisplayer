using System.Text.Json;

public class Country
{
    public Name Name { get; set; }
    public List<string> Tld { get; set; }
    public string Cca2 { get; set; }
    public string Ccn3 { get; set; }
    public string Cca3 { get; set; }
    public bool Independent { get; set; }
    public string Status { get; set; }
    public bool UnMember { get; set; }
    public Dictionary<string, Currency> Currencies { get; set; }
    public Idd Idd { get; set; }
    public List<string> Capital { get; set; }
    public List<string> AltSpellings { get; set; }
    public string Region { get; set; }
    public string Subregion { get; set; }
    public Dictionary<string, string> Languages { get; set; }
    public Translations Translations { get; set; }
    public List<double> LatLng { get; set; }
    public bool Landlocked { get; set; }
    public double Area { get; set; }
    public Demonyms Demonyms { get; set; }
    public string Flag { get; set; }
    public Maps Maps { get; set; }
    public long Population { get; set; }
    public Car Car { get; set; }
    public List<string> Timezones { get; set; }
    public List<string> Continents { get; set; }
    public Flags Flags { get; set; }
    public CoatOfArms CoatOfArms { get; set; }
    public string StartOfWeek { get; set; }
    public CapitalInfo CapitalInfo { get; set; }
}

public class Name
{
    public string Common { get; set; }
    public string Official { get; set; }
    public Dictionary<string, NameDetails> NativeName { get; set; }
}

public class NameDetails
{
    public string Official { get; set; }
    public string Common { get; set; }
}

public class Currency
{
    public string Name { get; set; }
    public string Symbol { get; set; }
}

public class Idd
{
    public string Root { get; set; }
    public List<string> Suffixes { get; set; }
}

public class Translations
{
    public Dictionary<string, Translation> TranslatedNames { get; set; }
}

public class Translation
{
    public string Official { get; set; }
    public string Common { get; set; }
}

public class Demonyms
{
    public Dictionary<string, string> Eng { get; set; }
}

public class Maps
{
    public string GoogleMaps { get; set; }
    public string OpenStreetMaps { get; set; }
}

public class Car
{
    public List<string> Signs { get; set; }
    public string Side { get; set; }
}

public class Flags
{
    public string Png { get; set; }
    public string Svg { get; set; }
}

public class CoatOfArms
{
}

public class CapitalInfo
{
    public List<double> LatLng { get; set; }
}


public class CountryService
{
    private readonly HttpClient _httpClient;

    public CountryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Country>> GetCountriesAsync()
    {
        var response = await _httpClient.GetStringAsync("https://restcountries.com/v3.1/all");
        var countries = JsonSerializer.Deserialize<List<Country>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        return countries;
    }
}

