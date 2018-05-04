using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GolfingStats.Models;
using GolfingStats.Models.ShotModels;

namespace GolfingStats.Factories
{
    public class StatisticsFactory
    {
        /// <summary>
        /// If the 'updateStats' bool in the Round object is true, when the round is loaded it's statistics will first be calculated and saved before it is displayed.
        /// </summary>
        /// <param name="round"></param>
        /// <param name="holes"></param>
        /// <param name="shots"></param>
        /// <returns></returns>
        public RoundModel CalculateRoundStats(RoundModel round, List<HoleModel> holes, List<ShotModel> shots)
        {
            (round.Eagles, round.Birdies, round.Pars, round.Bogeys, round.DoubleBogeys, round.TripleBogeysPlus) = CountDifferentScores(holes);
            round.FIRPerc = FIRPercCalc(holes);
            (round.FIRMissLeft, round.FIRMissRight) = FIRSideMissTotals(shots);
            round.GIRPerc = GIRPercCalc(holes);
            (round.GIRMissLeft, round.GIRMissRight, round.GIRMissShort, round.GIRMissOver) = GIRLocationMissTotals(shots);
            (round.PuttsOne, round.PuttsTwo, round.PuttsThreePlus) = CalculateTotalPuttsCountMisses(shots);
            (round.PuttsLeft, round.PuttsRight, round.PuttsShort, round.PuttsPast) = CalculateTotalPuttsSideMisses(shots);
            round.Scrambling = CalcScramblingPerc(holes);

            round.ReloadStats = false;
            return round;
        }

        //==========================================================================================================================
        
        // All methods from here on are written with the entent to be reusable for any future statistics that would also have to be calculated.
        //=========================================================================

        /// <summary>
        /// Count how many eagles, birdies, pars, bogeys, double bogeys, triple bogeys+ were played in a round
        /// </summary>
        /// <param name="holes"></param>
        /// <returns></returns>
        (int, int, int, int, int, int) CountDifferentScores(List<HoleModel> holes)
        {
            int Eagles = 0;
            int Birdies = 0;
            int Pars = 0;
            int Bogeys = 0;
            int DBogeys = 0;
            int TBogeysPlus = 0;
            foreach (HoleModel hole in holes)
            {
                if (hole.Par == 3)
                {
                    if (hole.ShotsPlayed == 1)
                        Eagles++;
                    else if (hole.ShotsPlayed == 2)
                        Birdies++;
                    else if (hole.ShotsPlayed == 3)
                        Pars++;
                    else if (hole.ShotsPlayed == 4)
                        Bogeys++;
                    else if (hole.ShotsPlayed == 5)
                        DBogeys++;
                    else if (hole.ShotsPlayed >= 6)
                        TBogeysPlus++;
                }
                else if (hole.Par == 4)
                {
                    if (hole.ShotsPlayed == 2)
                        Eagles++;
                    else if (hole.ShotsPlayed == 3)
                        Birdies++;
                    else if (hole.ShotsPlayed == 4)
                        Pars++;
                    else if (hole.ShotsPlayed == 5)
                        Bogeys++;
                    else if (hole.ShotsPlayed == 6)
                        DBogeys++;
                    else if (hole.ShotsPlayed >= 7)
                        TBogeysPlus++;
                }
                else if (hole.Par == 5)
                {
                    if (hole.ShotsPlayed == 3)
                        Eagles++;
                    else if (hole.ShotsPlayed == 4)
                        Birdies++;
                    else if (hole.ShotsPlayed == 5)
                        Pars++;
                    else if (hole.ShotsPlayed == 6)
                        Bogeys++;
                    else if (hole.ShotsPlayed == 7)
                        DBogeys++;
                    else if (hole.ShotsPlayed >= 8)
                        TBogeysPlus++;
                }
            }
            return (Eagles, Birdies, Pars, Bogeys, DBogeys, TBogeysPlus);
        }
        //=========================================================================

        /// <summary>
        /// Calculate how percentage of fairways that were hit in the round
        /// and count up where all the misses were.
        /// (Par 3's does not count as fairway hit, only par 4's and 5's)
        /// </summary>
        /// <param name="holes"></param>
        /// <returns></returns>
        float FIRPercCalc(List<HoleModel> holes)
        {
            float FIRPerc = 0;
            int numOfFairwayHoles = 0;

            foreach (HoleModel hole in holes)
            {
                if (hole.Par == 4 || hole.Par == 5)
                {
                    numOfFairwayHoles++;
                    if (hole.FIR)
                        FIRPerc++;
                }
            }
            return ((FIRPerc * 100) / numOfFairwayHoles);
        }

        (int, int) FIRSideMissTotals(List<ShotModel> shots)
        {
            int FIRMissLeft = 0;
            int FIRMissRight = 0;

            foreach (ShotModel shot in shots)
            {
                if (shot.GetType() == typeof(DriveModel))
                {
                    if (!((DriveModel)shot).OnFairway)
                    {
                        if (((DriveModel)shot).PosToFairwayHorz == "Left")
                            FIRMissLeft++;
                        else if (((DriveModel)shot).PosToFairwayHorz == "Right")
                            FIRMissRight++;
                    }
                }
            }
            return (FIRMissLeft, FIRMissRight);
        }
        //=========================================================================

        /// <summary>
        /// Calculate the number of greens that were hit in regulation
        /// and count up where all the misses were.
        /// </summary>
        /// <param name="holes"></param>
        /// <returns></returns>
        float GIRPercCalc(List<HoleModel> holes)
        {
            float GIRPerc = 0;
            foreach (HoleModel hole in holes)
            {
                if (hole.GIR == true)
                    GIRPerc++;
            }
            return ((GIRPerc * 100) / 18);
        }

        (int, int, int, int) GIRLocationMissTotals(List<ShotModel> shots)
        {
            int GIRMissLeft = 0;
            int GIRMissRight = 0;
            int GIRMissShort = 0;
            int GIRMissPast = 0;

            foreach (ShotModel shot in shots)
            {
                if (shot.GetType() == typeof(ApproachModel))
                {
                    if (!((ApproachModel)shot).OnGreen && !((ApproachModel)shot).LayupShot)
                    {
                        if (((ApproachModel)shot).PosToGreenHorz == "Left")
                            GIRMissLeft++;
                        else if (((ApproachModel)shot).PosToGreenHorz == "Right")
                            GIRMissRight++;
                        if (((ApproachModel)shot).PosToGreenVer == "Short")
                            GIRMissShort++;
                        else if (((ApproachModel)shot).PosToGreenVer == "Past")
                            GIRMissPast++;
                    }
                }
            }
            return (GIRMissLeft, GIRMissRight, GIRMissShort, GIRMissPast);
        }
        //=========================================================================

        /// <summary>
        /// Creates a list of putts, check how many of them were played on the same hole
        /// and returns the number of 1, 2 and 3+ putts.
        /// </summary>
        /// <param name="shots"></param>
        /// <returns></returns>
        (int, int, int) CalculateTotalPuttsCountMisses(List<ShotModel> shots)
        {
            int Putts1 = 0;
            int Putts2 = 0;
            int Putts3plus = 0;
            List<int> AllPuttsHoleIds = new List<int>();
            foreach (ShotModel shot in shots)
            {
                if (shot.GetType() == typeof(PuttModel))
                {
                    AllPuttsHoleIds.Add(shot.HoleId);
                }
            }
            Dictionary<int, int> PuttsPerHoleId = AllPuttsHoleIds.GroupBy(ptt => ptt).ToDictionary(group => group.Key, group => group.Count());
            Dictionary<int, int> HolePuttTotalsCount = new Dictionary<int, int>();

            //Iterate through the values, setting count to 1 or incrementing current count.
            foreach (int i in PuttsPerHoleId.Values)
            {
                if (HolePuttTotalsCount.ContainsKey(i))
                    HolePuttTotalsCount[i]++;
                else
                    HolePuttTotalsCount[i] = 1;
            }
            foreach (KeyValuePair<int, int> kvp in HolePuttTotalsCount)
            {
                if (kvp.Key == 1)
                {
                    Putts1 = kvp.Value;
                }
                else if (kvp.Key == 2)
                {
                    Putts2 = kvp.Value;
                }
                else
                {
                    Putts3plus += kvp.Value;
                }
            }
            return (Putts1, Putts2, Putts3plus);
        }
        //=========================================================================
        
        /// <summary>
        /// Checks how many the putts played were missed left, right, short or past.
        /// </summary>
        /// <param name="shots"></param>
        /// <returns></returns>
        (int, int, int, int) CalculateTotalPuttsSideMisses(List<ShotModel> shots)
        {
            int puttsL = 0;
            int puttsR = 0;
            int puttsS = 0;
            int puttsP = 0;
            List<PuttModel> AllPutts = new List<PuttModel>();
            foreach (ShotModel shot in shots)
            {
                if (shot.GetType() == typeof(PuttModel))
                {
                    if (((PuttModel)shot).InHole == false)
                    {
                        if (((PuttModel)shot).PosToHoleHorz == "Left")
                            puttsL++;
                        else if (((PuttModel)shot).PosToHoleHorz == "Right")
                            puttsR++;
                        if (((PuttModel)shot).PosToHoleVer == "Short")
                            puttsS++;
                        else if (((PuttModel)shot).PosToHoleVer == "Past")
                            puttsP++;
                    }
                }
            }
            return (puttsL, puttsR, puttsS, puttsP);
        }
        //=========================================================================

        /// <summary>
        /// Checks if the player scrambled on the hole and returns the total of it.
        /// (Scramble: Missed green in regulation and still saved par)
        /// </summary>
        /// <param name="holes"></param>
        /// <returns></returns>
        float CalcScramblingPerc(List<HoleModel> holes)
        {
            int ScramblingTotal = 0;
            foreach (HoleModel hole in holes)
            {
                if (!hole.GIR && hole.ShotsPlayed <= hole.Par)
                    ScramblingTotal++;
            }
            return ScramblingTotal;
        }
        //=========================================================================
        //==========================================================================================================================
    }
}
