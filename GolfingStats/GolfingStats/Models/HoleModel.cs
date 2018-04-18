using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using SQLite;

namespace GolfingStats.Models
{
    [Table("Holes")]
    public class HoleModel : INotifyPropertyChanged
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
        private int _ShotsPlayed { get; set; } = 0;
        [MaxLength(2)]
        public int ShotsPlayed {
            get { return _ShotsPlayed; }
            set
            {
                this._ShotsPlayed = value;
                OnPropertyChanged("ShotsPlayed");
                OnPropertyChanged("DisplayListEmptyLabel");
                OnPropertyChanged("DisplayShotListview");
            }
        }

        /// <summary>
        /// Distance of the hole (meter)
        /// </summary>
        [MaxLength(3)]
        public int HoleDistance { get; set; } = 0;

        /// <summary>
        /// Fairway hit in Regulation
        /// (False for par 3's)
        /// </summary>
        private bool _FIR { get; set; } = false;
        public bool FIR {
            get { return _FIR; }
            set
            {
                this._FIR = value;
                OnPropertyChanged("FIR");
            }
        }

        /// <summary>
        /// Green in regulation
        /// </summary>
        private bool _GIR { get; set; } = false;
        public bool GIR
        {
            get { return _GIR; }
            set
            {
                this._GIR = value;
                OnPropertyChanged("GIR");
            }
        }

        [Ignore]
        public ObservableCollection<ShotModels.ShotModel> ShotsPlayedList { get; set; } = new ObservableCollection<ShotModels.ShotModel>();

        public event PropertyChangedEventHandler PropertyChanged;

        [Ignore]
        public bool DisplayListEmptyLabel {
            get
            {
                if (ShotsPlayed == 0)
                    return true;
                else
                    return false;
            }
        }

        [Ignore]
        public bool DisplayShotListview
        {
            get
            {
                if (ShotsPlayed != 0)
                    return true;
                else
                    return false;
            }
        }

        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(v));
        }

        //TODO: Add a lot of extra information to let the player discribe the hole when creating it

        /// <summary>
        /// Does the hole bend a direction. Left/Right/None
        /// </summary>
        //[MaxLength(5)]
        //public string Dogleg { get; set; }
        //public bool Dogleg { get; set; } = false;

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
