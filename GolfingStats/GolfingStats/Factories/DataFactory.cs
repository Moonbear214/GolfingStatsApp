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
        private GolfstatsRepository GolfstatsRepository { get; set; }

        private DummData DummData = new DummData();

        public DataFactory(string dbPath)
        {
            GolfstatsRepository = new GolfstatsRepository(dbPath);


            //Add dummy data
            //==================================================
            //AddAllDummyData();
            //AddAllDummyData();
            //AddAllDummyData();
            //AddAllDummyData();
            //AddAllDummyData();
            //AddAllDummyData();
            //==================================================
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
            List<HoleModel> NewRound = await CreateFullRound(new RoundModel());
        }


        //All methods for adding dummy data to local storage
        public void AddAllDummyData()
        {
            AddDummyRound();
            AddDummyHole();
            AddDummyShotDrive();
            AddDummyShotFairway();
            AddDummyShotChip();
            AddDummyShotPutt();
        }

        public async void AddDummyRound()
        {
            await GolfstatsRepository.AddNewRound(DummData.OneRound());
        }

        public async void AddDummyHole()
        {
            await GolfstatsRepository.AddOneHole(DummData.OneHoleData());
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


        //========================================================================================================================================================================
        public async Task<List<HoleModel>> CreateFullRound(RoundModel round)
        {
            await GolfstatsRepository.AddNewRound(round);

            IList<HoleModel> EmptyRound = HoleModel.EmptyRound;
            for (int i = 0; i < EmptyRound.Count; i++)
            {
                EmptyRound[i].RoundId = round.Id;
            }

            await GolfstatsRepository.AddRoundHoles(EmptyRound);

            return new List<HoleModel>(EmptyRound);
        }

        //========================================================================================================================================================================

        //Retrieve data from local storage
        //========================================================================================================================================================================
        public async Task<List<RoundModel>> GetAllRounds()
        {
            return await GolfstatsRepository.GetAllRounds();
        }

        public async Task<List<HoleModel>> GetAllHoles()
        {
            return await GolfstatsRepository.GetAllHoles();
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
        //========================================================================================================================================================================
    }
}
