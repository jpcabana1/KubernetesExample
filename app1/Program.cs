var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/weatherforecast", async (IConfiguration configuration, CancellationToken cancellationToken) =>
{
    HttpClient client = new HttpClient();
    var resp = Enumerable.Empty<WeatherForecast?>();

    HttpResponseMessage response = await client.GetAsync(configuration.GetSection("Urls:app2").Get<string>() + "/weatherforecast");
    if (response.IsSuccessStatusCode && response!.Content != null)
    {
        resp = await response!.Content!.ReadFromJsonAsync<IEnumerable<WeatherForecast?>>(cancellationToken: cancellationToken)!;
    }
    return resp;
   
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

