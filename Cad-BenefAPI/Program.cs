using Cad_BenefAPI.Interfaces;
using Cad_BenefAPI.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API de Consulta de Benefici�rio",
        Description = @"API que vai consumir os servi�os do CAD-BENEF para consulta de benefici�rios dispon�veis na Unimed Brasil.

                        **Observa��es Importantes**
                         Todos os param�tros necess�rios para a chamada da API devem ser repassados antes de consumir os servi�os, s�o eles:

                        - O caminho de rede e a senha do Certificado Digital A1 adquirida pela Unimed.
                        - O client-id e o secret-id que a Unimed Brasil fornece para cada Unimed.
                        - O token gerado pelo servi�o, ex: https://ua-gateway-hml.unimed.coop.br/oauth/v1/access-token.
                        - A URL do endpoint do servi�o que ser� consumido pela API (ver documenta��o fornecida pela Unimed Brasil).
                        ",
        Contact = new OpenApiContact
        {
            Name = "Kleiton Souza",
            Email = new ("Kleiton.souza@mv.com.br"),
            
        },
    
    });

    //comando para adicionar coment�rios xml's nas rotas das classes Controllers
    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
});



// Registro de depend�ncias
builder.Services.AddScoped<IBeneficiarioService, BeneficiarioService>();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Consulta de Benefici�rio v1");
        c.RoutePrefix = "swagger";
    });
}

// Aplicar a pol�tica de CORS
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
