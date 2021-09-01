using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReadExcelWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using ReadExcelWebMVC.Helper;
using System.Data;

namespace ReadExcelWebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Report()
        {
            LoadData ld = new LoadData();

            List<RecordIndividualDetails> data = new List<RecordIndividualDetails>();
            DataTable dt = ld.LoadDataFromFile();
            foreach (DataRow r in dt.Rows)
            {
                ld.AddData(r, ref data);
            }
            return View(data);
        }
    }
}
