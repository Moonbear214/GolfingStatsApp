using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace GolfingStats.Models.ShotModels
{
    [Table("ApproachShot")]
    public partial class ApproachModel : ShotModel
    {
        ConvertShotsClass ConvertShotsClass = new ConvertShotsClass();

        /// <summary>
        /// Indecator of which shot model type is used by the shot:
        /// 0 = Drive, 1 = Fairway, 2 = Chip, 3 = Putt, 4 = Drop
        /// </summary>
        public int ShotType { get; } = 1;

        //Before Swing (All info about the shot before the player has hit the ball)
        //============================================================================
        /// <summary>
        /// On what side of the green is the pin located:
        /// 1 = Center, 2 = Left, 3 = Right
        /// </summary>
        [MaxLength(1)]
        public Int16 _PinPositionHorz { get; set; } = 1;

        [Ignore]
        public String PinPositionHorz
        {
            get
            {
                return ConvertShotsClass.CenterLeftRightConvert(this._PinPositionHorz);
            }
            set
            {
                this._PinPositionHorz = ConvertShotsClass.CenterLeftRightConvert(value);
            }
        }

        /// <summary>
        /// How far in is the flag located:
        /// 1 = Center, 2 = Front, 3 = Back
        /// </summary>
        [MaxLength(1)]
        public Int16 _PinPositionVert { get; set; } = 1;

        [Ignore]
        public String PinPositionVert
        {
            get
            {
                return ConvertShotsClass.CenterFrontBackConvert(this._PinPositionVert);
            }
            set
            {
                this._PinPositionVert = ConvertShotsClass.CenterFrontBackConvert(value);
            }
        }

        /// <summary>
        /// Where is the player aiming to land on the green:
        /// 1 = Center, 2 = Left, 3 = Right
        /// </summary>
        public Int16 _Aiming { get; set; } = 1;

        [Ignore]
        public String Aiming
        {
            get
            {
                return ConvertShotsClass.CenterLeftRightConvert(this._Aiming);
            }
            set
            {
                this._Aiming = ConvertShotsClass.CenterLeftRightConvert(value);
            }
        }

        /// <summary>
        /// At what angle is the green when the player looks at the flag:
        /// 1 = Flat, 2 = Downhill, 3 = Uphill
        /// </summary>
        public Int16 _BallToGreen { get; set; } = 1;

        [Ignore]
        public String BallToGreen
        {
            get
            {
                return ConvertShotsClass.FlatDownhillUphillConvert(this._BallToGreen);
            }
            set
            {
                this._BallToGreen = ConvertShotsClass.FlatDownhillUphillConvert(value);
            }
        }

        /// <summary>
        /// Where does the ball lie on the hole:
        /// 1 = Fairway, 2 = Ruff, 3 = Bunker, 4 = Hazard
        /// </summary>
        [MaxLength(1)]
        public Int16 _BallLie { get; set; } = 1;

        [Ignore]
        public String BallLie
        {
            get
            {
                return ConvertShotsClass.FairwayRuffBunkerHazardConvert(this._BallLie);
            }
            set
            {
                this._BallLie = ConvertShotsClass.FairwayRuffBunkerHazardConvert(value);
            }
        }

        /// <summary>
        /// On what side of the Fairway/Ruff is the ball:
        /// 1 = Center, 2 = Left, 3 = Right
        /// </summary>
        [MaxLength(1)]
        public Int16 _BallPositionSide { get; set; } = 1;

        [Ignore]
        public String BallPositionSide
        {
            get
            {
                return ConvertShotsClass.CenterLeftRightConvert(this._BallPositionSide);
            }
            set
            {
                this._BallPositionSide = ConvertShotsClass.CenterLeftRightConvert(value);
            }
        }

        /// <summary>
        /// At what angle is the ball postitioned:
        /// 1 = Flat, 2 = Downhill, 3 = Uphill
        /// </summary>
        [MaxLength(1)]
        public Int16 _BallAngle { get; set; } = 1;

        [Ignore]
        public String BallAngle
        {
            get
            {
                return ConvertShotsClass.FlatDownhillUphillConvert(this._BallAngle);
            }
            set
            {
                this._BallAngle = ConvertShotsClass.FlatDownhillUphillConvert(value);
            }
        }

        /// <summary>
        /// Where is the ball positioned in relation to the players feet (Sqaure, Above, Below):
        /// 1 = Sqaure, 2 = Below, 3 = Above
        /// </summary>
        [MaxLength(1)]
        public Int16 _BallToFeet { get; set; } = 1;

        [Ignore]
        public String BallToFeet
        {
            get
            {
                return ConvertShotsClass.SqaureBelowAboveConvert(this._BallToFeet);
            }
            set
            {
                this._BallToFeet = ConvertShotsClass.SqaureBelowAboveConvert(value);
            }
        }

        /// <summary>
        /// Froce of the wind:
        /// 1 = None, 2 = Light, 3 = Medium, 4 = Strong
        /// </summary>
        [MaxLength(1)]
        public Int16 _WindForce { get; set; } = 1;

        [Ignore]
        public String WindForce
        {
            get
            {
                return ConvertShotsClass.NoneLightMediumStrongConvert(this._WindForce);
            }
            set
            {
                this._WindForce = ConvertShotsClass.NoneLightMediumStrongConvert(value);
            }
        }


        /// <summary>
        /// Direction that the wind is blowing (Left, Right, Towards, Away):
        /// 1 = Left, 2 = Right, 3 = Towards, 4 = Away
        /// </summary>
        [MaxLength(1)]
        public Int16 _WindDirection { get; set; } = 0;

        [Ignore]
        public String WindDirection
        {
            get
            {
                return ConvertShotsClass.LeftRightTowardsAwayConvert(this._WindDirection);
            }
            set
            {
                this._WindDirection = ConvertShotsClass.LeftRightTowardsAwayConvert(value);
            }
        }
        //============================================================================

        //After Shot (All info about the shot that the player just hit)
        //============================================================================

        /// <summary>
        /// Is the ball in the hole
        /// </summary>
        public bool _InHole { get; set; } = false;

        [Ignore]
        public bool InHole
        {
            get
            {
                return _InHole;
            }
            set
            {
                if (value)
                {
                    PosOnGreenVer = null;
                    PosOnGreenHorz = null;
                    PosToGreenVer = null;
                    PosToGreenHorz = null;
                }

                _InHole = value;
            }
        }

        /// <summary>
        /// Is the ball on the green
        /// </summary>
        public bool _OnGreen { get; set; } = true;

        [Ignore]
        public bool OnGreen
        {
            get
            {
                return _OnGreen;
            }
            set
            {
                if (value)
                {
                    PosToGreenVer = null;
                    PosToGreenHorz = null;
                }
                else
                {
                    PosOnGreenVer = null;
                    PosOnGreenHorz = null;
                }
                _OnGreen = value;
            }
        }

        /// <summary>
        /// Is the player playing a layup shot or going for green
        /// </summary>
        public bool LayupShot { get; set; } = false;

        /// <summary>
        /// How far did the player hit the shot
        /// </summary>
        [MaxLength(3)]
        public int DistanceHit { get; set; } = 0;

        /// <summary>
        /// What type of swing did the player use when hitting the shot:
        /// 1 = Full, 2 = 3/4, 3 = Punch, 4 = KnockDown
        /// </summary>
        [MaxLength(1)]
        public Int16 _SwingType { get; set; } = 1;

        [Ignore]
        public String SwingType
        {
            get
            {
                return ConvertShotsClass.Full34PunchKnockdownConvert(this._SwingType);
            }
            set
            {
                this._SwingType = ConvertShotsClass.Full34PunchKnockdownConvert(value);
            }
        }

        /// <summary>
        /// What type of ball flight did the ball have:
        /// 1 = Draw, 2 = Cut, 3 = Hook, 4 = Fade, 5 = Slice
        /// </summary>
        [MaxLength(1)]
        public Int16 _BallFlight { get; set; } = 2;

        [Ignore]
        public String BallFlight
        {
            get
            {
                return ConvertShotsClass.DrawCutHookFadeSliceConvert(this._BallFlight);
            }
            set
            {
                this._BallFlight = ConvertShotsClass.DrawCutHookFadeSliceConvert(value);
            }
        }

        /// <summary>
        /// How much spin was on the ball when it landed:
        /// 1 = None, 2 = Little, 3 = Medium, 4 = Much
        /// </summary>
        [MaxLength(1)]
        public Int16 _SpinAmount { get; set; } = 1;

        [Ignore]
        public String SpinAmount
        {
            get
            {
                return ConvertShotsClass.NoneLittleMediumMuchConvert(this._SpinAmount);
            }
            set
            {
                this._SpinAmount = ConvertShotsClass.NoneLittleMediumMuchConvert(value);
            }
        }

        //Player did end on the green
        //==========================
        /// <summary>
        /// On which side of the green did the ball end:
        /// 1 = Center, 2 = Left, 3 = Right
        /// </summary>
        [MaxLength(1)]
        public Int16 _PosOnGreenHorz { get; set; } = 1;

        [Ignore]
        public String PosOnGreenHorz
        {
            get
            {
                return ConvertShotsClass.CenterLeftRightConvert(this._PosOnGreenHorz);
            }
            set
            {
                this._PosOnGreenHorz = ConvertShotsClass.CenterLeftRightConvert(value);
            }
        }

        /// <summary>
        /// How far into the green did the ball end:
        /// 1 = Center, 2 = Front, 3 = Back
        /// </summary>
        [MaxLength(0)]
        public Int16 _PosOnGreenVer { get; set; } = 1;

        [Ignore]
        public String PosOnGreenVer
        {
            get
            {
                return ConvertShotsClass.CenterFrontBackConvert(this._PosOnGreenVer);
            }
            set
            {
                this._PosOnGreenVer = ConvertShotsClass.CenterFrontBackConvert(value);
            }
        }
        //==========================

        //Player missed the green
        //==========================
        /// <summary>
        /// On what side did the player miss the green:
        /// 1 = Center, 2 = Left, 3 = Right
        /// </summary>
        [MaxLength(1)]
        public Int16 _PosToGreenHorz { get; set; } = 0;

        [Ignore]
        public String PosToGreenHorz
        {
            get
            {
                return ConvertShotsClass.CenterLeftRightConvert(this._PosToGreenHorz);
            }
            set
            {
                this._PosToGreenHorz = ConvertShotsClass.CenterLeftRightConvert(value);
            }
        }

        /// <summary>
        /// Did the ball end short, next to or over the green
        /// 1 = Center, 2 = Short, 3 = Past
        /// </summary>
        [MaxLength(1)]
        public Int16 _PosToGreenVer { get; set; } = 0;

        [Ignore]
        public String PosToGreenVer
        {
            get
            {
                return ConvertShotsClass.CenterShortPastConvert(this._PosToGreenVer);
            }
            set
            {
                this._PosToGreenVer = ConvertShotsClass.CenterShortPastConvert(value);
            }
        }

        //==========================

        //============================================================================
    }
}
