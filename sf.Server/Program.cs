using System.Text;
using JWT.Extensions.AspNetCore;
using Microsoft.IdentityModel.Tokens;
using sf.Server.Middlewares;
using ILogger = Serilog.ILogger;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(".logs/latest.log", rollingInterval: RollingInterval.Day)
            .WriteTo.File($".logs/{DateTime.Now:dd-MM-yyyy}.log")
            .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddDbContext<SfContext>(
    options =>
        options.UseMySql(
            builder.Configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 0, 23))
        )
);

builder.Services.AddControllers()
       .AddNewtonsoftJson(
            options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                options.SerializerSettings.Converters.Add(new IsoDateTimeConverter());
                options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                options.SerializerSettings.Formatting = Formatting.Indented;
                options.SerializerSettings.TypeNameHandling = TypeNameHandling.None;
                options.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
            });

builder.Services.AddApiVersioning(
    options =>
    {
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.DefaultApiVersion = new(1, 0);
        options.ReportApiVersions = true;
        options.ApiVersionReader = new UrlSegmentApiVersionReader();
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc(
            "v1",
            new()
                { Title = "SportsFestApi", Version = "v1" });
    });

builder.Services.AddSwaggerGenNewtonsoftSupport();
builder.Services.AddOpenApiDocument();

builder.Services.AddSerilog();
builder.Services.AddScoped<ILogger>(
    provider =>
        new LoggerConfiguration()
           .WriteTo.Console()
           .WriteTo.File(".logs/latest.log", rollingInterval: RollingInterval.Day)
           .WriteTo.File($".logs/{DateTime.Now:dd-MM-yyyy}.log")
           .CreateLogger());

builder.Services.AddScoped<ResultService>();

builder.Services.AddScoped<DataBaseService<User>>();
builder.Services.AddScoped<DataBaseService<Class>>();
builder.Services.AddScoped<DataBaseService<Discipline>>();
builder.Services.AddScoped<DataBaseService<Entry>>();
builder.Services.AddScoped<DataBaseService<Location>>();
builder.Services.AddScoped<DataBaseService<Student>>();
builder.Services.AddScoped<DataBaseService<School>>();
builder.Services.AddScoped<DataBaseService<CampaignManager>>();
builder.Services.AddScoped<DataBaseService<CampaignJudge>>();
builder.Services.AddScoped<DataBaseService<Tutor>>();

builder.Services.AddScoped<UserController>();
builder.Services.AddScoped<ClassController>();
builder.Services.AddScoped<DisciplineController>();
builder.Services.AddScoped<EntryController>();
builder.Services.AddScoped<LocationController>();
builder.Services.AddScoped<StudentController>();
builder.Services.AddScoped<SchoolController>();
builder.Services.AddScoped<ManagerController>();
builder.Services.AddScoped<JudgeController>();
builder.Services.AddScoped<TutorController>();


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

var readmePath = Path.Combine(app.Environment.ContentRootPath, "README.md");
var changelogPath = Path.Combine(app.Environment.ContentRootPath, "CHANGELOG.md");
app.UseMiddleware<ReadmeMiddleware>(readmePath, "/swagger/readme.md");
app.UseMiddleware<ReadmeMiddleware>(changelogPath, "/swagger/changelog.md");

// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseOpenApi();
    app.UseDeveloperExceptionPage();
// }

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapFallbackToFile("/index.html");
app.Run();