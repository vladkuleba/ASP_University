using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddTransient<ITimeOfDayService, TimeOfDayService>();
builder.Services.AddSingleton<CalcService>();
var app = builder.Build();

app.MapGet("/time", ([FromServices] ITimeOfDayService timeOfDayService) => timeOfDayService.GetTimeOfDay());

app.MapGet("/add/{a}/{b}", ([FromServices] CalcService calcService, int a, int b) =>
    calcService.Add(a, b).ToString());

app.MapGet("/subtract/{a}/{b}", ([FromServices] CalcService calcService, int a, int b) =>
    calcService.Subtract(a, b).ToString());

app.MapGet("/multiply/{a}/{b}", ([FromServices] CalcService calcService, int a, int b) =>
    calcService.Multiply(a, b).ToString());

app.MapGet("/divide/{a}/{b}", ([FromServices] CalcService calcService, int a, int b) =>
    calcService.Divide(a, b).ToString());

app.MapGet("/", ([FromServices] ITimeOfDayService timeOfDayService) =>
    $"The time of day is: {timeOfDayService.GetTimeOfDay()}");

app.Run();