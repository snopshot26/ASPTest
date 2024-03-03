using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestTaskMVM.Models;

namespace TestTaskMVM.Controllers
{
    public class ProjectsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            TotalChatsReport projects = new TotalChatsReport();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44357/api/projectsapi"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    projects = JsonConvert.DeserializeObject<TotalChatsReport>(apiResponse);
                }
            }
            return View(projects);
        }
    }
}
