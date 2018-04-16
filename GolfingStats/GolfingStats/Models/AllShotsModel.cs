using System;
using System.Collections.Generic;
using System.Text;

using GolfingStats.Models.ShotModels;

namespace GolfingStats.Models
{
    /// <summary>
    /// This class is not saved to local storage and is used when
    /// a list of all the shots the player has played is created
    /// </summary>
    public class AllShotsModel
    {
        public List<DriveModel> DriveASModel { get; set; } = new List<DriveModel>();

        public List<ApproachModel> FairwayASModel { get; set; } = new List<ApproachModel>();

        public List<ChipModel> ChipASModel { get; set; } = new List<ChipModel>();

        public List<PuttModel> PuttASModel { get; set; } = new List<PuttModel>();

        public List<DropShotModel> DropASModel { get; set; } = new List<DropShotModel>();
    }
}
