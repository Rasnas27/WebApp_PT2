using Microsoft.EntityFrameworkCore;
using webApiPTI.Controllers;
using webApiPTI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Context>(options => options.UseSqlServer
("Data Source=localhost;Initial Catalog=PTI;Integrated Security=True;Trust Server Certificate=true"));

var app = builder.Build();

// Configure the HTTP request pipeline.
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
    name: "deleteAluno",
    pattern: "Alunos/ExcluirAluno/{id}",
    defaults: new { controller = "Alunos", action = "ExcluirAluno" });


app.MapControllerRoute(
    name: "getAlunosByName",
    pattern: "Alunos/FindAlunoByName/{nome}",
    defaults: new { controller = "Alunos", action = "GetAlunoByName" });

app.MapControllerRoute(
    name: "alunos",
    pattern: "Alunos/Alunos/{id?}",
    defaults: new { controller = "Alunos", action = "Alunos" });

app.MapControllerRoute(
    name: "postAluno",
    pattern: "Alunos/PostAluno",
    defaults: new { controller = "Alunos", action = "PostAluno" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
