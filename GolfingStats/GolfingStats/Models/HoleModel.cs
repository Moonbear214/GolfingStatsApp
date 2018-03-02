using System;
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
        /// Hole Number. 1-18
        /// </summary>
        [MaxLength(2), Unique]
        public int HoleNumber { get; set; }

        /// <summary>
        /// Par of the hole 3/4/5
        /// </summary>
        [MaxLength(1)]
        public int Par { get; set; }

        /// <summary>
        /// Stroke (Difficulty) of the hole
        /// </summary>
        [MaxLength(2)]
        public int Stroke { get; set; }

        /// <summary>
        /// Score on the hole
        /// </summary>
        [MaxLength(2)]
        public int Score { get; set; }

        /// <summary>
        /// Distance of the hole (meter)
        /// </summary>
        [MaxLength(3)]
        public int HoleDistance { get; set; }

        //TODO: Change fro, bool to value (String)
        /// <summary>
        /// Does the hole bend a direction. Left/Right/None
        /// </summary>
        //[MaxLength(5)]
        //public string Dogleg { get; set; }
        public bool Dogleg { get; set; }

        /// <summary>
        /// Fairway hit in Regulation
        /// </summary>
        public bool FIR { get; set; }

        /// <summary>
        /// Green in regulation
        /// </summary>
        public bool GIR { get; set; }

        public static ObservableCollection<HoleModel> EmptyRound { get; set; }

        static HoleModel ()
        {
            ObservableCollection<HoleModel> emptyRound = new ObservableCollection<HoleModel>();

            int i = 0;

            while (i < 18)
            {
                i++;

                HoleModel hole = new HoleModel
                {
                    HoleNumber = i,
                    Par = 4,
                    Stroke = 9,
                    Score = 4,
                    HoleDistance = 380,
                    Dogleg = false,
                    FIR = true,
                    GIR = true
                };

                emptyRound.Add(hole);
            }

            EmptyRound = emptyRound;
        }
    }
}
