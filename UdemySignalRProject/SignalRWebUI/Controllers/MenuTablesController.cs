using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.DtoLayer.MenuTableDto;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class MenuTablesController : Controller
	{
		
		
			private readonly IHttpClientFactory _httpClientFactory;

			public MenuTablesController(IHttpClientFactory httpClientFactory)
			{
				_httpClientFactory = httpClientFactory;
			}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7284/api/MenuTables");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<SignalRWebUI.Dtos.MenuTablesDtos.ResultMenuTableDto>>(jsonData);
				return View(values);
			}

			return View();
		}
		[HttpGet]
			public IActionResult CreateMenuTable()
			{
				return View();
			}
			[HttpPost]
			public async Task<IActionResult> CreateMenuTable(CreateMenuTableDto createMenuTableDto)
			{
			createMenuTableDto.Status = false;
				var client = _httpClientFactory.CreateClient();
				var jsondata = JsonConvert.SerializeObject(createMenuTableDto);
				StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
				var responseMessage = await client.PostAsync("https://localhost:7284/api/MenuTables", stringContent);
				if (responseMessage.IsSuccessStatusCode)
				{
					return RedirectToAction("Index");
				}
				return View();
			}
			public async Task<IActionResult> DeleteMenuTable(int id)
			{
				var client = _httpClientFactory.CreateClient();
				var responseMessage = await client.DeleteAsync($"https://localhost:7284/api/MenuTables/{id}");
				if (responseMessage.IsSuccessStatusCode)
				{
					return RedirectToAction("Index");
				}
				return View();
			}
		[HttpGet]
		public async Task<IActionResult> UpdateMenuTable(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7284/api/MenuTables/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<SignalRWebUI.Dtos.MenuTablesDtos.UpdateMenuTableDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateMenuTable(SignalRWebUI.Dtos.MenuTablesDtos.UpdateMenuTableDto updateMenuTableDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateMenuTableDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7284/api/MenuTables/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> TableListByStatus()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7284/api/MenuTables");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<SignalRWebUI.Dtos.MenuTablesDtos.ResultMenuTableDto>>(jsonData);
				return View(values);
			}

			return View();
		}
	}
}
