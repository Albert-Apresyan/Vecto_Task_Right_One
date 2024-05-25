using Vecto_;
using Vecto_.Plugins.Interfaces;
using Vecto_.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IImageProcessingService, ImageProcessingService>();
builder.Services.AddSingleton<IPlugin, BlurPlugin>();
builder.Services.AddSingleton<IPlugin, GrayscalePlugin>();
builder.Services.AddSingleton<IPlugin, ResizePlugin>();


builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
