using Hostel.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;

namespace Hostel.MVC.Controllers
{
    public class StudentViewController : Controller
    {
        private readonly HttpClient _httpClient;

        public StudentViewController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("HostelAPI"); // 👈 Uses the named client
        }

        public async Task<IActionResult> Index()
        {
            // ✅ Now this will combine BaseAddress + "student"
            var students = await _httpClient.GetFromJsonAsync<List<StudentViewModel>>("student");

            if (students == null || !students.Any())
            {
                ViewBag.Message = "No data found!";
            }

            return View(students);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"student/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var json = await response.Content.ReadAsStringAsync();
            var student = JsonSerializer.Deserialize<StudentViewModel>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View(student);
        }
    }
}
