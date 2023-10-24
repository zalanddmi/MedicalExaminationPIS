/*using ServerME.Data;

var dbFiller = new DataBaseFiller();
dbFiller.FillDataBase();*/







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
