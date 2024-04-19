using Wolverine;
using Wolverine.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

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

var app = builder.Build();

app.Run();