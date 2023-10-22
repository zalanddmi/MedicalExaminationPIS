using ServerME.Models;
using (var context = new Context())
{
    /*var mun = new Municipality();
    mun.Name = "Tulen";
    context.Municipalities.Add(mun);*/
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



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();


app.UseSession();

app.UseAuthorization();

app.MapControllers();

app.Run();
