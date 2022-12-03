using MedHub.Domain.Models;
using MedHub.Infrastructure;
using MedHub.Infrastructure.Repositories;
using MedHub.Infrastructure.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<MedHubContext>(
    options => options.UseSqlite(
        builder.Configuration.GetConnectionString("MedhubDatabase"), b => b.MigrationsAssembly(typeof(MedHubContext).Assembly.FullName)));

builder.Services.AddScoped<IRepository<Patient>, PatientRepository>();
builder.Services.AddScoped<IRepository<Invoice>, InvoiceRepository>();
builder.Services.AddScoped<IRepository<Drug>, DrugRepository>();
builder.Services.AddScoped<IRepository<Doctor>, DoctorRepository>();
builder.Services.AddScoped<IRepository<Cabinet>, CabinetRepository>();
builder.Services.AddScoped<IRepository<Allergen>, AllergenRepository>();
builder.Services.AddScoped<IRepository<MedicalSpeciality>, MedicalSpecialityRepository>();
builder.Services.AddScoped<IRepository<InvoiceLineItem>, InvoiceLineItemRepository>();
builder.Services.AddScoped<IRepository<StockLineItem>, StockLineItemRepository>();
builder.Services.AddScoped<IRepository<MedicalRecord>, MedicalRecordRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("medhubCors", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
