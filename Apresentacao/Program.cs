using Dominio.Infra;
using Apresentacao.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

ServicesExtensionDomain.ConfigurarDominio(builder.Services, builder.Configuration);

var app = builder.Build();

app.MapGrpcService<ContasBancariasService>();
app.MapGrpcReflectionService();

app.Run();