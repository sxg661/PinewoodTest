using Microsoft.VisualBasic;
using PinewoodBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add injectables
builder.Services.AddSingleton<ICustomerService, CustomerService>();

var MyAllowFrontend = "_myAllowFrontend";
builder.Services.AddCors(options =>
{
	options.AddPolicy(name: MyAllowFrontend,
					  policy =>
					  {
						  policy.WithOrigins("https://localhost:7175");
					  });
});

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

app.UseCors(MyAllowFrontend);

app.Run();
