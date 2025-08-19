using Hostel.Core.DTOs;
using Hostel.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Hostel.MVC.Controllers
{
    public class StudentViewController : Controller
    {
        private readonly HttpClient _httpClient;

        public StudentViewController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("HostelAPI");
            // 👆 Make sure in Program.cs you configured:
            // builder.Services.AddHttpClient("HostelAPI", c => c.BaseAddress = new Uri("https://localhost:7128/api/"));
        }

        // ✅ GET: StudentView
        public async Task<IActionResult> Index()
        {
            var students = await _httpClient.GetFromJsonAsync<List<StudentViewModel>>("student");

            if (students == null || !students.Any())
            {
                ViewBag.Message = "No students found!";
            }

            return View(students);
        }

        // ✅ GET: StudentView/Details/5
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

        // ✅ GET: StudentView/Create
        public IActionResult Create()
        {
            return View();
        }

        // ✅ POST: StudentView/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentRequestDTO studentRequestDTO)
        {
            if (!ModelState.IsValid) return View(studentRequestDTO);

            var response = await _httpClient.PostAsJsonAsync("student", studentRequestDTO);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Failed to create student.");
                return View(studentRequestDTO);
            }

            return RedirectToAction(nameof(Index));
        }

        // ✅ GET: StudentView/Edit/5
        public async Task<IActionResult> Edit(int id)
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

            if (student == null) return NotFound();

            // Map to request DTO
            var dto = new StudentRequestDTO
            {
                StudentName = student.StudentName,
                StudentDepartment = student.StudentDepartment
            };

            ViewBag.StudentId = student.StudentId;
            return View(dto);
        }

        // ✅ POST: StudentView/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentRequestDTO studentRequestDTO)
        {
            if (!ModelState.IsValid) return View(studentRequestDTO);

            var response = await _httpClient.PutAsJsonAsync($"student/{id}", studentRequestDTO);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Failed to update student.");
                return View(studentRequestDTO);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
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

            return View(student); // shows Delete.cshtml confirmation page
        }

        // ✅ POST: Confirm delete
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"student/{id}");

            if (!response.IsSuccessStatusCode)
            {
                TempData["Error"] = "Failed to delete student.";
                return RedirectToAction(nameof(Index));
            }

            TempData["Message"] = "Student deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
