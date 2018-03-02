using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace GolfingStats.Models
{
    [Table("Shots")]
    public class ShotModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; private set; }

        /// <summary>
        /// Id of the round of golf this hole was played on
        /// </summary>
        public int RoundId { get; private set; }
        public string SetRoundId(int roundId)
        {
            if (RoundId != roundId)
            {
                RoundId = roundId;
                return RoundId.ToString();
            }
            else
                return string.Format("RoundId already set to {0}", RoundId);
        }

        /// <summary>
        /// Id of the round of golf this hole was played on
        /// </summary>
        public int HoleId { get; private set; }
        public string SetHoleId(int holeId)
        {
            if (HoleId != holeId)
            {
                HoleId = holeId;
                return HoleId.ToString();
            }
            else
                return string.Format("HoleId already set to {0}", HoleId);
        }

        /// <summary>
        /// The shot number that the player played
        /// </summary>
        [MaxLength(2)]
        public int ShotNumber { get; set; }

        /// <summary>
        /// Distance from where player is now to the hole
        /// </summary>
        [MaxLength(3)]
        public int DistanceToHole { get; set; }

        /// <summary>
        /// Distance player hit the ball
        /// </summary>
        [MaxLength(3)]
        public int ShotDistance { get; set; }

        /// <summary>
        /// Is the shot on the fairway/green
        /// </summary>
        public bool InPlay { get; set; }

        /// <summary>
        /// Where did the ball end. Center/Left/Right
        /// </summary>
        [MaxLength(5)]
        public string BallLocation { get; set; }

        /// <summary>
        /// Was the shot played a bunker shot
        /// </summary>
        public bool BunkerShot { get; set; }

        /// <summary>
        /// Driver, 3/5/7 Wood, 3/5 Hybrid, 2/3/4/5/6/7/8/9 Iron, PW, 52/56/58/60 Wedge, Putter
        /// </summary>
        [MaxLength(8)]
        public string Culb { get; set; }

        /// <summary>
        /// Cut, Draw, Fade, Hook, Slice
        /// </summary>
        [MaxLength(5)]
        public string ShotShape { get; set; }

        /// <summary>
        /// Full, 3/4, Punch, Chip
        /// </summary>
        [MaxLength(5)]
        public string ShotType { get; set; }

    }
}
