using RSAllies.Marker;
using Wolverine;
using Wolverine.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Host.UseWolverine(x =>
{
    x.ListenToRabbitQueue("userAnswers-queue");
    x.UseRabbitMq(options =>
    {
        options.HostName = "mqserver.southafricanorth.cloudapp.azure.com";
        options.UserName = "heri";
        options.Password = "karata";
    }).AutoProvision();
});

builder.Services.AddHttpClient<ApiClient>(client => client.BaseAddress = new Uri("http://localhost:5000"));

var app = builder.Build();

app.Run();