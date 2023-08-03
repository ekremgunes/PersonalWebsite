using gunesekremcom.Data.Context;
using gunesekremcom.Data.Entities;

namespace gunesekremcom.Tools.DataSeed
{

    public class SeedStatisticData
    {
        private readonly DatabaseContext _context;

        public SeedStatisticData()
        {
            _context = new DatabaseContext();
        }
        public void UpdateDates()
        {
            var oldestStat = _context.Statistics.OrderBy(s => s.Date).FirstOrDefault();
            var newestStat = _context.Statistics.OrderByDescending(s => s.Date).FirstOrDefault();

            if (oldestStat != null)
            {
                _context.Statistics.Remove(oldestStat);
                _context.SaveChanges();
            }
            if (newestStat != null)
            {
                _context.Settings.First().VisitorCount += newestStat!.VisitorCount;
            }

            // Yeni kaydı ekle
            var newStat = new Statistic
            {
                Date = DateTime.Now,
                VisitorCount = 0
            };
            _context.Statistics.Add(newStat);
            _context.SaveChanges();

        }

        public async Task Seed()
        {

            if (!_context.Statistics.Any())
            {
                // Bugünden geriye doğru 30 gün boyunca seed veri oluşturulur
                DateTime currentDate = DateTime.Today;
                for (int i = 0; i < 30; i++)
                {
                    var statistic = new Statistic
                    {
                        Date = currentDate.AddDays(-i),
                        VisitorCount = 0
                    };

                    await _context.Statistics.AddAsync(statistic);
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}
