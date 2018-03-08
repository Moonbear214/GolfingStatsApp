using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace GolfingStats.Models.ShotModels
{
    [Table("PuttShot")]
    public partial class PuttModel : ShotModel
    {
        //Before Swing (All info about the shot before the player has hit the ball)
        //============================================================================

        /// <summary>
        /// Where is the player aiming to putt in relation to the flag (Straight, Left, Right)
        /// </summary>
        public string Aiming { get; set; } = null;

        /// <summary>
        /// How far is the player in the given direction (Inside, Edge, Cup, 2/3/4 Cups, HalfMeter, 3/4 Meter, Meter)
        /// </summary>
        public string AimingDistance { get; set; } = null;

        /// <summary>
        /// To what side does the green break in relation to the player (Straight, Left, Right)
        /// </summary>
        [MaxLength(7)]
        public string GreenBreak { get; set; } = "Straight";

        /// <summary>
        /// At what angle is the green when the player looks at the flag (Flat, Uphill, Downill)
        /// </summary>
        public string AngleOfGreen { get; set; } = null;

        //============================================================================

        //After Swing (All info about the shot after the player has hit the ball)
        //============================================================================

        /// <summary>
        /// Is the ball in the hole
        /// </summary>
        public bool InHole { get; set; } = false;

        //Player missed the Hole
        //==========================
        /// <summary>
        /// On what side did the player miss the Hole (Center, Left, Right)
        /// </summary>
        [MaxLength(6)]
        public string PosToHoleHorz { get; set; } = null;

        /// <summary>
        /// How far from the Hole did the ball end (Center, Over, Short) 
        /// </summary>
        [MaxLength(6)]
        public string PosToHoleVer { get; set; } = null;

        /// <summary>
        /// How far is the ball still from the hole
        /// </summary>
        [MaxLength(2)]
        public int DistanceLeftToHole { get; set; } = 0;
        //==========================

        /// <summary>
        /// How far did the player pull back the putter (Minnimal, Medium, Far)
        /// </summary>
        public string PullBackLength { get; set; } = "Minnimal";
        //============================================================================

    }
}
