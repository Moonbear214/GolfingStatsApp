using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;

namespace GolfingStats.Models
{
    [Table("Courses")]
    public class CourseModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; private set; }

        [Indexed]
        /// <summary>
        /// Name of the course that the user creates
        /// </summary>
        public string Name { get; set; } = null;

        /// <summary>
        /// Name of the course that the user creates
        /// </summary>
        public int Par { get; set; } = 0;

        /// <summary>
        /// List of all the holes that the player creates that is on the course
        /// </summary>
        public int Hole1 { get; private set; } = 0;
        public int Hole2 { get; private set; } = 0;
        public int Hole3 { get; private set; } = 0;
        public int Hole4 { get; private set; } = 0;
        public int Hole5 { get; private set; } = 0;
        public int Hole6 { get; private set; } = 0;
        public int Hole7 { get; private set; } = 0;
        public int Hole8 { get; private set; } = 0;
        public int Hole9 { get; private set; } = 0;
        public int Hole10 { get; private set; } = 0;
        public int Hole11 { get; private set; } = 0;
        public int Hole12 { get; private set; } = 0;
        public int Hole13 { get; private set; } = 0;
        public int Hole14 { get; private set; } = 0;
        public int Hole15 { get; private set; } = 0;
        public int Hole16 { get; private set; } = 0;
        public int Hole17 { get; private set; } = 0;
        public int Hole18 { get; private set; } = 0;

        //===================================================================================================================================

        /// <summary>
        /// Sets the hole IDs that are on this course.
        /// Must only be called once! (When the course is created )
        /// </summary>
        [Ignore]
        public List<HoleModel> SetHoleIds
        {
            set
            {
                foreach (var hole in value)
                {
                    switch (hole.HoleNumber)
                    {
                        case 1:
                            this.Hole1 = hole.Id;
                            break;
                        case 2:
                            this.Hole2 = hole.Id;
                            break;
                        case 3:
                            this.Hole3 = hole.Id;
                            break;
                        case 4:
                            this.Hole4 = hole.Id;
                            break;
                        case 5:
                            this.Hole5 = hole.Id;
                            break;
                        case 6:
                            this.Hole6 = hole.Id;
                            break;
                        case 7:
                            this.Hole7 = hole.Id;
                            break;
                        case 8:
                            this.Hole8 = hole.Id;
                            break;
                        case 9:
                            this.Hole9 = hole.Id;
                            break;
                        case 10:
                            this.Hole10 = hole.Id;
                            break;
                        case 11:
                            this.Hole11 = hole.Id;
                            break;
                        case 12:
                            this.Hole12 = hole.Id;
                            break;
                        case 13:
                            this.Hole13 = hole.Id;
                            break;
                        case 14:
                            this.Hole14 = hole.Id;
                            break;
                        case 15:
                            this.Hole15 = hole.Id;
                            break;
                        case 16:
                            this.Hole16 = hole.Id;
                            break;
                        case 17:
                            this.Hole17 = hole.Id;
                            break;
                        case 18:
                            this.Hole18 = hole.Id;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Returns a list of Ids of the holes that are on this course.
        /// The holes will be saved in local storage with a round ID if 0,
        /// to know that it is not a hole that was played in a round.
        /// </summary>
        [Ignore]
        public List<int> GetHoleIds
        {
            get
            {
                List<int> holes = new List<int>()
                {
                    Hole1,
                    Hole2,
                    Hole3,
                    Hole4,
                    Hole5,
                    Hole6,
                    Hole7,
                    Hole8,
                    Hole9,
                    Hole10,
                    Hole11,
                    Hole12,
                    Hole13,
                    Hole14,
                    Hole15,
                    Hole16,
                    Hole17,
                    Hole18
                };

                return holes;
            }
        }

        //===================================================================================================================================

            //When the course model is called a list is created of holes that is used on the course.
            //If it is a new CourseModel object the Id will be 0 and an empty round will be given as te course holes else,
            //all the hole Ids will be searched for and objects will be added in the "Holes" list that can be accesses at any time.
        //===================================================================================================================================

        public List<HoleModel> Holes = new List<HoleModel>();
        
    }
}
