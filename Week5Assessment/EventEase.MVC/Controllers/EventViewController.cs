using EventEase.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;

namespace EventEase.MVC.Controllers
{
    public class EventViewController : Controller
    {
        private readonly HttpClient _httpClient;

        public EventViewController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("EventEaseAPI");
        }

        // GET: EventView
        public async Task<IActionResult> Index()
        {
            var events = await _httpClient.GetFromJsonAsync<IEnumerable<EventViewModel>>("Event");
            return View(events);
        }

        // GET: EventView/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var ev = await _httpClient.GetFromJsonAsync<EventViewModel>($"Event/{id}");
            if (ev == null)
            {
                return NotFound();
            }
            return View(ev);
        }
    }
}
