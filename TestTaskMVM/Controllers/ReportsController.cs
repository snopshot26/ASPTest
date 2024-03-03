using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using TestTaskMVM.Models;

namespace TestTaskMVM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public ReportsController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet("total-chats")]
        public async Task<IActionResult> GetTotalChats()
        {
            var filePath = Path.Combine(_env.ContentRootPath, "Data", "total-chats-report.json");

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("JSON file not found");
            }

            var jsonData = await System.IO.File.ReadAllTextAsync(filePath);
            var report = JsonConvert.DeserializeObject<TotalChatsReport>(jsonData);

            return Ok(report);
        }
        [HttpGet("ratings")]
        public async Task<IActionResult> GetRating()
        {
            var filePath = Path.Combine(_env.ContentRootPath, "Data", "rating-report.json");

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("JSON file not found");
            }

            var jsonData = await System.IO.File.ReadAllTextAsync(filePath);
            var report = JsonConvert.DeserializeObject<TotalChatsReport>(jsonData);

            return Ok(report);
        }
        [HttpGet("response-time")]
        public async Task<IActionResult> GetResponseTime()
        {
            var filePath = Path.Combine(_env.ContentRootPath, "Data", "response-time-report.json");

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("JSON file not found");
            }

            var jsonData = await System.IO.File.ReadAllTextAsync(filePath);
            var report = JsonConvert.DeserializeObject<TotalChatsReport>(jsonData);

            return Ok(report);
        }
        [HttpGet("tags")]
        public async Task<IActionResult> GetTags()
        {
            var filePath = Path.Combine(_env.ContentRootPath, "Data", "tags-report.json");

            var jsonString = await System.IO.File.ReadAllTextAsync(filePath);

            var report = JsonConvert.DeserializeObject<TotalChatsReport>(jsonString);

            // Ручная обработка records
            var jsonObject = JObject.Parse(jsonString);
            var recordsObject = jsonObject["records"] as JObject;

            report.Records = new Dictionary<string, Record>();

            foreach (var item in recordsObject)
            {
                string date = item.Key;
                var recordData = item.Value as JObject;

                Record record = new Record();
                record.Tags = new Dictionary<string, object>();
                foreach (var field in recordData)
                {
                    string key = field.Key;
                    object value = ((JValue)field.Value).Value;
                    record.Tags.Add(key, value);
                }

                if (report.Records == null)
                    report.Records = new Dictionary<string, Record>();
                report.Records.Add(date, record);
               
            }

            return Ok(report);

        }
    }
}
