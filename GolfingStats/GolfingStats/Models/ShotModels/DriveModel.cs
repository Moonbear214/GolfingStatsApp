using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace GolfingStats.Models.ShotModels
{
    [Table("DriveShot")]
    public partial class DriveModel : ShotModel
    {
        ConvertShotsClass ConvertShotsClass = new ConvertShotsClass();

        /// <summary>
        /// Indecator of which shot model type is used by the shot:
        /// 0 = Drive, 1 = Fairway, 2 = Chip, 3 = Putt
        /// </summary>
        public int ShotType { get; } = 0;

        //Before Swing (All info about the shot before the player has hit the ball)
        //============================================================================

        /// <summary>
        /// Where is the player aiming to land on the fairway:
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
        /// Force of the wind:
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
                if(value == "None")
                {
                    WindDirection = null;
                }
                this._WindForce = ConvertShotsClass.NoneLightMediumStrongConvert(value);
            }
        }

        /// <summary>
        /// Direction that the wind is blowing:
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

        //After Swing (All info about the shot after the player has hit the ball)
        //============================================================================

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
        public Int16 _BallFlight { get; set; } = 1;

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
        /// Is the ball on the fairway
        /// </summary>
        public bool _OnFairway { get; set; } = true;

        [Ignore]
        public bool OnFairway
        {
            get
            {
                return _OnFairway;
            }
            set
            {
                if(value)
                {
                    PosToFairwayHorz = null;
                }
                else
                {
                    PosToFairwayHorz = null;
                }
                _OnFairway = value;
            }
        }

        //Player did end on the Fairway
        //==========================
        /// <summary>
        /// On which side of the fairway did the ball end:
        /// 1 = Center, 2 = Left, 3 = Right
        /// </summary>
        [MaxLength(1)]
        public Int16 _PosOnFairwayHorz { get; set; } = 1;

        [Ignore]
        public String PosOnFairwayHorz
        {
            get
            {
                return ConvertShotsClass.CenterLeftRightConvert(this._PosOnFairwayHorz);
            }
            set
            {
                this._PosOnFairwayHorz = ConvertShotsClass.CenterLeftRightConvert(value);
            }
        }

        //==========================

        //Player missed the Fairway
        //==========================
        /// <summary>
        /// On what side did the player miss the Fairway:
        /// 1 = Center, 2 = Left, 3 = Right
        /// </summary>
        [MaxLength(0)]
        public Int16 _PosToFairwayHorz { get; set; } = 0;

        [Ignore]
        public String PosToFairwayHorz
        {
            get
            {
                return ConvertShotsClass.CenterLeftRightConvert(this._PosToFairwayHorz);
            }
            set
            {
                this._PosToFairwayHorz = ConvertShotsClass.CenterLeftRightConvert(value);
            }
        }

        //==========================
        //============================================================================

        public DriveModel()
        {
            this.Club = "Driver";
        }
    }
}
