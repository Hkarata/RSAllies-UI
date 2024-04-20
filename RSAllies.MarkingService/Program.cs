using RSAllies.Data.Contracts;
using RSAllies.MarkingService;
using Wolverine;
using Wolverine.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Host.UseWolverine(options =>
{
    options.ListenToRabbitQueue("userAnswers-queue");

    options.PublishMessage<CreateCertificate>()
        .ToRabbitExchange("certificate-exc", exchange =>
        {
            exchange.BindQueue("certificate-queue", "certificate4user");
        });
    
    options.UseRabbitMq(factory =>
    {
        factory.HostName = "mqserver.southafricanorth.cloudapp.azure.com";
        factory.UserName = "heri";
        factory.Password = "karata";
    }).AutoProvision();
});

builder.Services.AddMemoryCache();

builder.Services.AddScoped<UserResponseDtoHandler>();

builder.Services.AddHttpClient<ApiClient>(client => client.BaseAddress = new Uri("https://localhost:5000"));

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

app.Run();
