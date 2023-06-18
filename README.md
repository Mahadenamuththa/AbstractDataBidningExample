# Dependency Injection 
![DI_NET](https://user-images.githubusercontent.com/21302583/68460253-58833880-022d-11ea-97b0-795ff0b58bc5.png)

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=PasinduUmayanga_DependencyInjectionExample&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=PasinduUmayanga_DependencyInjectionExample)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=PasinduUmayanga_DependencyInjectionExample&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=PasinduUmayanga_DependencyInjectionExample)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=PasinduUmayanga_DependencyInjectionExample&metric=bugs)](https://sonarcloud.io/summary/new_code?id=PasinduUmayanga_DependencyInjectionExample)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=PasinduUmayanga_DependencyInjectionExample&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=PasinduUmayanga_DependencyInjectionExample)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=PasinduUmayanga_DependencyInjectionExample&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=PasinduUmayanga_DependencyInjectionExample)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=PasinduUmayanga_DependencyInjectionExample&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=PasinduUmayanga_DependencyInjectionExample)
[![Build status](https://ci.appveyor.com/api/projects/status/2ts29stgii1xhhng?svg=true)](https://ci.appveyor.com/project/Mahadenamuththa/dependencyinjectionexample)

[![Build history](https://buildstats.info/appveyor/chart/Mahadenamuththa/dependencyinjectionexample)](https://ci.appveyor.com/project/Mahadenamuththa/dependencyinjectionexample/history)
 
ASP.NET Core is designed from scratch to support Dependency Injection. ASP.NET Core injects objects of dependency classes through constructor or method by using built-in IoC container.

## Benifits of using DI
* Effectively designing services and their dependencies.
* Preventing multi-threading issues.
* Preventing memory-leaks.
* Preventing potential bugs.

## How to use

01. Create Project `ABD.WEB` and Soluation name as `AbstractDataBinding`.
    ![Capture](https://user-images.githubusercontent.com/21302583/68460885-ee6b9300-022e-11ea-8f93-77759adaecc4.PNG)
    
02. Select in Next Screen Web Application Model View Controller application and remove Configure for Https
    ![Capture1](https://user-images.githubusercontent.com/21302583/68460997-3b4f6980-022f-11ea-9afb-9f1c11e1def1.PNG)
    
03. Create .net Core Class libarary `ABD.BusinessService`
    ![Capture2](https://user-images.githubusercontent.com/21302583/68461183-a5680e80-022f-11ea-8983-1b47bf337e54.PNG)

04. Delete Class file in `ABD.BusinessService`
05. Add a Folder `Services` and inside `Services` Create another folder `Abstract` 
    ![image](https://user-images.githubusercontent.com/21302583/68461374-1a3b4880-0230-11ea-9fd9-9ff77562817c.png)
    
06. Create interface named `ICustomerServices` inside Abstract ABD.BusinessService -> Services -> Abstract Change Like this
```cSharp
    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace ABD.BusinessService.Services.Abstract
    {
        public interface ICustomerService
        {
            string getCustomers();
        }
    }
```
07. Now Create Class File named `CustomerServices` in Services ABD.BusinessService -> Services
```cSharp
    using ABD.BusinessService.Services.Abstract;

    namespace ABD.BusinessService.Services
    {
        public class CustomerService : ICustomerService
        {
            public string getCustomers()
            {
                return "pasindu";
            }
        }
    }
```

08. Now Add `ABD.BusinessServiceas` reference to `ABD.WEB`
    ![Capture3](https://user-images.githubusercontent.com/21302583/68461790-1cea6d80-0231-11ea-951e-e66c1b8963b1.PNG)
    
09.Now we can do our DI inside Startup.cs in `ABD.WEB`,Add Followings to Startup.cs->ConfigureServices

   01. First Import Followings
   ```cSharp
       using ABD.BusinessService.Services;
       using ABD.BusinessService.Services.Abstract;
   ```

   02. Then Add Following Line to ConfigureServices()
   ```cSharp
       public void ConfigureServices(IServiceCollection services)
       {
          services.Configure<CookiePolicyOptions>(options =>
          {
             options.CheckConsentNeeded = context => true;
             options.MinimumSameSitePolicy = SameSiteMode.None;
          });


          services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
          //Here We map our Interface and Class
          services.AddScoped<ICustomerService, CustomerService>();
       }
   ```
   
10. Now let use our Interface in Controller
   
   * First Make Inject Iterface in ABD.WEB -> Controller -> HomeController Like This

     ```cSharp   
     private readonly ICustomerService _ICustomerService;
     public HomeController(ICustomerService ICustomerService)
     {
        this._ICustomerService = ICustomerService;
     }
     ```
11. Then Use Injected Variable inside Index()
    ```Csharp
    public IActionResult Index()
    {
      var data=_ICustomerService.getCustomers();
      return View();
    }
    ```
