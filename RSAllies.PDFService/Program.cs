using Wolverine;
using Wolverine.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();


QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

//builder.Host.UseWolverine(options =>
//{
//    options.ListenToRabbitQueue("certificate-queue");
//    options.UseRabbitMq(factory =>
//    {
//        factory.HostName = "mq-server.southafricanorth.cloudapp.azure.com";
//        factory.UserName = "heri";
//        factory.Password = "karata";
//    }).AutoProvision();
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();




