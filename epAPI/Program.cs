using epAPI;
using epDataAccess.DbAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(
        opt => {
            opt.AddPolicy(name: "CORSPolicy", builder => {
                builder
                .WithOrigins("http://localhost:8080", "http://localhost:8081", "https://localhost:8080", "https://localhost:8081")
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
        }
    );
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IUserData, UserData>();
builder.Services.AddSingleton<IRecipeData, RecipeData>();
builder.Services.AddSingleton<IIngredientData, IngredientData>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CORSPolicy");

app.ConfigureApi();

//app.UseCors(options => options
//    .AllowAnyOrigin()
//    //.WithOrigins(new[] { "http://localhost:8081", "https://localhost:8080", "http://localhost:*" })
//    .AllowAnyHeader().AllowAnyMethod()); //.AllowCredentials()); ;

app.Run();