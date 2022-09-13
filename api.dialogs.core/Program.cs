using api.dialogs.core.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<RGDialogsClients>();
builder.Services.AddScoped<DataTreatment>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
