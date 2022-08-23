using GraphQL.Sample.GraphQL;
using GraphQL.Sample.GraphQL.TypeExtensions;
using GraphQL.Sample.Repositories;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddSingleton<UserRepository>();
services
    .AddGraphQLServer()
    .AddTypeExtension<UserTypeExtensions>()
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
