using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

using GolfingStats.Models.ShotModels;

namespace GolfingStats.Models.ShotModels
{
    [Table("PuttShot")]
    public partial class PuttModel : ShotModel
    {
        ConvertShotsClass ConvertShotsClass = new ConvertShotsClass();

        /// <summary>
        /// Indecator of which shot model type is used by the shot:
        /// 0 = Drive, 1 = Fairway, 2 = Chip, 3 = Putt
        /// </summary>
        public int ShotType { get; } = 3;

        //Before Swing (All info about the shot before the player has hit the ball)
        //============================================================================

        /// <summary>
        /// Where is the player aiming to putt in relation to the flag: 
        /// 1 = Straight, 2 = Left, 3 = Right
        /// </summary>
        [MaxLength(1)]
        public Int16 _Aiming { get; set; } = 0;

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
        /// How far is the player in the given direction: 
        /// 1 = Inside, 2 = Edge, 3 = Ball, 4 = 2Cups, 5 = 3Cups, 6 = 4Cups, 7 = 1/2Meter, 8 = 3/4Meter, 9 = Meter
        /// </summary>
        [MaxLength(2)]
        public Int16 _AimingDistance { get; set; } = 0;

        [Ignore]
        public String AimingDistance
        {
            get
            {
                return ConvertShotsClass.PuttingAimingDistance(this._AimingDistance);
            }
            set
            {
                this._AimingDistance = ConvertShotsClass.PuttingAimingDistance(value);
            }
        }

        /// <summary>
        /// To what side will the green break in relation to the player: 
        /// 1 = Center, 2 = Left, 3 = Right
        /// </summary>
        [MaxLength(1)]
        public Int16 _GreenBreak { get; set; } = 0;

        [Ignore]
        public String GreenBreak
        {
            get
            {
                return ConvertShotsClass.CenterLeftRightConvert(this._GreenBreak);
            }
            set
            {
                this._GreenBreak = ConvertShotsClass.CenterLeftRightConvert(value);
            }
        }

        /// <summary>
        /// At what angle is the green when the player looks at the flag:
        /// 1 = Flat, 2 = Uphill, 3 = Downhill
        /// </summary>
        [MaxLength(1)]
        public Int16 _AngleOfGreen { get; set; } = 0;

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
        /// On which side did the player miss the Hole:
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
        /// Is the ball Center to the hole, Past or Short:
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

        /// <summary>
        /// How far is the ball still from the hole
        /// </summary>
        [MaxLength(2)]
        public int DistanceLeftToHole { get; set; } = 0;
        //==========================

        /// <summary>
        /// How hard did the player putt the ball compared to the distance the player had:
        /// 1 = Soft, 2 = Medium, 3 = Hard, 4 = Very Hard
        /// </summary>
        public Int16 _PullBackStrength { get; set; } = 0;

        [Ignore]
        public String PullBackStrength
        {
            get
            {
                return ConvertShotsClass.SoftMediumHardVeryConvert(this._PullBackStrength);
            }
            set
            {
                this._PullBackStrength = ConvertShotsClass.SoftMediumHardVeryConvert(value);
            }
        }
        //============================================================================

    }
}
