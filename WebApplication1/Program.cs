using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var appRunner = new AppRunOrchestrator(null);
var cO = new ControllersOrchestrator(appRunner);
var aO = new AuthOrchestrator(cO);
var hO = new HttpsRedirectionOrchestrator(aO);
var sO = new SwaggerOrchestrator(hO);

sO.Orchestrate(app);

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//	app.UseSwagger();
//	app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
