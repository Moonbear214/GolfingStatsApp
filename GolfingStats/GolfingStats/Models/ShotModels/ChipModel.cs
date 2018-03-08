using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace GolfingStats.Models.ShotModels
{
    [Table("ChipShot")]
    public partial class ChipModel : ShotModel
    {
        //Before Swing (All info about the shot before the player has hit the ball)
        //============================================================================

        /// <summary>
        /// Where is the player aiming to land in relation to the flag (Straight, Left, Right)
        /// </summary>
        public string Aiming { get; set; } = null;

        /// <summary>
        /// Where on the green is the pin located in relation to the player (Left, Center, Right)
        /// </summary>
        [MaxLength(6)]
        public string PinPositionHorz { get; set; } = "Center";

        /// <summary>
        /// How far in on the green is the pin located in relation to the player (Back, Center, Front)
        /// </summary>
        [MaxLength(6)]
        public string PinPositionVert { get; set; } = "Center";

        /// <summary>
        /// To what side does the green break in relation to the player (Straight, Left, Right)
        /// </summary>
        [MaxLength(7)]
        public string GreenBreak { get; set; } = "Straight";

        /// <summary>
        /// At what angle is the green when the player looks at the flag (Flat, Uphill, Downill)
        /// </summary>
        public string AngleOfGreen { get; set; } = null;

        /// <summary>
        /// Where does the ball lie on the hole (Fairway, Ruff, Bunker)
        /// </summary>
        [MaxLength(7)]
        public string BallLie { get; set; } = "Fairway";

        /// <summary>
        /// On what side of the green is the ball from the fairways perspective (Center, Left, Right)
        /// </summary>
        [MaxLength(6)]
        public string PosToGreenHorz { get; set; } = null;

        /// <summary>
        /// How far into the green did the ball end from the fairways perspective (Center, Over, Short) 
        /// </summary>
        [MaxLength(6)]
        public string PosToGreenVer { get; set; } = null;

        /// <summary>
        /// At what angle is the ball postitioned (Uphill, Downhill, Flat)
        /// </summary>
        [MaxLength(8)]
        public string BallAngle { get; set; } = null;

        /// <summary>
        /// Where is the ball positioned in relation to the players feet (Sqaure, Above, Below)
        /// </summary>
        [MaxLength(5)]
        public string BallToFeet { get; set; } = null;
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
        /// TODO: Add More chip shot types
        /// What type of swing did the player use when hitting the shot (Pitch, Run, Flop) 
        /// </summary>
        [MaxLength(5)]
        public string SwingType { get; set; } = null;

        /// <summary>
        /// How much spin was on the ball when it landed (None, Little, Mild, Much) 
        /// </summary>
        public string SpinAmount { get; set; } = null;

        //============================================================================

    }
}
