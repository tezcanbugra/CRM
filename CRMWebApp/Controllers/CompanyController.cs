using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CRMWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace CRMWebApp.Controllers
{

    [Authorize]

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


		public ViewResult GetCompany() => View();

		[HttpPost]
		public async Task<IActionResult> GetCompany(int id)
		{
			Company company = new Company();
			using (var httpClient = new HttpClient())
			{

				using (var response = await httpClient.GetAsync("https://localhost:7228/api/Company/" + id))
				{
					if (response.StatusCode == System.Net.HttpStatusCode.OK)
					{
						string apiResponse = await response.Content.ReadAsStringAsync();
						company = JsonConvert.DeserializeObject<Company>(apiResponse);
					}
					else
						ViewBag.StatusCode = response.StatusCode;
				}
			}

            return View(company);

        }

		public ViewResult AddCompany() => View();

		[HttpPost]
		public async Task<IActionResult> AddCompany(Company company)
		{
			Company receivedCompany = new Company();
			using(var httpClient = new HttpClient())
			{
				StringContent content = new StringContent(JsonConvert.SerializeObject(company), Encoding.UTF8, "application/json");
				using(var response = await httpClient.PostAsync("https://localhost:7228/api/Company", content))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					receivedCompany = JsonConvert.DeserializeObject<Company>(apiResponse);
				}

			}
			return View(receivedCompany);
		}

		public async Task<IActionResult> UpdateCompany(int id)
		{
			Company company = new Company();
			using(var httpClient = new HttpClient())
			{
				using ( var response = await httpClient.GetAsync("https://localhost:7228/api/Company/" + id))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					company = JsonConvert.DeserializeObject<Company>(apiResponse);

				}
			}
			return View(company);
		}

		[HttpPost]

        public async Task<IActionResult> UpdateCompany(Company company)
        {
            Company receivedCompany = new Company();
            using (var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(company.Id.ToString()), "Id");
                content.Add(new StringContent(company.Title.ToString()), "Title");

                content.Add(new StringContent(company.Contact.ToString()), "Contact");
                content.Add(new StringContent(company.Phone.ToString()), "Phone");

                content.Add(new StringContent(company.Email.ToString()), "Email");
                content.Add(new StringContent(company.Status.ToString()), "Status");

                using (var response = await httpClient.PutAsync("https://localhost:7228/api/Company", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
					receivedCompany = JsonConvert.DeserializeObject<Company>(apiResponse);

                }
            }

			return View(receivedCompany);
        }

		[HttpPost]
		public async Task<IActionResult> DeleteCompany(int CompanyId)
		{
			using (var httpClient = new HttpClient())
			{
				using(var response = await httpClient.DeleteAsync("https://localhost:7228/api/Company/" + CompanyId))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
				}

            }
			return RedirectToAction("Index");
		}
    }
}

