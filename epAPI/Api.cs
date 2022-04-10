using epAPI.APIs;

namespace epAPI;

public static class Api
{
    public static void ConfigureApi(this WebApplication app) 
    {
        // User - API
        app.MapGet("/Users", UserAPI.GetUsers);
        app.MapGet("/User/{userId}", UserAPI.GetUser);
        app.MapPost("/Users", UserAPI.InsertUser);
        app.MapPut("/Users", UserAPI.UpdateUser);
        app.MapDelete("/Users", UserAPI.DeleteUser);
        // Auth - API
        app.MapPost("/Auth/Register", AuthAPI.RegisterUser);
        app.MapPost("/Auth/Login", AuthAPI.LoginUser);
        app.MapPost("/Auth/Logout", AuthAPI.LogoutUser);
        app.MapGet("/Auth/User", AuthAPI.User);
        // Recupie - API
        app.MapGet("/Recipes", RecipeAPI.GetRecipes);

        // Ingredient - API
        app.MapGet("/Ingredients", IngredientAPI.GetIngredients);
    }
}

