var builder = WebApplication.CreateBuilder(args);
//Graphql Sever
builder.Services
.AddGraphQLServer()
.AddQueryType<Query>();
//.AddJsonSupport();
//.InitializeOnStrartup();
builder.Services.AddScoped<IRestApiQuery, RestApiQuery>();

var app = builder.Build();

RestService.InitializeClient();


app.MapGraphQL();

app.Run();
