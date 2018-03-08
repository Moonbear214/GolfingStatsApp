using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace GolfingStats.Models.ShotModels
{
    [Table("FairwayShot")]
    public partial class FairwayModel : ShotModel
    {
        //Before Swing (All info about the shot before the player has hit the ball)
        //============================================================================

        /// <summary>
        /// Where is the player aiming to land on the green (Center, Left, Right)
        /// </summary>
        public string Aiming { get; set; } = null;

        /// <summary>
        /// On what side of the green is the pin located (Left, Center, Right)
        /// </summary>
        [MaxLength(6)]
        public string PinPositionHorz { get; set; } = "Center";

        /// <summary>
        /// How far in is the flag located (Back, Center, Front)
        /// </summary>
        [MaxLength(6)]
        public string PinPositionVert { get; set; } = "Center";

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
        /// On what side of the Fairway/Ruff is the ball (Center, Left, Right)
        /// </summary>
        [MaxLength(6)]
        public string BallPositionSide { get; set; } = "Center";
            
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

        //After Shot (All info about the shot that the player just hit)
        //============================================================================

        /// <summary>
        /// How far did the player hit the shot
        /// </summary>
        [MaxLength(3)]
        public int DistanceHit { get; set;} = 0;
    
        /// <summary>
        /// What type of swing did the player use when hitting the shot (Full, 3/4, Punch, KnockDown) 
        /// </summary>
        [MaxLength(9)]
        public string SwingType { get; set;} = null;

        /// <summary>
        /// What type of ball flight id the ball have (Cut, Fade, Draw, Hook, Slice)
        /// </summary>
        [MaxLength(5)]
        public string BallFlight { get; set;} = null;
    
        /// <summary>
        /// Is the ball on the green
        /// </summary>
        public bool OnGreen { get; set;} = true;
    
        //Player did end on the green
        //==========================
        /// <summary>
        /// On which side of the green did the ball end (Center, Left, Right)
        /// </summary>
        [MaxLength(6)]
        public string PosOnGreenHorz { get; set;} = null;
    
        /// <summary>
        /// How far into the green did the ball end (Front, Center, Back)
        /// </summary>
        [MaxLength(6)]
        public string PosOnGreenVer { get; set;} = null;
        //==========================

        //Player missed the green
        //==========================
        /// <summary>
        /// On what side did the player miss the green (Center, Left, Right)
        /// </summary>
        [MaxLength(6)]
        public string PosToGreenHorz { get; set; } = null;

        /// <summary>
        /// How far into the green did the ball end (Center, Over, Short) 
        /// </summary>
        [MaxLength(6)]
        public string PosToGreenVer { get; set; } = null;
        //==========================

        /// <summary>
        /// Is the ball in the hole
        /// </summary>
        public bool InHole { get; set; } = false;

        //============================================================================
    }
}
