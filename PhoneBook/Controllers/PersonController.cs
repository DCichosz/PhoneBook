using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBook.Controllers
{
	public class PersonController : Controller
	{
		[HttpGet]
		public IActionResult Index(int id = 1, string name = "")
		{
			int count = SourceManager.GetCount(name);

			int prev = id - 1;
			int next = id + 1;

			if (id <= 1)
			{
				prev = 1;
			}

			if (count <= id * 5)
			{
				next = id;
			}

			ViewBag.Title = "Home";
			ViewBag.Name = name;
			ViewBag.Prev = prev;
			ViewBag.Next = next;
			ViewBag.ID = id;

			return View(SourceManager.Get(id, 5, name));
		}

		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.Title = "Add";
			return View();
		}

		[HttpPost]
		public IActionResult Add(PersonModel personModel)
		{
			if (ModelState.IsValid)
			{
				SourceManager.Add(personModel);
				TempData["mess"] = "Added";
				TempData["alert"] = "alert alert-success";
				return Redirect("/Person/Index");
			}
			return View(personModel);
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			ViewBag.Title = "Edit";

			var person = SourceManager.GetPerson(id);

			if (person == null)
				return NotFound();

			return View(person);
		}

		[HttpPost]
		public IActionResult Edit(PersonModel personModel)
		{
			if (ModelState.IsValid)
			{
				SourceManager.Update(personModel);
				TempData["mess"] = "Edited";
				TempData["alert"] = "alert alert-warning";
				return Redirect("/Person/index");
			}
			return View(personModel);
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			ViewBag.Title = "Delete Person";

			var person = SourceManager.GetPerson(id);

			if (person == null)
				return NotFound();

			return View(person);
		}

		[HttpPost]
		public IActionResult Delete(PersonModel personModel)
		{
			SourceManager.Delete(personModel.ID);
			TempData["mess"] = "Deleted";
			TempData["alert"] = "alert alert-danger";
			return Redirect("/Person/index");
		}
	}
}
