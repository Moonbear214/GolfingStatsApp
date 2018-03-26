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
        
        [Indexed]
        /// <summary>
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
        public int ShotsPlayed { get; set; } = 0;

        /// <summary>
        /// Distance of the hole (meter)
        /// </summary>
        [MaxLength(3)]
        public int HoleDistance { get; set; } = 0;

        /// <summary>
        /// Fairway hit in Regulation
        /// </summary>
        public bool FIR { get; set; } = false;

        /// <summary>
        /// Green in regulation
        /// </summary>
        public bool GIR { get; set; } = true;

        //TODO: Add a lot of extra information to let the player discribe the hole when creating it

        //TODO: Change from, bool to value (String)
        /// <summary>
        /// Does the hole bend a direction. Left/Right/None
        /// </summary>
        //[MaxLength(5)]
        //public string Dogleg { get; set; }
        //public bool Dogleg { get; set; } = false;

        //====================Test===============================
        [Ignore]
        public IList<ShotModels.ShotModel> ShotsPlayedList { get; set; } = new ObservableCollection<ShotModels.ShotModel>();
        //====================Test===============================


        /// <summary>
        /// A variable that holds 18 holes inside that has no values assigned to them yet other than default.
        /// For use when creating a new round or any scenario that needs a list of 18 empty holes models
        /// </summary>
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
