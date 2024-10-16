using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Warsztat;
using MudBlazor.Services;
using Blazored.LocalStorage;
using Microsoft.EntityFrameworkCore;
using warsztat.Services;
using warsztat.Data;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress ?? "https://localhost:7145") });

builder.Services.AddMudServices();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddDbContext<warsztatDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WarsztatDb")));

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<CarService>();

builder.Services.AddScoped<IWorkerService, WorkerService>();

await builder.Build().RunAsync();
