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
        public List<DriveModel> DriveASModel { get; set; } = null;

        public List<FairwayModel> FairwayASModel { get; set; } = null;

        public List<ChipModel> ChipASModel { get; set; } = null;

        public List<PuttModel> PuttASModel { get; set; } = null;
    }
}
