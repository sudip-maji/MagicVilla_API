<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 1d945c3a6169b9fe3aed61bee7a4541b9a52bc3e
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
<<<<<<< HEAD
=======
=======
using MagicVilla_VillaAPI.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDBContext>(option =>{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});
builder.Services.AddControllers(option=>{
    option.ReturnHttpNotAcceptable=true;
});
// .AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
>>>>>>> 521ccf57076bb568b26d1e2d13fae82ab4d9d017
>>>>>>> 1d945c3a6169b9fe3aed61bee7a4541b9a52bc3e

var app = builder.Build();

// Configure the HTTP request pipeline.
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 1d945c3a6169b9fe3aed61bee7a4541b9a52bc3e
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
<<<<<<< HEAD
=======
=======
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
>>>>>>> 521ccf57076bb568b26d1e2d13fae82ab4d9d017
>>>>>>> 1d945c3a6169b9fe3aed61bee7a4541b9a52bc3e

app.Run();
