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

        /// <summary>
        /// Player handicap when round was played (-11 = Value has not been assigned yet)
        /// </summary>
        [MaxLength(2)]
        public float Handicap { get; set; } = -11;
    }
}
