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
            await conn.CreateTableAsync<CourseModel>();
            await conn.CreateTableAsync<RoundModel>();
            await conn.CreateTableAsync<HoleModel>();
            await conn.CreateTableAsync<DriveModel>();
            await conn.CreateTableAsync<FairwayModel>();
            await conn.CreateTableAsync<ChipModel>();
            await conn.CreateTableAsync<PuttModel>();
        }

        //Methods for adding to local storage data for all classes (courses, rounds, holes, shots)
        //========================================================================================================================================================================

        //Courses
        //==========================================================
        public async Task<CourseModel> AddNewCourse(CourseModel course)
        {
            try
            {
                await conn.InsertAsync(course);
                return course;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                throw new Exception(string.Format("Exception at: {0}. Message: {1}", ex.Source, ex.Message));
            }
        }
        //==========================================================

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
        public async Task<HoleModel> AddNewHoleOne(HoleModel hole)
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

        public async Task<IEnumerable<HoleModel>> AddNewHoleList(IEnumerable<HoleModel> holes)
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


        //Methods for updating local storage data for all classes (courses, rounds, holes, shots)
        //========================================================================================================================================================================

        //Course
        //==========================================================
        public async Task<CourseModel> UpdateCourse(CourseModel course)
        {
            try
            {
                await conn.UpdateAsync(course);
                return course;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                throw new Exception(string.Format("Exception at: {0}. Message: {1}", ex.Source, ex.Message));
            }
        }
        //==========================================================

        //Rounds
        //==========================================================
        public async Task<RoundModel> UpdateRound(RoundModel round)
        {
            try
            {
                await conn.UpdateAsync(round);
                return round;
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
        public async Task<HoleModel> UpdateHole(HoleModel hole)
        {
            try
            {
                await conn.UpdateAsync(hole);
                return hole;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                throw new Exception(string.Format("Exception at: {0}. Message: {1}", ex.Source, ex.Message));
            }
        }

        public async Task<IEnumerable<HoleModel>> UpdateHoles(IEnumerable<HoleModel> holes)
        {
            try
            {
                await conn.UpdateAllAsync(holes);
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
        public async Task<DriveModel> UpdateShot(DriveModel shot)
        {
            try
            {
                await conn.UpdateAsync(shot);
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
        public async Task<FairwayModel> UpdateShot(FairwayModel shot)
        {
            try
            {
                await conn.UpdateAsync(shot);
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
        public async Task<ChipModel> UpdateShot(ChipModel shot)
        {
            try
            {
                await conn.UpdateAsync(shot);
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
        public async Task<PuttModel> UpdateShot(PuttModel shot)
        {
            try
            {
                await conn.UpdateAsync(shot);
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

        //Methods for returning all local storage data for given class (courses, rounds, holes, shots)
        //========================================================================================================================================================================

        //Course
        //==========================================================
        public async Task<List<CourseModel>> GetAllCourses()
        {
            try
            {
                return await conn.Table<CourseModel>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                throw new Exception(string.Format("Exception at: {0}. Message: {1}", ex.Source, ex.Message));
            }
        }
        //==========================================================

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


        /// <summary>
        /// Returns a list of "HoleModel" objects that corrsepond with the list of holeIds that it was given
        /// </summary>
        /// <param name="holeIds"></param>
        /// <returns></returns>
        public async Task<List<HoleModel>> GetHolesFromList(List<int> holeIds)
        {
            try
            {
                List<HoleModel> tempList = new List<HoleModel>();

                foreach (int holeId in holeIds)
                {
                    tempList.Add(await conn.Table<HoleModel>().Where(t => t.Id == holeId).FirstOrDefaultAsync());
                }

                return tempList;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                throw new Exception(string.Format("Exception at: {0}. Message: {1}", ex.Source, ex.Message));
            }
        }


        /// <summary>
        /// Returns a list of "HoleModel" objects that corrsepond with the list of holeIds that it was given
        /// </summary>
        /// <param name="holeIds"></param>
        /// <returns></returns>
        public async Task<List<HoleModel>> GetHolesFromRoundId(int roundId)
        {
            try
            {
                return await conn.Table<HoleModel>().Where(t => t.RoundId == roundId).ToListAsync();
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

        //All Shots
        //================================
        public async Task<AllShotsModel> GetShotsFromHoleId(int holeId)
        {
            try
            {
                AllShotsModel allShots = new AllShotsModel
                {
                    DriveASModel = await conn.Table<DriveModel>().Where(t => t.HoleId == holeId).ToListAsync(),
                    FairwayASModel = await conn.Table<FairwayModel>().Where(t => t.HoleId == holeId).ToListAsync(),
                    ChipASModel = await conn.Table<ChipModel>().Where(t => t.HoleId == holeId).ToListAsync(),
                    PuttASModel = await conn.Table<PuttModel>().Where(t => t.HoleId == holeId).ToListAsync()
                };

                return allShots;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                throw new Exception(string.Format("Exception at: {0}. Message: {1}", ex.Source, ex.Message));
            }
        }
        //================================

        //All Shots
        //================================
        public async Task<AllShotsModel> GetAllShots()
        {
            try {
                AllShotsModel allShots = new AllShotsModel
                {
                    DriveASModel = await conn.Table<DriveModel>().ToListAsync(),
                    FairwayASModel = await conn.Table<FairwayModel>().ToListAsync(),
                    ChipASModel = await conn.Table<ChipModel>().ToListAsync(),
                    PuttASModel = await conn.Table<PuttModel>().ToListAsync()
                };

                return allShots;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                throw new Exception(string.Format("Exception at: {0}. Message: {1}", ex.Source, ex.Message));
            }
        }
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
            await conn.ExecuteAsync("DELETE FROM Courses");
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
