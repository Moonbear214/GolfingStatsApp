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
        public int RoundId { get; set; } = 0;

        /// <summary>
        /// Id of the round of golf this hole was played on
        /// </summary>
        public int HoleId { get; set; } = 0;

        /// <summary>
        /// What number shot is this for the player on the hole
        /// </summary>
        [MaxLength(2)]
        public int ShotNumber { get; set; } = 0;

        /// <summary>
        /// Distance from where player is now to the hole
        /// </summary>
        [MaxLength(3)]
        public int DistanceToHole { get; set; } = 0;

        /// <summary>
        /// Distance player hit the ball
        /// </summary>
        [MaxLength(3)]
        public int ShotDistance { get; set; } = 0;

        /// <summary>
        /// Is the shot on the fairway/green
        /// </summary>
        public bool InPlay { get; set; } = true;

        /// <summary>
        /// Where did the ball end. Center/Left/Right
        /// </summary>
        [MaxLength(5)]
        public string BallLocation { get; set; } = null;

        /// <summary>
        /// Was the shot played a bunker shot
        /// </summary>
        public bool BunkerShot { get; set; } = false;

        /// <summary>
        /// Driver, 3/5/7 Wood, 3/5 Hybrid, 2/3/4/5/6/7/8/9 Iron, PW, 52/56/58/60 Wedge, Putter
        /// </summary>
        [MaxLength(8)]
        public string Culb { get; set; } = null;

        /// <summary>
        /// Cut, Draw, Fade, Hook, Slice
        /// </summary>
        [MaxLength(5)]
        public string ShotShape { get; set; } = null;

        /// <summary>
        /// Full, 3/4, Punch, Chip
        /// </summary>
        [MaxLength(5)]
        public string ShotType { get; set; } = null;
    }
}
