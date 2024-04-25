using Microsoft.AspNetCore.Components.Authorization;
using RSAllies;
using RSAllies.Authentication;
using RSAllies.Data.Contracts;
using RSAllies.Extensions;
using Wolverine;
using Wolverine.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

builder.Host.UseWolverine(options =>
{
    options.PublishMessage<UserResponseDto>()
        .ToRabbitExchange("userAnswers-exc", exchange =>
        {
            exchange.BindQueue("userAnswers-queue", "exchange2userAnswers");
        });
    options.UseRabbitMq(x =>
    {
        x.HostName = "mq-server.southafricanorth.cloudapp.azure.com";
        x.UserName = "heri";
        x.Password = "karata";
    }).AutoProvision();
});

builder.Services.AddScoped<UserResponsePublisher>();

builder.Services.AddSession();

builder.Services.AddHttpContextAccessor();

builder.Services.AddRazorPages();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

builder.Services.AddScoped<LanguageSessionManager>();

builder.Services.AddScoped<SessionChecker>();

builder.Services.AddHttpClient<ApiClient>(client => client.BaseAddress = new Uri("http://localhost:5000"));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
