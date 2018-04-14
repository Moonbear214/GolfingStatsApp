using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using GolfingStats.Models;
using GolfingStats.Models.ShotModels;

namespace GolfingStats.Factories
{
    public class DataFactory
    {
        private static GolfstatsRepository GolfstatsRepository { get; set; }

        //======================================
        //For use only to add dummy data to storage to work with
        private DummData DummData = new DummData();
        //======================================

        public DataFactory(string dbPath)
        {
            GolfstatsRepository = new GolfstatsRepository(dbPath);
        }

        //Dummy data
        //========================================================================================================================================================================
        //Clear local storage of all data
        //!!!ONLY FOR TESTING PURPOSES!!!!
        public void ClearLocalStorage()
        {
            GolfstatsRepository.ClearLocalStorage();
        }

        //Creates a full round with all holes included
        public async void CreateFullRoundDummy()
        {
            List<HoleModel> NewRound = await CreateNewFullRound(new RoundModel(), (List<HoleModel>)HoleModel.EmptyRound);
        }

        //All methods for adding dummy data to local storage
        public void AddAllDummyData()
        {
            AddDummyCourse();
            AddDummyRound();
            AddDummyHole();
            AddDummyShotDrive();
            AddDummyShotFairway();
            AddDummyShotChip();
            AddDummyShotPutt();
        }

        public async void AddDummyCourse()
        {
            await GolfstatsRepository.AddNewCourse(DummData.OneCourse());
        }

        public async void AddDummyRound()
        {
            await GolfstatsRepository.AddNewRound(DummData.OneRound());
        }

        public async void AddDummyHole()
        {
            await GolfstatsRepository.AddNewHoleOne(DummData.OneHoleData());
        }

        public async void AddDummyShotDrive()
        {
            await GolfstatsRepository.AddNewShot(DummData.OneShotDrive());
        }

        public async void AddDummyShotFairway()
        {
            await GolfstatsRepository.AddNewShot(DummData.OneShotFairway());
        }

        public async void AddDummyShotChip()
        {
            await GolfstatsRepository.AddNewShot(DummData.OneShotChip());
        }

        public async void AddDummyShotPutt()
        {
            await GolfstatsRepository.AddNewShot(DummData.OneShotPutt());
        }
        //========================================================================================================================================================================


        //Methods that is connected to local storage (GolfstatsRepository)
        //========================================================================================================================================================================
            
            //Create methods that adds the data to local storage
        //==================================================================================

        /// <summary>
        /// Saves a course to local storage that will be used for the different rounds being played
        /// (Will be updated after the user updates the holes that are played on the course)
        /// </summary>
        /// <param name="courseName"></param>
        /// <returns></returns>
        public async Task<CourseModel> CreateNewCourse(string courseName)
        {
            CourseModel courseModel = new CourseModel()
            {
                Name = courseName,
                Holes = new List<HoleModel>(HoleModel.EmptyRound)
            };

            courseModel.SetHoleIds = await CreateHoleList(courseModel.Holes);

            return await GolfstatsRepository.AddNewCourse(courseModel); ;
        }

        /// <summary>
        /// Saves a round and 18 holes with the roundId applied to them to local storage
        /// that will be updated as the player continues playing the round
        /// </summary>
        /// <param name="round"></param>
        /// <param name="holes"></param>
        /// <returns></returns>
        public async Task<List<HoleModel>> CreateNewFullRound(RoundModel round, List<HoleModel> holes)
        {
            await GolfstatsRepository.AddNewRound(round);

            List<HoleModel> EmptyRound = holes;
            for (int i = 0; i < EmptyRound.Count; i++)
            {
                EmptyRound[i].RoundId = round.Id;
            }

            return await CreateHoleList(EmptyRound);// new List<HoleModel>(EmptyRound);
        }

        /// <summary>
        /// Saves a list of holes to local storage
        /// </summary>
        /// <param name="holes"></param>
        /// <returns></returns>
        public async Task<List<HoleModel>> CreateHoleList(List<HoleModel> holes)
        {
            return new List<HoleModel>(await GolfstatsRepository.AddNewHoleList(holes));
        }
        
        public async Task<DriveModel> CreateShot(DriveModel drive)
        {
            //If the shot already has an ID, update the shot in local storage
            if (drive.Id != 0)
                return await UpdateShot(drive);
            else
                return await GolfstatsRepository.AddNewShot(drive);
        }

        public async Task<FairwayModel> CreateShot(FairwayModel fairway)
        {
            //If the shot already has an ID, update the shot in local storage
            if (fairway.Id != 0)
                return await UpdateShot(fairway);
            else
                return await GolfstatsRepository.AddNewShot(fairway);
        }

        public async Task<ChipModel> CreateShot(ChipModel chip)
        {
            //If the shot already has an ID, update the shot in local storage
            if (chip.Id != 0)
                return await UpdateShot(chip);
            else
                return await GolfstatsRepository.AddNewShot(chip);
        }

        public async Task<PuttModel> CreateShot(PuttModel putt)
        {
            //If the shot already has an ID, update the shot in local storage
            if (putt.Id != 0)
                return await UpdateShot(putt);
            else
                return await GolfstatsRepository.AddNewShot(putt);
        }

        public async Task<DropShotModel> CreateShot(DropShotModel drop)
        {
            //If the shot already has an ID, update the shot in local storage
            if (drop.Id != 0)
                return await UpdateShot(drop);
            else
                return await GolfstatsRepository.AddNewShot(drop);
        }
        //==================================================================================


        // Methods for updating tables in local storage
        //==================================================================================

        public async Task<CourseModel> UpdateCourse(CourseModel course)
        {
            await UpdateHoles(course.Holes);

            course.Par = 0;
            foreach (HoleModel hole in course.Holes)
            {
                course.Par += hole.Par;
            }

            await GolfstatsRepository.UpdateCourse(course);

            return course;
        }

        public async Task<RoundModel> UpdateRound(RoundModel round)
        {
            return await GolfstatsRepository.UpdateRound(round);
        }

        public async Task<HoleModel> UpdateHole(HoleModel hole)
        {
            return await GolfstatsRepository.UpdateHole(hole);
        }

        public async Task<IEnumerable<HoleModel>> UpdateHoles(IEnumerable<HoleModel> hole)
        {
            return await GolfstatsRepository.UpdateHoles(hole);
        }

        public async Task<DriveModel> UpdateShot(DriveModel shot)
        {
            return await GolfstatsRepository.UpdateShot(shot);
        }

        public async Task<FairwayModel> UpdateShot(FairwayModel shot)
        {
            return await GolfstatsRepository.UpdateShot(shot);
        }

        public async Task<ChipModel> UpdateShot(ChipModel shot)
        {
            return await GolfstatsRepository.UpdateShot(shot);
        }

        public async Task<PuttModel> UpdateShot(PuttModel shot)
        {
            return await GolfstatsRepository.UpdateShot(shot);
        }

        public async Task<DropShotModel> UpdateShot(DropShotModel shot)
        {
            return await GolfstatsRepository.UpdateShot(shot);
        }
        //==================================================================================


        //Retrieve data from local storage
        //==================================================================================
        public async Task<List<CourseModel>> GetAllCourses()
        {
            //TODO: If there are dozens of courses this process will be very slow,
            //change this to collect the holes for the course when the user has selected a course

            List<CourseModel> AllCourses = await GolfstatsRepository.GetAllCourses();

            foreach (CourseModel course in AllCourses)
            {
                course.Holes = await GetHolesFromList(course.GetHoleIds);
            }

            return AllCourses;
        }

        public async Task<List<RoundModel>> GetAllRounds()
        {
            return await GolfstatsRepository.GetAllRounds();
        }

        public async Task<List<HoleModel>> GetAllHoles()
        {
            return await GolfstatsRepository.GetAllHoles();
        }

        /// <summary>
        /// Returns a list of "HoleModel" objects that corrsepond with the list of holeIds that it was given
        /// </summary>
        /// <param name="holeIds"></param>
        /// <returns></returns>
        public async Task<List<HoleModel>> GetHolesFromList(List<int> holeIds)
        {
            return await GolfstatsRepository.GetHolesFromList(holeIds); 
        }

        /// <summary>
        /// Returns a list of "HoleModel" objects that has all been played on the roundId that was given
        /// </summary>
        /// <param name="roundId"></param>
        /// <returns></returns>
        public async Task<List<HoleModel>> GetHolesFromRoundId(int roundId)
        {
            return await GolfstatsRepository.GetHolesFromRoundId(roundId);
        }


        /// <summary>
        /// Returns a list of "ShotModel" objects that has all been played on the holeId that was given
        /// </summary>
        /// <param name="holeId"></param>
        /// <returns></returns>
        public async Task<List<ShotModel>> GetShotsFromHoleId(int holeId)
        {
            AllShotsModel allShots = await GolfstatsRepository.GetShotsFromHoleId(holeId);
            return AllShotsList(allShots);
        }

        public async Task<List<ShotModel>> GetShotsFromHoleIdList(List<int> holeIds)
        {
            AllShotsModel allShots = await GolfstatsRepository.GetShotsFromHoleIdList(holeIds);
            return AllShotsList(allShots);
        }


        public async Task<List<ShotModel>> GetAllShots()
        {
            AllShotsModel allShots = await GolfstatsRepository.GetAllShots();
            return AllShotsList(allShots);
        }

        public async Task<List<DriveModel>> GetAllShotsDrive()
        {
            return await GolfstatsRepository.GetAllShotsDrive();
        }

        public async Task<List<FairwayModel>> GetAllShotsFairway()
        {
            return await GolfstatsRepository.GetAllShotsFairway();
        }

        public async Task<List<ChipModel>> GetAllShotsChip()
        {
            return await GolfstatsRepository.GetAllShotsChip();
        }

        public async Task<List<PuttModel>> GetAllShotsPutt()
        {
            return await GolfstatsRepository.GetAllShotsPutt();
        }

        public async Task<List<DropShotModel>> GetAllShotsDrop()
        {
            return await GolfstatsRepository.GetAllShotsDrop();
        }
        //==================================================================================

        //Delete data from local storage
        //==================================================================================
        public void DeleteRoundHolesShots(RoundModel round)
        {
            GolfstatsRepository.DeleteRoundHolesShots(round);
        }

        public void DeleteCourseAndHoles(CourseModel course)
        {
            GolfstatsRepository.DeleteCourseAndHoles(course);
        }

        public void DeleteShot(ShotModel shot)
        {
            GolfstatsRepository.DeleteShot(shot);
        }
        //==================================================================================

        //========================================================================================================================================================================

        //Methods that used within the Datafactory
        //========================================================================================================================================================================

        //Creates a ShotModel List from the AllShotsModel object that it was given
        public List<ShotModel> AllShotsList(AllShotsModel allShots)
        {
            List<ShotModel> shotModel = new List<ShotModel>();

            for (int i = 0; i < allShots.DriveASModel.Count; i++)
            {
                shotModel.Add(allShots.DriveASModel[i]);
            }

            for (int i = 0; i < allShots.FairwayASModel.Count; i++)
            {
                shotModel.Add(allShots.FairwayASModel[i]);
            }

            for (int i = 0; i < allShots.ChipASModel.Count; i++)
            {
                shotModel.Add(allShots.ChipASModel[i]);
            }

            for (int i = 0; i < allShots.PuttASModel.Count; i++)
            {
                shotModel.Add(allShots.PuttASModel[i]);
            }

            for (int i = 0; i < allShots.DropASModel.Count; i++)
            {
                shotModel.Add(allShots.DropASModel[i]);
            }

            return shotModel;
        }
        //========================================================================================================================================================================
    }
}
