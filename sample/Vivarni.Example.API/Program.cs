﻿
using Vivarni.DDD.Core.Repositories;
using Vivarni.Example.API.ApiModels;
using Vivarni.Example.Domain.Entities;
using Vivarni.Example.Infrastructure.SQLite;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddControllers();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseDeveloperExceptionPage();

app.MapControllers();

app.Run();