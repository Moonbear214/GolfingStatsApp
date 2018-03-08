using System;
using System.Collections.Generic;
using System.Text;

using GolfingStats.Models;
using GolfingStats.Models.ShotModels;

namespace GolfingStats
{
    public class DummData
    {
        //Returns single round data
        public RoundModel OneRound()
        {
            return new RoundModel();
        }

        //Returns five rounds
        public List<RoundModel> FiveRounds()
        {
            List<RoundModel> fiveRounds = new List<RoundModel>();

            while (fiveRounds.Count < 5)
            {
                fiveRounds.Add(new RoundModel() { GolfCourse = string.Format("Round {0}", fiveRounds.Count) });
            }

            return fiveRounds;
        }
        
        
        //Returns single hole dummy data
        public HoleModel OneHoleData ()
        {
            return new HoleModel();
        }

        public HoleModel OneHoleData(int roundId)
        {
            return new HoleModel() { RoundId = roundId };
        }

        //Returns empty round list (18)
        public List<HoleModel> ListHoleData ()
        {
            return (List<HoleModel>)HoleModel.EmptyRound;
        }

        //Returns empty round list (18) with the supplied round Id added
        public List<HoleModel> RoundHoleData(int roundId)
        {
            List<HoleModel> emptyRound = (List<HoleModel>)HoleModel.EmptyRound;

            for (int i = 0; i < emptyRound.Count; i++)
            {
                emptyRound[i].RoundId = roundId;
            }

            return emptyRound;
        }
        

        //Returns one shot (Do not miss your chance to blow!)
        public ShotModel OneShot ()
        {
            return new ShotModel();
        }

        //Returns 4 shots with no hole or round Id's assigned 
        public List<ShotModel> FourShots ()
        {
            List<ShotModel> fourShots = new List<ShotModel>();

            while (fourShots.Count < 4)
            {
                fourShots.Add(new ShotModel());
            }

            return fourShots;
        }

        //Returns 4 shots with hole or round Id's assigned 
        public List<ShotModel> FourShots(int roundId, int holeId)
        {
            List<ShotModel> fourShots = new List<ShotModel>();

            while (fourShots.Count < 4)
            {
                fourShots.Add(new ShotModel() { RoundId = roundId, HoleId = holeId });
            }

            return fourShots;
        }
    }
}
