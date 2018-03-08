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
            await conn.CreateTableAsync<DriveModel>();
            await conn.CreateTableAsync<FairwayModel>();
            await conn.CreateTableAsync<ChipModel>();
            await conn.CreateTableAsync<PuttModel>();
        }

        //Methods for adding to local storage data for all classes (rounds, holes, shots)
        //========================================================================================================================================================================

        //Rounds
        //==========================================================
        public async Task<int> AddNewRound(RoundModel round)
        {
            try
            {
                await conn.InsertAsync(round);
                return round.Id;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                throw new Exception(string.Format("Exception at: {0}. Message: {1}", ex.Source, ex.Message));
            }
        }
        //==========================================================

        //Holes
        //==========================================================
        public async Task<HoleModel> AddOneHole(HoleModel hole)
        {
            try
            {
                await conn.InsertAsync(hole);
                return hole;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                throw new Exception(string.Format("Exception at: {0}. Message: {1}", ex.Source, ex.Message));
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
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                throw new Exception(string.Format("Exception at: {0}. Message: {1}", ex.Source, ex.Message));
            }
        }
        //==========================================================

        //Shots
        //==========================================================

            //Drive
        //================================
        public async Task<DriveModel> AddNewShot(DriveModel shot)
        {
            try
            {
                await conn.InsertAsync(shot);
                return shot;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                throw new Exception(string.Format("Exception at: {0}. Message: {1}", ex.Source, ex.Message));
            }
        }
        //================================

            //Fairway
        //================================
        public async Task<FairwayModel> AddNewShot(FairwayModel shot)
        {
            try
            {
                await conn.InsertAsync(shot);
                return shot;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                throw new Exception(string.Format("Exception at: {0}. Message: {1}", ex.Source, ex.Message));
            }
        }
        //================================

            //Chip
        //================================
        public async Task<ChipModel> AddNewShot(ChipModel shot)
        {
            try
            {
                await conn.InsertAsync(shot);
                return shot;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                throw new Exception(string.Format("Exception at: {0}. Message: {1}", ex.Source, ex.Message));
            }
        }
        //================================

            //Putt
        //================================
        public async Task<PuttModel> AddNewShot(PuttModel shot)
        {
            try
            {
                await conn.InsertAsync(shot);
                return shot;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                throw new Exception(string.Format("Exception at: {0}. Message: {1}", ex.Source, ex.Message));
            }
        }
        //================================

        //========================================================================================================================================================================

        //Methods for returning all local storage data for given class (round, holes, shots)
        //========================================================================================================================================================================

        //Round
        //==========================================================
        public async Task<List<RoundModel>> GetAllRounds()
        {
            try
            {
                return await conn.Table<RoundModel>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                throw new Exception(string.Format("Exception at: {0}. Message: {1}", ex.Source, ex.Message));
            }
        }
        //==========================================================

        //Holes
        //==========================================================
        public async Task<List<HoleModel>> GetAllHoles()
        {
            try
            {
                return await conn.Table<HoleModel>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                throw new Exception(string.Format("Exception at: {0}. Message: {1}", ex.Source, ex.Message));
            }
        }
        //==========================================================

        //Shots
        //==========================================================

        //TODO: Create a method that returns a list of all shots
            //All Shots
        //================================
        //public async Task<List<>> AllShots()
        //{
        //    return null;
        //}
        //================================

            //Drive
        //================================
        public async Task<List<DriveModel>> GetAllShotsDrive()
        {
            try
            {
                return await conn.Table<DriveModel>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                throw new Exception(string.Format("Exception at: {0}. Message: {1}", ex.Source, ex.Message));
            }
        }
        //================================

        //Fairway
        //================================
        public async Task<List<FairwayModel>> GetAllShotsFairway()
        {
            try
            {
                return await conn.Table<FairwayModel>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                throw new Exception(string.Format("Exception at: {0}. Message: {1}", ex.Source, ex.Message));
            }
        }
        //================================

        //Chip
        //================================
        public async Task<List<ChipModel>> GetAllShotsChip()
        {
            try
            {
                return await conn.Table<ChipModel>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                throw new Exception(string.Format("Exception at: {0}. Message: {1}", ex.Source, ex.Message));
            }
        }
        //================================

        //Putt
        //================================
        public async Task<List<PuttModel>> GetAllShotsPutt()
        {
            try
            {
                return await conn.Table<PuttModel>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                throw new Exception(string.Format("Exception at: {0}. Message: {1}", ex.Source, ex.Message));
            }
        }
        //================================

        //========================================================================================================================================================================


        //Methods for returning all local storage data for given class (round, holes, shots)
        //========================================================================================================================================================================
        public async void ClearLocalStorage()
        {
            await conn.ExecuteAsync("DELETE FROM Rounds");
            await conn.ExecuteAsync("DELETE FROM Holes");
            await conn.ExecuteAsync("DELETE FROM DriveShot");
            await conn.ExecuteAsync("DELETE FROM FairwayShot");
            await conn.ExecuteAsync("DELETE FROM ChipShot");
            await conn.ExecuteAsync("DELETE FROM PuttShot");
        }
        //========================================================================================================================================================================
    }
}
