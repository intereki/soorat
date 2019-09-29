using soorat.api.Data.Interfaces;
using soorat.api.Data.Repositories.Base;
using soorat.api.Models;

namespace soorat.api.Data.Repositories
{
    public class BazarRepository : BaseRepository<Bazar>, IBazar
    {
        public BazarRepository(DataContext context) : base(context)
        {
        }
    }
}