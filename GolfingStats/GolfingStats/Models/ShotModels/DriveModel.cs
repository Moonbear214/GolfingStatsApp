using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace GolfingStats.Models.ShotModels
{
    [Table("DriveShot")]
    public partial class DriveModel : ShotModel
    {
        //Before Swing (All info about the shot before the player has hit the ball)
        //============================================================================

        /// <summary>
        /// Where is the player aiming to land on the fairway (Center, Left, Right)
        /// </summary>
        public string Aiming { get; set; } = null;

        /// <summary>
        /// Froce of the wind (None, Light, Mild, Strong)
        /// </summary>
        [MaxLength(6)]
        public string WindForce { get; set; } = null;

        /// <summary>
        /// Direction that the wind is blowing (Left, Right, Towards, Away)
        /// </summary>
        [MaxLength(7)]
        public string WindDirection { get; set; } = null;
        //============================================================================

        //After Swing (All info about the shot after the player has hit the ball)
        //============================================================================

        /// <summary>
        /// How far did the player hit the shot
        /// </summary>
        [MaxLength(3)]
        public int DistanceHit { get; set; } = 0;

        /// <summary>
        /// What type of swing did the player use when hitting the shot (Full, 3/4, Punch, KnockDown) 
        /// </summary>
        [MaxLength(9)]
        public string SwingType { get; set; } = null;

        /// <summary>
        /// What type of ball flight id the ball have (Cut, Fade, Draw, Hook, Slice)
        /// </summary>
        [MaxLength(5)]
        public string BallFlight { get; set; } = null;

        /// <summary>
        /// Is the ball on the faiwary
        /// </summary>
        public bool OnFairway { get; set; } = true;

        //Player did end on the Fairway
        //==========================
        /// <summary>
        /// On which side of the fairway did the ball end (Center, Left, Right)
        /// </summary>
        [MaxLength(6)]
        public string PosOnFairwayHorz { get; set; } = null;

        //==========================

        //Player missed the Fairway
        //==========================
        /// <summary>
        /// On what side did the player miss the Fairway (Center, Left, Right)
        /// </summary>
        [MaxLength(6)]
        public string PosToFairwayHorz { get; set; } = null;

        //==========================
        //============================================================================
    }
}
