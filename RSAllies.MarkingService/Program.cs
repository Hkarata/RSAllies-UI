using Wolverine;
using Wolverine.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


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
