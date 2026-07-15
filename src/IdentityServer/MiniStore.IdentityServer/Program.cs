WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
/*
builder.Services.AddDbContext<IdentityServerDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("IdentityServer"));
    options.UseOpenIddict();
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<IdentityServerDbContext>();
builder.Services.AddOpenIddict().AddCore(options => { options.UseEntityFrameworkCore().UseDbContext<IdentityServerDbContext>(); });
*/

WebApplication app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapDefaultControllerRoute();
app.MapRazorPages();
await app.RunAsync();