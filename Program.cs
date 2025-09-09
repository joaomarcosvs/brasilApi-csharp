using IntegraBrasilApi.Interfaces;
using IntegraBrasilApi.Mappings;
using IntegraBrasilApi.Rest;
using IntegraBrasilApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg => { }, typeof(IntegraBrasilApi.Mappings.EnderecoMapping));

builder.Services.AddSingleton<IEnderecoService, EnderecoService>();
builder.Services.AddSingleton<IBancoService, BancoService>();
builder.Services.AddSingleton<IBrasilApi, BrasilApiRest>();

builder.Services.AddAutoMapper(typeof(EnderecoMapping));
builder.Services.AddAutoMapper(typeof(BancoMapping));

// 👉 Aqui está a mágica com HttpClientFactory
builder.Services.AddHttpClient<IPortalTransparenciaRest, PortalTransparenciaRest>();

builder.Services.AddScoped<IPortalTransparenciaService, PortalTransparenciaService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();