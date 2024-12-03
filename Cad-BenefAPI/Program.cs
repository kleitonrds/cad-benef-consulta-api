using Cad_BenefAPI;


var builder = WebApplication.CreateBuilder(args);

builder.AddServices();
builder.AddSwaggerDocs();



var app = builder.Build();


// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Consulta de Beneficiário v1");
        c.RoutePrefix = "swagger";
    });


// Aplicar a política de CORS
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
