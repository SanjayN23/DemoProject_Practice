namespace Pratice.Models
{
    public class BackupCountryRepository
    {
        public readonly DeletedDataDbContext _db;
        public BackupCountryRepository(DeletedDataDbContext db)
        {
            _db = db;
        }

        public void Retrieve(int id)
        {
            var backupcountry = _db.BackupCountries.Find(id);
            if (backupcountry != null)
            {
                var country = new Country
                {
                    Name = backupcountry.Name,
                    Population = backupcountry.Population,
                    Capital = backupcountry.Capital,
                    Economy = backupcountry.Economy,
                    Currency = backupcountry.Currency,
                    IsDeleted = true
                };

                using (var newdata = new TestDbContext())
                {
                    newdata.Countries.Add(country);
                    newdata.SaveChanges();
                }

                _db.BackupCountries.Remove(backupcountry);
                _db.SaveChanges();
            }
        }

    }
}
