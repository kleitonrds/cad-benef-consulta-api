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
        Title = "API de Consulta de Beneficiário",
        Description = @"API que vai consumir os serviços do CAD-BENEF para consulta de beneficiários disponíveis na Unimed Brasil.

                        **Observações Importantes**
                         Todos os paramêtros necessários para a chamada da API devem ser repassados antes de consumir os serviços, são eles:

                        - O caminho de rede e a senha do Certificado Digital A1 adquirida pela Unimed.
                        - O client-id e o secret-id que a Unimed Brasil fornece para cada Unimed.
                        - O token gerado pelo serviço, ex: https://ua-gateway-hml.unimed.coop.br/oauth/v1/access-token.
                        - A URL do endpoint do serviço que será consumido pela API (ver documentação fornecida pela Unimed Brasil).
                        ",
        Contact = new OpenApiContact
        {
            Name = "Kleiton Souza",
            Email = new ("Kleiton.souza@mv.com.br"),
            
        },
    
    });

    //comando para adicionar comentários xml's nas rotas das classes Controllers
    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
});



// Registro de dependências
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
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Consulta de Beneficiário v1");
        c.RoutePrefix = "swagger";
    });
}

// Aplicar a política de CORS
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
