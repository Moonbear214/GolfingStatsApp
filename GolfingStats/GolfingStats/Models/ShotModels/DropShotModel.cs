using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace GolfingStats.Models.ShotModels
{
    [Table("DropShot")]
    public partial class DropShotModel : ShotModel
    {
        ConvertShotsClass ConvertShotsClass = new ConvertShotsClass();

        /// <summary>
        /// Indecator of which shot model type is used by the shot:
        /// 0 = Drive, 1 = Fairway, 2 = Chip, 3 = Putt, 4 = Drop
        /// </summary>
        public int ShotType { get; } = 4;

        //Before Swing (All info about the shot before the player has hit the ball)
        //============================================================================

        /// <summary>
        /// Reason for dropping a ball
        /// 1 = Water, 2 = Lost ball, 3 = Unplayable, 4 = Out of bounds
        /// </summary>
        [MaxLength(1)]
        public Int16 _DropReason { get; set; } = 1;

        [Ignore]
        public String DropReason
        {
            get
            {
                return ConvertShotsClass.WaterLostUnplayableBounds(this._DropReason);
            }
            set
            {
                this._DropReason = ConvertShotsClass.WaterLostUnplayableBounds(value);
            }
        }


        /// <summary>
        /// Place where player is hitting their next shot
        /// 1 = Closest point of relieve, 2 = Point of entry, 3 = Replay previous shot
        /// </summary>
        [MaxLength(1)]
        public Int16 _DropPosition { get; set; } = 1;

        [Ignore]
        public String DropPosition
        {
            get
            {
                return ConvertShotsClass.ClosestEntryReplay(this._DropPosition);
            }
            set
            {
                this._DropPosition = ConvertShotsClass.ClosestEntryReplay(value);
            }
        }

        public DropShotModel()
        {
            //TODO: Display better
            this.Club = "Drop Shot";
        }
    }
}
