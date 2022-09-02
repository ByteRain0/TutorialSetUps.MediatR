using MediatR;
using Voyager;
using VoyagerAPI.Infrastructure;
using VoyagerAPI.Service.BLL;
using VoyagerAPI.Service.DAL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

//--Product service
builder.Services.AddSingleton<FakeDataStore>();
builder.Services.AddTransient<IProductService, ProductService>();

//--Behaviors
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceMiddleware<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidator<,>));
builder.Services.AddMediatR(typeof(Program).Assembly);


//--Voyager
builder.Services.AddVoyager(c =>
{
    c.AddAssemblyWith<Program>();
});


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseVoyagerExceptionHandler();
app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapVoyager();
    endpoints.MapControllers();
});
app.Run();