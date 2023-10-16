using ServerME.Models;
using (var context = new Context(null))
{
    var mun = new Municipality();
    mun.Name = "Tulen";
    context.Municipalities.Add(mun);
    var typeOrg = new TypeOrganization() { Name = "Teta" };
    var typeOrg2 = new TypeOrganization() { Name = "Teta" };
    context.TypeOrganizations.Add(typeOrg);
    context.SaveChanges();
    context.TypeOrganizations.Add(typeOrg2);
    context.SaveChanges();
}




var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
 builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
*/


app.UseSession();

app.UseAuthorization();

app.MapControllers();

app.Run();
