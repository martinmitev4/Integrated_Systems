﻿using AdminApplication.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AdminApplication.Controllers
{
    public class ConcertController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ImportUsers(IFormFile file)
        {
            string pathToUpload = $"{Directory.GetCurrentDirectory()}\\files\\{file.FileName}";

            using (FileStream fileStream = System.IO.File.Create(pathToUpload))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }

            List<Concert> concert = getAllConcertsFromFile(file.FileName);
            HttpClient client = new HttpClient();
            string URL = "http://localhost:5054/api/Admin/ImportAllUsers";

            HttpContent content = new StringContent(JsonConvert.SerializeObject(concert), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var result = response.Content.ReadAsAsync<bool>().Result;

            return RedirectToAction("Index", "Order");
        }



        private List<Concert> getAllConcertsFromFile(string fileName)
        {
            List<Concert> concert = new List<Concert>();
            string filePath = $"{Directory.GetCurrentDirectory()}\\files\\{fileName}";

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        concert.Add(new Models.Concert
                        {
                            ConcertName = reader.GetValue(0).ToString(),
                            ConcertDescription = reader.GetValue(1).ToString(),
                            ConcertImage = reader.GetValue(2).ToString(),
                            Rating = (double) reader.GetValue(3)
                        });
                    }

                }
            }
            return concert;

        }

    }
}
