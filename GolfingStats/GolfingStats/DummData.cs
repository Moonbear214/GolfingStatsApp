using System;
using System.Collections.Generic;
using System.Text;

using GolfingStats.Models;
using GolfingStats.Models.ShotModels;

namespace GolfingStats
{
    public class DummData
    {
        //Round
        //=================================================================================================
        //Returns single round data
        public CourseModel OneCourse()
        {
            return new CourseModel() { Name = "Dummy Course" };
        }
        //=================================================================================================

        //Round
        //=================================================================================================
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
                fiveRounds.Add(new RoundModel() { CourseName = string.Format("Round {0}", fiveRounds.Count) });
            }

            return fiveRounds;
        }
        //=================================================================================================

            //Hole
        //=================================================================================================
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
        //=================================================================================================

            //Shot
        //=================================================================================================
        //Returns one shot (Do not miss your chance to blow!)
        //=================================================
        //Drive
        public DriveModel OneShotDrive ()
        {
            return new DriveModel();
        }

        //Fairwway
        public ApproachModel OneShotApproach()
        {
            return new ApproachModel();
        }

        //Chip
        public ChipModel OneShotChip()
        {
            return new ChipModel();
        }

        //Putt
        public PuttModel OneShotPutt()
        {
            return new PuttModel();
        }

        //Drop
        public DropShotModel OneShotDrop()
        {
            return new DropShotModel();
        }
        //=================================================

        //Returns 4 shots with no hole or round Id's assigned
        //=================================================
        //Returns 4 Drives with no hole or round Id's assigned 
        public List<DriveModel> FourShotsDrive()
        {
            List<DriveModel> fourShots = new List<DriveModel>();

            while (fourShots.Count < 4)
            {
                fourShots.Add(new DriveModel());
            }

            return fourShots;
        }

        //Returns 4 Approach shots with no hole or round Id's assigned 
        public List<ApproachModel> FourShotsApproach()
        {
            List<ApproachModel> fourShots = new List<ApproachModel>();

            while (fourShots.Count < 4)
            {
                fourShots.Add(new ApproachModel());
            }

            return fourShots;
        }

        //Returns 4 Chip with no hole or round Id's assigned 
        public List<ChipModel> FourShotsChip()
        {
            List<ChipModel> fourShots = new List<ChipModel>();

            while (fourShots.Count < 4)
            {
                fourShots.Add(new ChipModel());
            }

            return fourShots;
        }

        //Returns 4 Putts with no hole or round Id's assigned 
        public List<PuttModel> FourShotsPutt()
        {
            List<PuttModel> fourShots = new List<PuttModel>();

            while (fourShots.Count < 4)
            {
                fourShots.Add(new PuttModel());
            }

            return fourShots;
        }

        //Returns 4 Putts with no hole or round Id's assigned 
        public List<DropShotModel> FourShotsDrop()
        {
            List<DropShotModel> fourShots = new List<DropShotModel>();

            while (fourShots.Count < 4)
            {
                fourShots.Add(new DropShotModel());
            }

            return fourShots;
        }
        //=================================================

        //Returns 4 shots with hole or round Id's assigned
        //=================================================
        //Returns 4 Drives with hole or round Id's assigned 
        public List<DriveModel> FourShotsDrive(int roundId, int holeId)
        {
            List<DriveModel> fourShots = new List<DriveModel>();

            while (fourShots.Count < 4)
            {
                fourShots.Add(new DriveModel() { RoundId = roundId, HoleId = holeId });
            }

            return fourShots;
        }

        //Returns 4 Approach shots with hole or round Id's assigned 
        public List<ApproachModel> FourShotsApproach(int roundId, int holeId)
        {
            List<ApproachModel> fourShots = new List<ApproachModel>();

            while (fourShots.Count < 4)
            {
                fourShots.Add(new ApproachModel() { RoundId = roundId, HoleId = holeId });
            }

            return fourShots;
        }

        //Returns 4 Chip with no hole round Id's assigned 
        public List<ChipModel> FourShotsChip(int roundId, int holeId)
        {
            List<ChipModel> fourShots = new List<ChipModel>();

            while (fourShots.Count < 4)
            {
                fourShots.Add(new ChipModel() { RoundId = roundId, HoleId = holeId });
            }

            return fourShots;
        }

        //Returns 4 Putts with hole or round Id's assigned 
        public List<PuttModel> FourShotsPutt(int roundId, int holeId)
        {
            List<PuttModel> fourShots = new List<PuttModel>();

            while (fourShots.Count < 4)
            {
                fourShots.Add(new PuttModel() { RoundId = roundId, HoleId = holeId });
            }

            return fourShots;
        }

        //Returns 4 Putts with hole or round Id's assigned 
        public List<DropShotModel> FourShotsDrop(int roundId, int holeId)
        {
            List<DropShotModel> fourShots = new List<DropShotModel>();

            while (fourShots.Count < 4)
            {
                fourShots.Add(new DropShotModel() { RoundId = roundId, HoleId = holeId });
            }

            return fourShots;
        }
        //=================================================
        //=================================================================================================
    }
}
