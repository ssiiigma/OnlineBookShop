using OnlineBookShop.Components;
using OnlineBookShop.Components.Pages.Models;

public class ProductService
{
    private readonly HttpClient _http;
    public ProductService(HttpClient http) => _http = http;

    public async Task<List<Book>> GetProducts()
        => await _http.GetFromJsonAsync<List<Book>>("products") ?? new();

    
    
}