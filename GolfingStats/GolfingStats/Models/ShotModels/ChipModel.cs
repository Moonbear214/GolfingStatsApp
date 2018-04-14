using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace GolfingStats.Models.ShotModels
{
    [Table("ChipShot")]
    public partial class ChipModel : ShotModel
    {
        ConvertShotsClass ConvertShotsClass = new ConvertShotsClass();

        /// <summary>
        /// Indecator of which shot model type is used by the shot:
        /// 0 = Drive, 1 = Fairway, 2 = Chip, 3 = Putt, 4 = Drop
        /// </summary>
        public int ShotType { get; } = 2;

        //Before Swing (All info about the shot before the player has hit the ball)
        //============================================================================

        /// <summary>
        /// Where is the player aiming to land in relation to the flag:
        /// 1 = Center, 2 = Left, 3 = Right
        /// </summary>
        [MaxLength(1)]
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
        /// Where on the green is the pin located in relation to the player:
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
        /// How far in on the green is the pin located in relation to the player (Back, Center, Front):
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
        /// To what side does the green break in relation to the player:
        /// 1 = Flat, 2 = Left, 3 = Right
        /// </summary>
        [MaxLength(1)]
        public Int16 _GreenBreak { get; set; } = 1;

        [Ignore]
        public String GreenBreak
        {
            get
            {
                return ConvertShotsClass.StraightLeftRightConvert(this._GreenBreak);
            }
            set
            {
                this._GreenBreak = ConvertShotsClass.StraightLeftRightConvert(value);
            }
        }

        /// <summary>
        /// At what angle is the green when the player looks at the flag:
        /// 1 = Flat, 2 = Downhill, 3 = Uphill
        /// </summary>
        public Int16 _AngleOfGreen { get; set; } = 1;

        [Ignore]
        public String AngleOfGreen
        {
            get
            {
                return ConvertShotsClass.FlatDownhillUphillConvert(this._AngleOfGreen);
            }
            set
            {
                this._AngleOfGreen = ConvertShotsClass.FlatDownhillUphillConvert(value);
            }
        }

        /// <summary>
        /// On what does the ball lie does the ball lie on the hole:
        /// 1 = Fairway, 2 = Ruff, 3 = Bunker
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
        /// On what side of the green is the ball from the fairways perspective:
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
        /// How far into the green did the ball end from the fairways perspective:
        /// 1 = Center, 2 = Short, 3 = Over
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
        
        /// <summary>
        /// At what angle is the ball:
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
        /// Where is the ball positioned in relation to the players feet:
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

        //============================================================================

        //After Swing (All info about the shot after the player has hit the ball)
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
                    DistanceLeftToHole = 0;
                    PosToHoleVer = null;
                    PosToHoleHorz = null;
                }

                _InHole = value;
            }
        }

        /// <summary>
        /// Is the ball on the green
        /// </summary>
        //TODO: Add to chip Page
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
                if (!value)
                {
                    PosToHoleVer = null;
                    PosToHoleHorz = null;
                }
                _OnGreen = value;
            }
        }

        /// <summary>
        /// TODO: Add More chip shot types
        /// What type of swing did the player use when hitting the shot:
        /// 1 = Pitch, 2 = Run, 3 = Flop
        /// </summary>
        [MaxLength(1)]
        public Int16 _SwingType { get; set; } = 1;

        [Ignore]
        public String SwingType
        {
            get
            {
                return ConvertShotsClass.PitchRunFlopConvert(this._SwingType);
            }
            set
            {
                this._SwingType = ConvertShotsClass.PitchRunFlopConvert(value);
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

        //Player is on green
        //Player missed the Hole
        //==========================

        /// <summary>
        /// On what side did the player miss the Hole:
        /// 1 = Center, 2 = Left, 3 = Right
        /// </summary>
        [MaxLength(1)]
        public Int16 _PosToHoleHorz { get; set; } = 0;

        [Ignore]
        public String PosToHoleHorz
        {
            get
            {
                return ConvertShotsClass.CenterLeftRightConvert(this._PosToHoleHorz);
            }
            set
            {
                this._PosToHoleHorz = ConvertShotsClass.CenterLeftRightConvert(value);
            }
        }

        /// <summary>
        /// How far from the Hole did the ball end (Center, Over, Short):
        /// 1 = Center, 2 = Short, 3 = Past
        /// </summary>
        [MaxLength(1)]
        public Int16 _PosToHoleVer { get; set; } = 0;

        [Ignore]
        public String PosToHoleVer
        {
            get
            {
                return ConvertShotsClass.CenterShortPastConvert(this._PosToHoleVer);
            }
            set
            {
                this._PosToHoleVer = ConvertShotsClass.CenterShortPastConvert(value);
            }
        }
        //==========================

        //============================================================================

    }
}
