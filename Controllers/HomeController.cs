using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SeparujCertizne.Mappers;
using SeparujCertizne.Models;
using TinyCsvParser;

namespace SeparujCertizne.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View(GetDataForSelectedDistrict());
        }

        public IActionResult Contacts()
        {
            return View("Contacts");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region Helpers
        private SeparationDataModel GetDataForSelectedDistrict()
        {
            IEnumerable<SeparationTermModel> selectectSeparationTermLines = null;

            //initialize CSV parser
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');

            //fetch data for AG report
            #region Separation data processing
            var csvParser = new CsvParser<SeparationTermModel>(csvParserOptions, new SeparationDataMapping());
            var allSeparationRecords = csvParser.ReadFromFile(GetSeparationDataLocalFilePath(), Encoding.UTF8).ToList();
            #endregion Separation data processing      

            #region Validation and filtration
            if (allSeparationRecords != null && allSeparationRecords.Any())
            {
                selectectSeparationTermLines = allSeparationRecords.Where(d => d.Result?.GarbagePickingDate.Date >= DateTime.Now.Date).Select(d => d.Result).OrderBy(d => d.GarbagePickingDate).Take(4).ToList();              
            }
            else return new SeparationDataModel();
            #endregion Validation and filtration

            return new SeparationDataModel {
                SeparationTerms = selectectSeparationTermLines
            };
        }

        private string GetSeparationDataLocalFilePath()
        {
            string webRootPath = _webHostEnvironment.WebRootPath;

            return Path.Combine(webRootPath, "DataFiles/separationData.csv");
        }
        #endregion Helpers
    }
}
