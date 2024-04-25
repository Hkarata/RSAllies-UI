using Microsoft.Extensions.Hosting;
using RSAllies.Data.Contracts;
using Wolverine;
using Wolverine.RabbitMQ;

var builder = Host.CreateDefaultBuilder();

builder.UseWolverine(options =>
{
    options.ListenToRabbitQueue("userAnswers-queue");

    options.PublishMessage<CreateCertificate>()
        .ToRabbitExchange("certificate-exc", exchange =>
        {
            exchange.BindQueue("certificate-queue", "certificate4user");
        });

    options.UseRabbitMq(factory =>
    {
        factory.HostName = "mq-server.southafricanorth.cloudapp.azure.com";
        factory.UserName = "heri";
        factory.Password = "karata";
    }).AutoProvision();
});


var app = builder.Build();

app.Run();