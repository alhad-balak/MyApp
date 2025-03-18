using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scrutor; // ✅ Import Scrutor
using MyApp.Services;
using System.ComponentModel.Design;

var builder = WebApplication.CreateBuilder(args);

// Register controllers and services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Auto-register all services in the "Services" namespace
builder.Services.Scan(scan => scan
    .FromAssemblyOf<Program>()  // Scan services in this assembly
    .AddClasses(classes => classes.InNamespaces("MyApp.Services"))
    .AsImplementedInterfaces()
    .WithScopedLifetime());

var app = builder.Build();

//// ✅ Invoke GetMessage() from HelloService in Program.cs
//using (var scope = app.Services.CreateScope())
//{
//    var helloService = scope.ServiceProvider.GetRequiredService<IHelloService>();
//    Console.WriteLine($"Message from Service: {helloService.GetMessage()}");
//}

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
