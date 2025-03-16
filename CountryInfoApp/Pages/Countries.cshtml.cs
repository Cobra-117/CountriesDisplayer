using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CountriesModel : PageModel
{
    private readonly CountryService _countryService;

    public List<Country> Countries { get; set; } = new();

    public CountriesModel(CountryService countryService) // Inject CountryService
    {
        _countryService = countryService;
    }

    public async Task OnGet()
    {
        Countries = await _countryService.GetCountriesAsync();
    }
}
