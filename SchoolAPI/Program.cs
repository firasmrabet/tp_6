using Microsoft.EntityFrameworkCore;
using SchoolAPI.DTOs;
using SchoolAPI.Models;
using SchoolAPI.Repositories;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");

builder.Services.AddDbContext<SchoolDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SchoolConnection")));

builder.Services.AddAutoMapper(typeof(SchoolsAutoMapperProfile));

builder.Services.AddScoped<IUniversityRepository, SchoolRepository>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.HeadContent = @"
<style>
  #mvc-link-btn {
    position: fixed; top: 14px; right: 24px; z-index: 99999;
    background: #2563eb; color: #fff !important;
    padding: 12px 22px; border-radius: 8px;
    text-decoration: none; font-weight: 700; font-size: 15px;
    font-family: 'Segoe UI', Roboto, sans-serif;
    box-shadow: 0 4px 12px rgba(0,0,0,.25);
    border: 2px solid #1d4ed8; transition: all .15s;
  }
  #mvc-link-btn:hover { background: #1d4ed8; transform: translateY(-1px); }
  #mvc-link-btn::before { content: '\1F310'; margin-right: 8px; }
</style>
<script>
  window.addEventListener('DOMContentLoaded', function () {
    var a = document.createElement('a');
    a.id = 'mvc-link-btn';
    a.href = 'https:
    a.target = '_blank';
    a.rel = 'noopener';
    a.title = 'Ouvrir l\u2019application MVC SchoolWebAppClient dans un nouvel onglet';
    a.textContent = 'Ouvrir l\u2019interface MVC';
    document.body.appendChild(a);
  });
</script>
";
    });
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run();

