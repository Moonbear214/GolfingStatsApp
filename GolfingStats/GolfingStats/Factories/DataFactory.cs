using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GolfingStats.Models;

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
            AddDummyShot();
        }

        public async void AddDummyRound()
        {
            await GolfstatsRepository.AddNewRound(DummData.OneRound());
        }

        public async void AddDummyHole()
        {
            await GolfstatsRepository.AddOneHole(DummData.OneHoleData());
        }

        public async void AddDummyShot()
        {
            await GolfstatsRepository.AddNewShot(DummData.OneShot());
        }
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

        public async Task<List<RoundModel>> GetAllRounds()
        {
            return await GolfstatsRepository.GetAllRounds();
        }

        public async Task<List<HoleModel>> GetAllHoles()
        {
            return await GolfstatsRepository.GetAllHoles();
        }

        public async Task<List<ShotModel>> GetAllShots()
        {
            return await GolfstatsRepository.GetAllShots();
        }
    }
}
