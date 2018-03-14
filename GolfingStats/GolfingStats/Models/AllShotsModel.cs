using System;
using System.Collections.Generic;
using System.Text;

using GolfingStats.Models.ShotModels;

namespace GolfingStats.Models
{
    public class AllShotsModel
    {
        public List<DriveModel> DriveASModel { get; set; } = null;

        public List<FairwayModel> FairwayASModel { get; set; } = null;

        public List<ChipModel> ChipASModel { get; set; } = null;

        public List<PuttModel> PuttASModel { get; set; } = null;
    }
}
