using Microsoft.AspNetCore.Mvc;
using SchoolWebAppClient.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SchoolWebAppClient.Controllers
{
    public class SchoolClientController : Controller
    {
        private readonly HttpClient _httpClient;

        public SchoolClientController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7005");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IActionResult> GetAllSchools()
        {
            var response = await _httpClient.GetAsync("api/SchoolsRepo/get-all-schools");
            if (!response.IsSuccessStatusCode)
            {
                return View(new List<SchoolClient>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var schools = JsonSerializer.Deserialize<List<SchoolClient>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(schools);
        }

        public async Task<IActionResult> GetSchoolById(int id)
        {
            var response = await _httpClient.GetAsync($"api/SchoolsRepo/get-school-by-id/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var json = await response.Content.ReadAsStringAsync();
            var school = JsonSerializer.Deserialize<SchoolClient>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(school);
        }

        public async Task<IActionResult> GetSchoolByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return RedirectToAction(nameof(GetAllSchools));
            }

            var response = await _httpClient.GetAsync($"api/SchoolsRepo/search-by-name/{name}");
            if (!response.IsSuccessStatusCode)
            {
                return View(new List<SchoolClient>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var schools = JsonSerializer.Deserialize<List<SchoolClient>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            ViewBag.SearchTerm = name;
            return View(schools);
        }

        public IActionResult CreateSchool()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSchool(SchoolClient schoolClient)
        {
            if (!ModelState.IsValid)
            {
                return View(schoolClient);
            }

            var json = JsonSerializer.Serialize(schoolClient);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/SchoolsRepo/create-school", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(GetAllSchools));
            }

            ModelState.AddModelError(string.Empty, "Erreur lors de la creation de l'ecole.");
            return View(schoolClient);
        }

        public async Task<IActionResult> EditSchool(int id)
        {
            var response = await _httpClient.GetAsync($"api/SchoolsRepo/get-school-by-id/{id}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var school = JsonSerializer.Deserialize<SchoolClient>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(school);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSchool(int id, SchoolClient schoolClient)
        {
            if (id != schoolClient.Id)
            {
                return BadRequest();
            }

            var json = JsonSerializer.Serialize(schoolClient);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/SchoolsRepo/edit-school/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(GetAllSchools));
            }

            ModelState.AddModelError(string.Empty, "Erreur lors de la modification de l'ecole.");
            return View(schoolClient);
        }

        public async Task<IActionResult> DeleteSchool(int id)
        {
            var response = await _httpClient.GetAsync($"api/SchoolsRepo/get-school-by-id/{id}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var school = JsonSerializer.Deserialize<SchoolClient>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(school);
        }

        [HttpPost, ActionName("DeleteSchool")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSchoolConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/SchoolsRepo/delete-school/{id}");
            return RedirectToAction(nameof(GetAllSchools));
        }
    }
}

