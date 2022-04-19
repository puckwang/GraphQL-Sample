using GraphQL.Sample.GraphQL;
using GraphQL.Sample.Services;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddSingleton<UserService>();
services
    .AddGraphQLServer()
    .AddQueryType<Query>();
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
app.MapGraphQL();
app.UseCors();
app.Run();
