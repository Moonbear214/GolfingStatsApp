using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

using GolfingStats.Models;
using GolfingStats.Models.ShotModels;
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

            CreateAllTables();
        }

        private async void CreateAllTables()
        {
            await conn.CreateTableAsync<RoundModel>();
            await conn.CreateTableAsync<HoleModel>();
            await conn.CreateTableAsync<ShotModel>();
            await conn.CreateTableAsync<DriveModel>();
            await conn.CreateTableAsync<FairwayModel>();
            await conn.CreateTableAsync<ChipModel>();
            await conn.CreateTableAsync<PuttModel>();
        }

        //Methods for adding to local storage data for all classes (rounds, holes, shots)
        //========================================================================================================================================================================
        public async Task<int> AddNewRound(RoundModel round)
        {
            try
            {
                await conn.InsertAsync(round);
                return round.Id;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Abort! ..at add new round (Golfstats Repository).. {0}", ex.Source);
                throw new Exception(ex.Message);
            }
        }

        public async Task<HoleModel> AddOneHole(HoleModel hole)
        {
            try
            {
                await conn.InsertAsync(hole);
                return hole;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Abort! ..at add new round (Golfstats Repository).. {0}", ex.Source);
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<HoleModel>> AddRoundHoles(IEnumerable<HoleModel> holes)
        {
            try
            {
                await conn.InsertAllAsync(holes);
                return holes;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Abort! ..at add new round (Golfstats Repository).. {0}", ex.Source);
                throw new Exception(ex.Message);
            }
        }

        
        public async Task<ShotModel> AddNewShot(ShotModel shot)
        {
            try
            {
                await conn.InsertAsync(shot);
                return shot;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Abort! ..at add new round (Golfstats Repository).. {0}", ex.Source);
                throw new Exception(ex.Message);
            }
        }
        //========================================================================================================================================================================

        //Methods for returning all local storage data for given class (round, holes, shots)
        //========================================================================================================================================================================
        public async Task<List<RoundModel>> GetAllRounds()
        {
            try
            {
                return await conn.Table<RoundModel>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<HoleModel>> GetAllHoles()
        {
            try
            {
                return await conn.Table<HoleModel>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                throw new Exception(ex.Message);
            }
        }
        
        public async Task<List<ShotModel>> GetAllShots()
        {
            try
            {
                return await conn.Table<ShotModel>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                throw new Exception(ex.Message);
            }
        }
        //========================================================================================================================================================================


        //Methods for returning all local storage data for given class (round, holes, shots)
        //========================================================================================================================================================================
        public async void ClearLocalStorage()
        {
            await conn.ExecuteAsync("DELETE FROM Rounds");
            await conn.ExecuteAsync("DELETE FROM Holes");
            await conn.ExecuteAsync("DELETE FROM Shots");
        }
        //========================================================================================================================================================================
    }
}
