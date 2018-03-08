using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace GolfingStats.Models
{
    public partial class ShotModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; private set; }

        /// <summary>
        /// Id of the round of golf this hole was played on
        /// </summary>
        public int RoundId { get; set; } = 0;

        /// <summary>
        /// Id of the round of golf this hole was played on
        /// </summary>
        public int HoleId { get; set; } = 0;

        /// <summary>
        /// What number shot is this for the player on the hole
        /// </summary>
        [MaxLength(2)]
        public int ShotNumber { get; set; } = 0;

        /// <summary>
        /// Distance from where player is now to the hole
        /// </summary>
        [MaxLength(3)]
        public int DistanceToHole { get; set; } = 0;

        /// <summary>
        /// Driver, 3/5/7 Wood, 3/5 Hybrid, 2/3/4/5/6/7/8/9 Iron, PW, 52/56/58/60 Wedge, Putter
        /// </summary>
        [MaxLength(8)]
        public string Club { get; set; } = null;

        //TODO: Add drop shot variable for waterhazards, Out-of-Bounds ect.
    }
}
