using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace GolfingStats.Models
{
    [Table("Rounds")]
    public class RoundModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; private set; }

        /// <summary>
        /// Name of the golf course the round was played on
        /// </summary>
        [MaxLength(40)]
        public string CourseName { get; set; } = null;

        /// <summary>
        /// Id of the course the round was played on
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// Date game was played on
        /// </summary>
        public DateTime Date { get; set; } = DateTime.Today;

        /// <summary>
        /// Par round for the golf course
        /// </summary>
        [MaxLength(2)]
        public int RoundTotal { get; set; } = 0;

        /// <summary>
        /// Total shots played in the round
        /// </summary>
        [MaxLength(3)]
        public int ShotsTotal { get; set; } = 0;

        [Ignore]
        public int ShotsToPar
        {
            get
            {
                return ((ShotsTotal - RoundTotal) >= 0) ? (ShotsTotal - RoundTotal) : 0;
            }
        }

        /// <summary>
        /// Player handicap when round was played (-11 = Value has not been assigned yet)
        /// </summary>
        [MaxLength(2)]
        public float Handicap { get; set; } = -11;

        //Round statistics values
        //==========================================================

        public bool ReloadStats { get; set; } = true;

        public int Eagles { get; set; } = 0;
        public int Birdies { get; set; } = 0;
        public int Pars { get; set; } = 0;
        public int Bogeys { get; set; } = 0;
        public int DoubleBogeys { get; set; } = 0;
        public int TripleBogeysPlus { get; set; } = 0;

        public float FIRPerc { get; set; } = 0;
        public int FIRPDisplay { get { return Convert.ToInt32(FIRPerc); } }
        public int FIRMissLeft { get; set; } = 0;
        public int FIRMissRight { get; set; } = 0;

        public float GIRPerc { get; set; } = 0;
        public int GIRPDisplay { get { return Convert.ToInt32(GIRPerc); } }
        public int GIRMissLeft { get; set; } = 0;
        public int GIRMissRight { get; set; } = 0;
        public int GIRMissShort { get; set; } = 0;
        public int GIRMissOver { get; set; } = 0;

        public int PuttsOne { get; set; } = 0;
        public int PuttsTwo { get; set; } = 0;
        public int PuttsThreePlus { get; set; } = 0;
        public int PuttsLeft { get; set; } = 0;
        public int PuttsRight { get; set; } = 0;
        public int PuttsShort { get; set; } = 0;
        public int PuttsPast { get; set; } = 0;

        public float Scrambling { get; set; } = 0;
    }
}
