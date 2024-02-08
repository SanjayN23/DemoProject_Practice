using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pratice.Models;
using System;
using System.Collections.Generic;

namespace Pratice.Controllers
{
    [Authorize]
    public class CountryController : Controller
    {
        private readonly CountryRepository _repositoryCountry;

        public CountryController(CountryRepository repositoryCountry)
        {
            _repositoryCountry = repositoryCountry;
        }

        // GET: Country
        public ActionResult Index()
        {
            List<Country> countries = _repositoryCountry.GetAllCountries();
            return View(countries);
        }

        // GET: Country/Details/5
        public ActionResult Details(int id)
        {
            Country country = _repositoryCountry.GetCountryById(id);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositoryCountry.AddCountry(country);
                    return RedirectToAction(nameof(Index));
                }
                return View(country);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return View("Index");
            }
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int id)
        {
            Country country = _repositoryCountry.GetCountryById(id);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // POST: Country/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    country.Id = id; // Set the ID to match the edited entity
                    _repositoryCountry.UpdateCountry(country);
                    return RedirectToAction(nameof(Index));
                }
                return View(country);
            }
            catch
            {
                return View();
            }
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int id)
        {
            Country country = _repositoryCountry.GetCountryById(id);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // POST: Country/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositoryCountry.DeleteCountry(id);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeletedCountries()
        {
            var deletedCountries =_repositoryCountry.ListDeletedCountries();
            return View(deletedCountries);
        }

        public ActionResult RetrieveCountry(int id)
        {
            Country country= _repositoryCountry.GetCountryById(id);

                if (country == null)
            {
                return NotFound();
            }
                return View(country);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
         public ActionResult RetrieveCountry(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositoryCountry.RetrieveCountries(id);
                }
                return RedirectToAction(nameof(Index));
            }

            catch { return View(); }
        }

        public ActionResult ConfirmDelete(int id)
        {
            Country country=_repositoryCountry.GetCountryById(id); 
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositoryCountry.ConfirmedDelete(id);
                }
                return RedirectToAction("DeletedCountries");
            }
            catch { return RedirectToAction("Index"); }
        }

        //[HttpPost]
        //public IActionResult Search(string searchTerm)
        //{
        //    // Perform the search
        //    var searchResults = _countryRepository.SearchCountries(searchTerm);

        //    // Pass the search results to the view
        //    return View("Index", searchResults);
        //}
    }
}
