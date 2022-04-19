using GraphQL.Sample.Services;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddSingleton<UserService>();
services.AddControllers();
services.AddCors(options =>
    options.AddDefaultPolicy(policyBuilder => policyBuilder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .Build()
    )
);

var app = builder.Build();
app.UseAuthorization();
app.MapControllers();
app.UseCors();
app.Run();
