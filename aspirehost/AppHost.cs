var builder = DistributedApplication.CreateBuilder(args);

var username = builder.AddParameter("username", value:"u_test");
var password = builder.AddParameter("password", value:"password$10");

var postgres = builder
    .AddPostgres("postgres", username, password, port: 5432);

var postgresdb = postgres.AddDatabase("postgresdb");

builder
    .AddProject<Projects.TodoMicroService>("todomicroservice")
    .WithReference(postgresdb);

builder.Build().Run();