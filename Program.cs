var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet(pattern:"/", handler:(TokenService service) 
    => service.Generate(
        new User(Id:1,
        Email:"teste@teste.com",
        Password:"123",
        Roles: new[]
        {
            "adm","comum"
        })));

app.Run();
