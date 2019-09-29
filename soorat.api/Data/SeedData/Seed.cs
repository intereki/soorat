using soorat.api.Models;

namespace soorat.api.Data.SeedData
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            Bazar bazar = new Bazar 
            {
                Name = "چراغ برق",
                Address = "میدان بهارستان - خیابان اکباتان"
            };

            _context.Bazar.Add(bazar);
            _context.SaveChanges();
        }
    }
}