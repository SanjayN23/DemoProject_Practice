using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Pratice.Models
{
    public class CountryRepository
    {
        private readonly TestDbContext _context;

        public CountryRepository(TestDbContext context)
        {
            _context = context;
        }

        public List<Country> GetAllCountries()
        {
            return _context.Countries.Where(c => !c.IsDeleted).ToList();
        }

        public Country GetCountryById(int id)
        {
            return _context.Countries.FirstOrDefault(c => c.Id == id && !c.IsDeleted);
        }

        public void AddCountry(Country country)
        {
            country.IsDeleted = false;
            _context.Countries.Add(country);
            _context.SaveChanges();
        }

        public void UpdateCountry(Country country)
        {
            _context.Countries.Update(country);
            _context.SaveChanges();
        }

        public void DeleteCountry(int id)
        {
            var country = _context.Countries.Find(id);

            if (country != null)
            {
                country.IsDeleted = true;
                _context.SaveChanges();
            }
        }

        public List<Country> ListDeletedCountries()
        {
            return _context.Countries.Where(c => c.IsDeleted).ToList();
        }

        public void RetrieveCountries(int id)
        {
            var country =_context.Countries.Find(id);
            if(country != null)
            {
                country.IsDeleted = false;
                _context.SaveChanges();
            }
        }

        //public void ConfirmedDelete(int id)
        //{
        //    var country = _context.Countries.Find(id);
        //    if (country != null)
        //    {
        //        _context.Countries.Remove(country);
        //        _context.SaveChanges();
        //    }
        //}


        public void ConfirmedDelete(int id)
        {
            // Find the country to delete
            var country = _context.Countries.Find(id);

            if (country != null)
            {
                // Create a copy of the data to be deleted
                var backupCountry = new BackupCountry
                {
                    // Copy relevant properties from the original country
                    // For example, assuming BackupCountry has the same structure as Country
                    
                    Name = country.Name,
                    Population = country.Population,
                    Capital = country.Capital,
                    Economy = country.Economy,
                    Currency = country.Currency,
                    IsDeleted = true,
                    BackupDateTime = DateTime.Now
                    // Copy other properties as needed
                };

                // Create a new instance of BackupDbContext
                using (var backupContext = new DeletedDataDbContext())
                {
                    // Insert the copy into the backup table
                    backupContext.BackupCountries.Add(backupCountry);

                    // Save changes to the backup database
                    backupContext.SaveChanges();
                }

                // Remove the original data from the Countries table
                _context.Countries.Remove(country);

                // Save changes to the original database
                _context.SaveChanges();
            }
        }

        public List<Country> SearchCountries(string searchTerm)
        {
            return _context.Countries
                .Where(c => !c.IsDeleted && (c.Name.Contains(searchTerm) || c.Capital.Contains(searchTerm)))
                .ToList();
        }
    }
}
