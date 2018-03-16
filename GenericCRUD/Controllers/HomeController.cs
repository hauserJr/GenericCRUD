using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GenericCRUD.Models;
using Microsoft.Extensions.DependencyInjection;
using static GenericCRUD.DBServices;
using GenericCRUD.Models.SYSTEM;
using Microsoft.EntityFrameworkCore;

namespace GenericCRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ServiceProvider provider;
        public HomeController()
        {
            this.provider = new ServiceCollection()
                                .AddScoped<IDBAction<DBRepo>, dbCRUD<DBRepo>>()
                                .AddScoped<CoreContext>()
                                .AddDbContext<CoreContext>(options => options.UseSqlServer(SysBase.testConn1))
                                .BuildServiceProvider();
        }
        public IActionResult Index()
        {
            /*Fake Data*/
            UserAccount _ua = new UserAccount() { Id = 3,Account = "free576002@gmail.com",Pwd="1234"};
            //_ua.Account = "A2456@g.com";
            //_ua.Pwd = "123456";

            provider.GetService<IDBAction<DBRepo>>().GetAllData(new UserAccount());


            /***/
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
