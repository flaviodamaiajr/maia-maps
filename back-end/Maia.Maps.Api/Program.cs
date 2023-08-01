using Maia.Maps.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.UseStartup<Startup>();

public partial class Program { }
