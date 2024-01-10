using BookStore2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<Appuser, IdentityRole>().AddEntityFrameworkStores<Appdbcontext>();
builder.Services.AddScoped<IBooksRepo, BooksRepo>();

builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});


builder.Services.AddDbContext<Appdbcontext>(

    options => { options.UseSqlServer("Server = .\\SQLEXPRESS; Database = TheBookStore; Integrated Security = SSPI; TrustServerCertificate = True; "); }
    );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseSession();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Register}/{id?}");

app.Run();
//builder.Services.AddDbContext<ITIEntity>(optionBuilder => {
//    optionBuilder.UseSqlServer("Data Source=.;Initial Catalog=Intake42Q3Assiut;Integrated Security=True");
//    ).

////Custom Service --REgister
//builder.Services.AddScoped<IStudentRepository, StudentRepository>();
//builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();



//var app = builder.Build();

//// Configure the HTTP request pipeline.
//#region Custom Middlemware "Inline Middleware"
////app.Use(async (httpContext, next) => {
//    await  httpContext.Response.WriteAsync("MiddleWare 1\n");
//    await  next.Invoke();
//    await httpContext.Response.WriteAsync("MiddleWare 1_1\n");


//});

//app.Run(async (context) => {
//    await context.Response.WriteAsync("Terminate\n");
//});
//app.Use(async (httpContext, next) => {
//    await httpContext.Response.WriteAsync("MiddleWare 2\n");
//    await next.Invoke();
//    await httpContext.Response.WriteAsync("MiddleWare 2_2\n");

//});
//#endregion


//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//}
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthentication();//requet

//app.UseAuthorization();
//app.UseSession();
//app.MapControllerRoute(
//               name: "default",
//               pattern: "ITI/{age:int:max(50)}/{name:alpha}",
//               defaults: new { controller = "Student", action = "TestRoute" });
//            app.MapControllerRoute(
//                name: "default",
//                pattern: "{controller=Home}/{action=Index}/{id?}");

//            app.Run();
//        }
//    }
//}