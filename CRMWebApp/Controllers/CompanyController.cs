using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CRMWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRMWebApp.Controllers
{
	public class CompanyController:Controller
	{
		public async Task<IActionResult> Index()
		{
			List<Company> CompanyList = new List<Company>();

			using(var httpClient = new HttpClient())
			{
				using (var response = await httpClient.GetAsync("https://localhost:7228/api/Company"))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					CompanyList = JsonConvert.DeserializeObject<List<Company>>(apiResponse);
				}
			}
			return View(CompanyList);
		}

		
		
	}
}

