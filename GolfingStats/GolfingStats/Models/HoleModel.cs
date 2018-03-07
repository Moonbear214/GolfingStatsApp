﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;

namespace GolfingStats.Models
{
    [Table("Holes")]
    public class HoleModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; private set; }

        [Indexed]
        /// <summary>
        /// Id of the round of golf this hole was played on
        /// </summary>
        public int RoundId { get; set; } = 0;

        /// <summary>
        /// Hole Number. 1-18
        /// </summary>
        [MaxLength(2)]
        public int HoleNumber { get; set; } = 0;

        /// <summary>
        /// Par of the hole 3/4/5
        /// </summary>
        [MaxLength(1)]
        public int Par { get; set; } = 4;

        /// <summary>
        /// Stroke (Difficulty) of the hole
        /// </summary>
        [MaxLength(2)]
        public int Stroke { get; set; } = 0;

        /// <summary>
        /// Score on the hole
        /// </summary>
        [MaxLength(2)]
        public int Score { get; set; } = 0;

        /// <summary>
        /// Distance of the hole (meter)
        /// </summary>
        [MaxLength(3)]
        public int HoleDistance { get; set; } = 0;

        //TODO: Change from, bool to value (String)
        /// <summary>
        /// Does the hole bend a direction. Left/Right/None
        /// </summary>
        //[MaxLength(5)]
        //public string Dogleg { get; set; }
        public bool Dogleg { get; set; } = false;

        /// <summary>
        /// Fairway hit in Regulation
        /// </summary>
        public bool FIR { get; set; } = true;

        /// <summary>
        /// Green in regulation
        /// </summary>
        public bool GIR { get; set; } = true;

        public static IList<HoleModel> EmptyRound;

        static HoleModel()
        {
            IList<HoleModel> emptyRound = new ObservableCollection<HoleModel>();

            int i = 0;

            while (i < 18)
            {
                i++;

                HoleModel hole = new HoleModel { HoleNumber = i };

                emptyRound.Add(hole);
            }

            EmptyRound = emptyRound;
        }
    }
}
