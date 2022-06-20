using Ocelot.DependencyInjection;
using Ocelot.Provider.Consul;
using Ocelot.Provider.Polly;
using WKS_API.Extenions;
using Ocelot.Cache.CacheManager;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureAppConfiguration((hostingContext, builder) =>
{
    //builder.SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
    //.AddJsonFile("Ocelot.json");
}).UseUrls("http://*:2000");


// Add services to the container.

IConfiguration configuration = new ConfigurationBuilder()
                                  .AddJsonFile("appsettings.json")
                                  .Build();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddPolicy("any", build =>
    {
        build.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});


//builder.Services.AddOcelot()
//                .AddPolly()
//                .AddConsul()
//                .AddCacheManager(x => { x.WithDictionaryHandle(); }) // ��ӱ��ػ���
//                .AddCOnfigStoredInMysql(configuration["apigateway"]);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c => {

});

app.UseCors("any");

#region ������չ�м������&&�������
var ocelotConfig = new OcelotPipelineConfiguration()
{
    // ��չΪ��������ַ
    PreErrorResponderMiddleware = async (ctx, next) =>
    {
        if (ctx.Request.Path.Equals(new PathString("/")))
        {
            await ctx.Response.WriteAsync("ok");
        }
        else
        {
            await next.Invoke();
        }
    },
};
//app.UseOcelot(ocelotConfig).Wait();
#endregion

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

