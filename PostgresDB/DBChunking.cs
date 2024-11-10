using Microsoft.EntityFrameworkCore;

namespace PostgresDB
{
    public class DBChunking
    {
        public async void ChunkDB()
        {
            int pageSize = 1000;
            int pageIndex = 0;
            List<Food> foodItems = new List<Food>();

            while (true)
            {
                var chunk = await dbContext.sample_table_food
                    .OrderBy(f => f.Id)
                    .Skip(pageIndex * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                if (!chunk.Any())
                    break;

                foodItems.AddRange(chunk);
                pageIndex++;
            }

        }

    }
}
