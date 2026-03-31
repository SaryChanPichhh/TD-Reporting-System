using BC.ACCOUNTING.CORE.Entities;
using BC.ACCOUNTING.INFRASTRUCTURE;
using BC.ACCOUNTING.REPORT.DataSources;
using BC.ACCOUNTING.REPORT.Helper.ExpressionFunction;
using BC.ACCOUNTING.REPORT.IService.ReportToken;
using BC.ACCOUNTING.REPORT.Services.ReportToken;
using DevExpress.AspNetCore;
using DevExpress.AspNetCore.Reporting;
using DevExpress.Data.Entity;
using DevExpress.Data.Filtering;
using DevExpress.XtraReports.Web.Extensions;
using DevExpress.XtraReports.Web.WebDocumentViewer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Net;
namespace BC.ACCOUNTING.REPORT
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("SharedConfig/appsettings.json", optional: true, reloadOnChange: true)  // Shared Config
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)             // API-Specific Config
                .AddEnvironmentVariables();
            builder.Build();
            services.AddDevExpressControls();
            services.RegisterServices();
            services.Configure<ReportSettings>(Configuration.GetSection("ReportSettings"));
            services.AddScoped<ReportStorageWebExtension, CustomReportStorageWebExtension>();
            services.AddScoped<IConnectionStringsProvider, CustomSqlDataSourceProvider>();
            services.AddTransient<IWebDocumentViewerReportResolver, CustomWebDocumentViewerReportResolver>();
            services.AddTransient<ITokenValidatorService, TokenValidatorService>();
           


            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
            });

            //reports template
            services.AddScoped<DailySaleReport>();
            services.AddScoped<InventoryReport>();
            services.AddScoped<PurchaseOrderReport>();
            services.AddScoped<SaleInvoiceReport>();
            services.AddScoped<ReportExportService>();
            services.AddScoped<DailySale80Report>();
            services.AddScoped<SaleReport>();
            services.AddScoped<POSSaleListingReport>();

            //var jwtKey = Configuration["Jwt:Key"];
            //var jwtIssuer = Configuration["Jwt:Issuer"];
            //var jwtAudience = Configuration["Jwt:Audience"];

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,
            //            ValidIssuer = jwtIssuer,
            //            ValidAudience = jwtAudience,
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
            //        };
            //    });

            services.AddHttpContextAccessor();
            services.AddScoped<ReadJsonBody>(); services.AddControllers(options =>
                {
                    options.Filters.Add<ReadJsonBody>();
                })
                .AddNewtonsoftJson(options =>
                {
                    
                    options.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            services.AddMemoryCache();
            services
                .AddControllersWithViews();
            services.AddDistributedMemoryCache(); // ? Required for Session
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // ? Keep session for 30 mins
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddHttpClient("images", c =>
            {
                c.Timeout = TimeSpan.FromSeconds(10);
            }).ConfigurePrimaryHttpMessageHandler(() => new SocketsHttpHandler
            {
                MaxConnectionsPerServer = 64,
                AutomaticDecompression = DecompressionMethods.All,
                PooledConnectionLifetime = TimeSpan.FromMinutes(5)
            });

            services.ConfigureReportingServices(configurator =>
            {

                configurator.ConfigureReportDesigner(designerConfigurator =>
                {
                    designerConfigurator.RegisterDataSourceWizardConfigFileConnectionStringsProvider();
                    designerConfigurator.RegisterObjectDataSourceWizardTypeProvider<ObjectDataSourceWizardCustomTypeProvider>();
                    designerConfigurator.RegisterObjectDataSourceConstructorFilterService<CustomObjectDataSourceConstructorFilterService>();
                    //designerConfigurator.RegisterDataSourceWizardJsonConnectionStorage<T>();

                });
                configurator.ConfigureWebDocumentViewer(viewerConfigurator =>
                {
                    viewerConfigurator.UseCachedReportSourceBuilder();
                    
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(EmployeeList));
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(ItemSaleReportDataSource)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(InvoiceReportDto)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(Aging)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(InventoryReportDto)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(FlatPurchaseOrderRow)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(FlatInvoiceRow)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(POListingDTO)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(SaleDto)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(ArDepreciationDto)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(ArPaidDto)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(ArCustomerDto)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(ArCustomerSummaryDto)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(ArCustomerSumInvDto)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(ArCustomerInvoiceDto)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(ArCustomerPaidDto)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(DailyClosingInventoryDto)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(DailyClosingsDto)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(InvoiceItemDto)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(ImageItem)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(POSSaleInvoiceDto)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(POSSaleListingByInvoiceDto)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(POSSaleListingMovementDto)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(SaleListingModel)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(POSSaleListingReportDto)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(RESSaleInvoiceDto)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(RESSaleInventoryDto)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(InventoryDto)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(RESSaleListingInvoiceDto));
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(POSSalelistingSummaryDto)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(RESPurchaseOrderDto)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(RESFlatternPurchaseOrderRow)); 
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(RESSaleListingMovementDto));
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(RESItemDto));
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(POSItemDto));
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(MBSaleListingCustomereDto));
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(InventoryExpiredDto));
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(RESSaleReceiptDto));
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(ClosingInventoryDto));
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(NOSaleInvoiceDto));
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(CreditNoteDto));
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(CreditNoteFlattenDto));
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(MBSaleInvoiceSummaryDto));
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(RESBZSaleInvoiceDto));
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(MBSaleListingSummaryDto));
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(IncomeExpenseDto));
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(ItemInfoDto));
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(MBCustomersDto));
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(ARCustomerInvoiceDetailDto));
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(APCustomerSummaryDto));
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(APPaidDto));
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(APSupplierInvoiceDetailDto));
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(POSPOListingDto));
            DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(DailyClosingInventoryDetailDto));

            // Register Built-in and Custom Expression Functions for DevExpress Reports

            if (CriteriaOperator.GetCustomFunction("HasKhmer") == null)
            {
                CriteriaOperator.RegisterCustomFunction(new HasKhmerLangFunction());
            }

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("App", "Reporting")
                .WriteTo.File(
                    path: @"D:\.NetAPI\Reports\Log\LogInformationFor-.txt",
                    rollingInterval: RollingInterval.Day,
                    fileSizeLimitBytes:50_000_000, 
                    rollOnFileSizeLimit: true,
                    retainedFileCountLimit: 20,
                    shared: true,
                    flushToDiskInterval: TimeSpan.FromSeconds(1)
                    )
                .CreateLogger();
            app.UseMiddleware<ExceptionLoggingMiddleware>();
            app.UseMiddleware<ErrorResponseLoggingMiddleware>();
            app.UseSerilogRequestLogging();
            DevExpress.XtraReports.Configuration.Settings.Default.UserDesignerOptions.DataBindingMode = DevExpress.XtraReports.UI.DataBindingMode.Expressions;
            app.UseDevExpressControls();
            
            System.Net.ServicePointManager.SecurityProtocol |= System.Net.SecurityProtocolType.Tls12;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

         //   app.UseAuthentication();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
