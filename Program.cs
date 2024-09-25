using Microsoft.EntityFrameworkCore;
using MyNewShop.Models;

var builder = WebApplication.CreateBuilder(args);

//kode for å legge til services for å håndtere  controllere og views til dependency injection container, som
//setter den opp til å bruke MVC
builder.Services.AddControllersWithViews();

// registrering av dbContext
builder.Services.AddDbContext<ItemDbContext>(options =>{
    options.UseSqlite(
        builder.Configuration["ConnectionStrings:ItemDbContextConnection"]);
});


var app = builder.Build();

if (app.Environment.IsDevelopment()) // sjekker hvilket miljø den er i
{
    app.UseDeveloperExceptionPage(); // kode for å vise feilmeldinger i developer miljø
}

// gjør at man bruker statiske filer (som ligger i wwwroot) som i dette tilfellet er bootstrap og jquery
app.UseStaticFiles();

app.MapDefaultControllerRoute(); // setter opp en default url adresse struktur
                                // dette legger også til en middleware til pipeline. håndterer routing av inkommende requests

app.Run(); // legger til middleware, siste delen i en pipeline. håndterer requests og gir respons
