using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using GolfingStats.Models;
using SQLite;


namespace GolfingStats
{
    public class GolfstatsRepository
    {
        SQLiteAsyncConnection conn;
        public string StatusMessage { get; set; }

        public GolfstatsRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<RoundModel>().Wait();
        }

        public async Task AddNewRound(RoundModel newRound)
        {
            int result = 0;
            try
            {
                //basic validation to ensure a name was entered
                //if (string.IsNullOrEmpty(name))
                //    throw new Exception("Valid name required");

                result = await conn.InsertAsync((RoundModel)newRound);

                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, newRound.GolfCourse);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", newRound.GolfCourse, ex.Message);
            }
        }

        public async Task<List<RoundModel>> GetAllRounds()
        {
            try
            {
                return await conn.Table<RoundModel>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<RoundModel>();
        }
    }
}
