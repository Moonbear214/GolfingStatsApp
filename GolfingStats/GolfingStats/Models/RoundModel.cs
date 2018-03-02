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
        public string GolfCourse { get; set; }

        /// <summary>
        /// Date game was played on
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Total shots played in the round
        /// </summary>
        [MaxLength(3)]
        public int RoundTotal { get; set; }

        /// <summary>
        /// Player handicap when round was played
        /// </summary>
        [MaxLength(2)]
        public int Handicap { get; set; }
    }
}
