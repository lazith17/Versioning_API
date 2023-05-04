using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opts =>
{
    var title = "Our versioned API";
    var description = "This is a web API that demostrates versioning.";
    var terms = new Uri("https://localhost:7194/terms");
    var license = new OpenApiLicense()
    {
        Name = "This is my full license information or link to it"
    };
    var contact = new OpenApiContact()
    {
        Name = "Lasith Helpdesk",
        Email = "help@las.com",
        Url = new Uri("https://www.hackerrank.com/lazith15")
    };

    opts.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = $"{title} v1 (deprecated)",
        Description = description,
        License = license,
        Contact = contact
    });

    opts.SwaggerDoc("v2", new OpenApiInfo
    {
        Version = "v2",
        Title = $"{title} v2",
        Description = description,
        License = license,
        Contact = contact
    });
});

builder.Services.AddApiVersioning(opts =>
{
    opts.AssumeDefaultVersionWhenUnspecified = true;
    opts.DefaultApiVersion = new(2, 0);
    opts.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(opts =>
{
    opts.GroupNameFormat = "'v'VVV";
    opts.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opts =>
    {
        opts.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
        opts.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
