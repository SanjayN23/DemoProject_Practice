using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pratice.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pratice.Controllers
{
    [Authorize]
    public class BackupCountryController : Controller
    {
        private readonly DeletedDataDbContext _dbContext;
        

        public BackupCountryController(DeletedDataDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        public IActionResult Index()
        {
            List<BackupCountry> list = _dbContext.BackupCountries.ToList();
            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Retrieve(int id, IFormCollection collection)
        {
            var backupCountry = _dbContext.BackupCountries.Find(id);

            if (backupCountry != null)
            {
                var country = new Country
                {
                   
                    Name = backupCountry.Name,
                    Population = backupCountry.Population,
                    Capital = backupCountry.Capital,
                    Economy = backupCountry.Economy,
                    Currency = backupCountry.Currency,
                    IsDeleted = true
                };

                using (var newDb = new TestDbContext())
                {
                    newDb.Countries.Add(country);
                    newDb.SaveChanges();
                }

                _dbContext.BackupCountries.Remove(backupCountry);
                _dbContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }

}

