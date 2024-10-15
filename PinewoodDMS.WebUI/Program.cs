var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
// Add services to the container.
builder.Services.AddRazorPages();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Use(async (context, next) =>
{
    if (context.Request.Cookies[".AspNetCore.Session"] != null)
    {
        context.Response.Cookies.Delete(".AspNetCore.Session");
    }
    await next();
});

app.MapGet("/", context =>
{
    context.Response.Redirect("/Customers");
    return Task.CompletedTask;
});

app.Run();
