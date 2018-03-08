using System;
using System.Collections.Generic;
using System.Text;

using GolfingStats.Models.ShotModels;

namespace GolfingStats.Models
{
    public class AllShotsModel
    {
        public DriveModel driveModel { get; set; } = null;

        public FairwayModel fairwayModel { get; set; } = null;

        public ChipModel chipModel { get; set; } = null;

        public PuttModel puttModel { get; set; } = null;
    }
}
