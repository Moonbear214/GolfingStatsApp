using System;
using System.Collections.Generic;
using System.Text;

namespace GolfingStats.Models.ShotModels
{
    public class ConvertShotsClass
    {
        /// <summary>
        /// Converts the values of the shots from integers to strings to be displayed to the user
        /// </summary>
        
        //=========================================================================================================
        /// <summary>
        /// Converts Center Left and Right values to string or integer depending on what is needed:
        /// 1 = Center, 2 = Left, 3 = Right
        /// </summary>
        public string CenterLeftRightConvert(Int16 valueParam)
        {
            String Value = null;

            switch (valueParam)
            {
                case 0:
                    Value = null;
                    break;
                case 1:
                    Value = "Center";
                    break;
                case 2:
                    Value = "Left";
                    break;
                case 3:
                    Value = "Right";
                    break;
            }

            return Value;
        }

        public Int16 CenterLeftRightConvert(String valueParam)
        {
            Int16 Value = 0;

            switch (valueParam)
            {
                case null:
                    Value = 0;
                    break;
                case "Center":
                    Value = 1;
                    break;
                case "Left":
                    Value = 2;
                    break;
                case "Right":
                    Value = 3;
                    break;
            }

            return Value;
        }
        //=========================================================================================================

        //=========================================================================================================
        /// <summary>
        /// Converts None, Light, Medium and Strong values to string or integer depending on what is needed:
        /// 1 = None, 2 = Light, 3 = Medium, 4 = Strong
        /// </summary>
        public string NoneLightMediumStrongConvert(Int16 valueParam)
        {
            String Value = null;

            switch (valueParam)
            {
                case 0:
                    Value = null;
                    break;
                case 1:
                    Value = "None";
                    break;
                case 2:
                    Value = "Light";
                    break;
                case 3:
                    Value = "Medium";
                    break;
                case 4:
                    Value = "Strong";
                    break;
            }

            return Value;
        }

        public Int16 NoneLightMediumStrongConvert(String valueParam)
        {
            Int16 Value = 0;

            switch (valueParam)
            {
                case null:
                    Value = 0;
                    break;
                case "None":
                    Value = 1;
                    break;
                case "Light":
                    Value = 2;
                    break;
                case "Medium":
                    Value = 3;
                    break;
                case "Strong":
                    Value = 4;
                    break;
            }

            return Value;
        }
        //=========================================================================================================

        //=========================================================================================================
        /// <summary>
        /// Converts Left, Right, Towards and Away values to string or integer depending on what is needed:
        /// 1 = Left, 2 = Right, 3 = Towards, 4 = Away
        /// </summary>
        public string LeftRightTowardsAwayConvert(Int16 valueParam)
        {
            String Value = null;

            switch (valueParam)
            {
                case 0:
                    Value = null;
                    break;
                case 1:
                    Value = "Left";
                    break;
                case 2:
                    Value = "Right";
                    break;
                case 3:
                    Value = "Towards";
                    break;
                case 4:
                    Value = "Away";
                    break;
            }

            return Value;
        }

        public Int16 LeftRightTowardsAwayConvert(String valueParam)
        {
            Int16 Value = 0;

            switch (valueParam)
            {
                case null:
                    Value = 0;
                    break;
                case "Left":
                    Value = 1;
                    break;
                case "Right":
                    Value = 2;
                    break;
                case "Towards":
                    Value = 3;
                    break;
                case "Away":
                    Value = 4;
                    break;
            }

            return Value;
        }
        //=========================================================================================================

        //=========================================================================================================
        /// <summary>
        /// Converts Full, 3/4, Punch and KnockDown values to string or integer depending on what is needed:
        /// 1 = Full, 2 = 3/4, 3 = Punch, 4 = KnockDown
        /// </summary>
        public string Full34PunchKnockDownConvert(Int16 valueParam)
        {
            String Value = null;

            switch (valueParam)
            {
                case 0:
                    Value = null;
                    break;
                case 1:
                    Value = "Full";
                    break;
                case 2:
                    Value = "3/4";
                    break;
                case 3:
                    Value = "Punch";
                    break;
                case 4:
                    Value = "KnockDown";
                    break;
            }

            return Value;
        }

        public Int16 Full34PunchKnockDownConvert(String valueParam)
        {
            Int16 Value = 0;

            switch (valueParam)
            {
                case null:
                    Value = 0;
                    break;
                case "Full":
                    Value = 1;
                    break;
                case "3/4":
                    Value = 2;
                    break;
                case "Punch":
                    Value = 3;
                    break;
                case "KnockDown":
                    Value = 4;
                    break;
            }

            return Value;
        }
        //=========================================================================================================


        //=========================================================================================================
        /// <summary>
        /// Converts Draw, Cut, Hook, Fade and Slice values to string or integer depending on what is needed:
        /// 1 = Draw, 2 = Cut, 3 = Hook, 4 = Fade, 5 = Slice
        /// </summary>
        public string DrawCutHookFadeSliceConvert(Int16 valueParam)
        {
            String Value = null;

            switch (valueParam)
            {
                case 0:
                    Value = null;
                    break;
                case 1:
                    Value = "Draw";
                    break;
                case 2:
                    Value = "Cut";
                    break;
                case 3:
                    Value = "Hook";
                    break;
                case 4:
                    Value = "Fade";
                    break;
                case 5:
                    Value = "Slice";
                    break;
            }

            return Value;
        }

        public Int16 DrawCutHookFadeSliceConvert(String valueParam)
        {
            Int16 Value = 0;

            switch (valueParam)
            {
                case null:
                    Value = 0;
                    break;
                case "Draw":
                    Value = 1;
                    break;
                case "Cut":
                    Value = 2;
                    break;
                case "Hook":
                    Value = 3;
                    break;
                case "Fade":
                    Value = 4;
                    break;
                case "Slice":
                    Value = 5;
                    break;
            }

            return Value;
        }
        //=========================================================================================================

        //=========================================================================================================
        /// <summary>
        /// Converts Center, Front and Back values to string or integer depending on what is needed:
        /// 1 = Center, 2 = Front, 3 = Back
        /// </summary>
        public string CenterFrontBackConvert(Int16 valueParam)
        {
            String Value = null;

            switch (valueParam)
            {
                case 0:
                    Value = null;
                    break;
                case 1:
                    Value = "Center";
                    break;
                case 2:
                    Value = "Front";
                    break;
                case 3:
                    Value = "Back";
                    break;
            }

            return Value;
        }

        public Int16 CenterFrontBackConvert(String valueParam)
        {
            Int16 Value = 0;

            switch (valueParam)
            {
                case null:
                    Value = 0;
                    break;
                case "Center":
                    Value = 1;
                    break;
                case "Front":
                    Value = 2;
                    break;
                case "Back":
                    Value = 3;
                    break;
            }

            return Value;
        }
        //=========================================================================================================

        //=========================================================================================================
        /// <summary>
        /// Converts Flat, Flat and Uphill values to string or integer depending on what is needed:
        /// 1 = Flat, 2 = , 3 = Uphill
        /// </summary>
        public string FlatDownhillUphillConvert(Int16 valueParam)
        {
            String Value = null;

            switch (valueParam)
            {
                case 0:
                    Value = null;
                    break;
                case 1:
                    Value = "Flat";
                    break;
                case 2:
                    Value = "Downhill";
                    break;
                case 3:
                    Value = "Uphill";
                    break;
            }

            return Value;
        }

        public Int16 FlatDownhillUphillConvert(String valueParam)
        {
            Int16 Value = 0;

            switch (valueParam)
            {
                case null:
                    Value = 0;
                    break;
                case "Flat":
                    Value = 1;
                    break;
                case "Downhill":
                    Value = 2;
                    break;
                case "Uphill":
                    Value = 3;
                    break;
            }

            return Value;
        }
        //=========================================================================================================

        //=========================================================================================================
        /// <summary>
        /// Converts Fairway, Ruff and Bunker values to string or integer depending on what is needed:
        /// 1 = Fairway, 2 = Ruff, 3 = Bunker
        /// </summary>
        public string FairwayRuffBunkerConvert(Int16 valueParam)
        {
            String Value = null;

            switch (valueParam)
            {
                case 0:
                    Value = null;
                    break;
                case 1:
                    Value = "Fairway";
                    break;
                case 2:
                    Value = "Ruff";
                    break;
                case 3:
                    Value = "Bunker";
                    break;
            }

            return Value;
        }

        public Int16 FairwayRuffBunkerConvert(String valueParam)
        {
            Int16 Value = 0;

            switch (valueParam)
            {
                case null:
                    Value = 0;
                    break;
                case "Fairway":
                    Value = 1;
                    break;
                case "Ruff":
                    Value = 2;
                    break;
                case "Bunker":
                    Value = 3;
                    break;
            }

            return Value;
        }
        //=========================================================================================================

        //=========================================================================================================
        /// <summary>
        /// Converts Sqaure, Below and Bunker values to string or integer depending on what is needed:
        /// 1 = Sqaure, 2 = Below, 3 = Above
        /// </summary>
        public string SqaureBelowAboveConvert(Int16 valueParam)
        {
            String Value = null;

            switch (valueParam)
            {
                case 0:
                    Value = null;
                    break;
                case 1:
                    Value = "Sqaure";
                    break;
                case 2:
                    Value = "Below";
                    break;
                case 3:
                    Value = "Above";
                    break;
            }

            return Value;
        }

        public Int16 SqaureBelowAboveConvert(String valueParam)
        {
            Int16 Value = 0;

            switch (valueParam)
            {
                case null:
                    Value = 0;
                    break;
                case "Sqaure":
                    Value = 1;
                    break;
                case "Below":
                    Value = 2;
                    break;
                case "Above":
                    Value = 3;
                    break;
            }

            return Value;
        }
        //=========================================================================================================

        //=========================================================================================================
        /// <summary>
        /// Converts Center, Short and Past values to string or integer depending on what is needed:
        /// 1 = Center, 2 = Short, 3 = Past
        /// </summary>
        public string CenterShortPastConvert(Int16 valueParam)
        {
            String Value = null;

            switch (valueParam)
            {
                case 0:
                    Value = null;
                    break;
                case 1:
                    Value = "Center";
                    break;
                case 2:
                    Value = "Short";
                    break;
                case 3:
                    Value = "Past";
                    break;
            }

            return Value;
        }

        public Int16 CenterShortPastConvert(String valueParam)
        {
            Int16 Value = 0;

            switch (valueParam)
            {
                case null:
                    Value = 0;
                    break;
                case "Center":
                    Value = 1;
                    break;
                case "Short":
                    Value = 2;
                    break;
                case "Past":
                    Value = 3;
                    break;
            }

            return Value;
        }
        //=========================================================================================================

        //=========================================================================================================
        /// <summary>
        /// Converts Pitch, Run and Over values to string or integer depending on what is needed:
        /// 1 = Pitch, 2 = Run, 3 = Flop
        /// </summary>
        public string PitchRunFlopConvert(Int16 valueParam)
        {
            String Value = null;

            switch (valueParam)
            {
                case 0:
                    Value = null;
                    break;
                case 1:
                    Value = "Pitch";
                    break;
                case 2:
                    Value = "Run";
                    break;
                case 3:
                    Value = "Flop";
                    break;
            }

            return Value;
        }

        public Int16 PitchRunFlopConvert(String valueParam)
        {
            Int16 Value = 0;

            switch (valueParam)
            {
                case null:
                    Value = 0;
                    break;
                case "Pitch":
                    Value = 1;
                    break;
                case "Run":
                    Value = 2;
                    break;
                case "Flop":
                    Value = 3;
                    break;
            }

            return Value;
        }
        //=========================================================================================================

        //=========================================================================================================
        /// <summary>
        /// Converts None, Little, Medium and Much values to string or integer depending on what is needed:
        /// 1 = None, 2 = Little, 3 = Medium, 4 = Much
        /// </summary>
        public string NoneLittleMediumMuchConvert(Int16 valueParam)
        {
            String Value = null;

            switch (valueParam)
            {
                case 0:
                    Value = null;
                    break;
                case 1:
                    Value = "None";
                    break;
                case 2:
                    Value = "Little";
                    break;
                case 3:
                    Value = "Medium";
                    break;
                case 4:
                    Value = "Much";
                    break;
            }

            return Value;
        }

        public Int16 NoneLittleMediumMuchConvert(String valueParam)
        {
            Int16 Value = 0;

            switch (valueParam)
            {
                case null:
                    Value = 0;
                    break;
                case "None":
                    Value = 1;
                    break;
                case "Little":
                    Value = 2;
                    break;
                case "Medium":
                    Value = 3;
                    break;
                case "Much":
                    Value = 4;
                    break;
            }

            return Value;
        }
        //=========================================================================================================

        //=========================================================================================================
        /// <summary>
        /// Converts Putting aiming distance values to string or integer depending on what is needed:
        /// 1 = Inside, 2 = Edge, 3 = , 4 = Cup, 5 = 2Cups, 6 = 3Cups, 7 = 4Cups, 8 = 1/2Meter, 9 = 3/4Meter, 10 = Meter
        /// </summary>
        public string PuttingAimingDistance(Int16 valueParam)
        {
            String Value = null;

            switch (valueParam)
            {
                case 0:
                    Value = null;
                    break;
                case 1:
                    Value = "Inside";
                    break;
                case 2:
                    Value = "Edge";
                    break;
                case 3:
                    Value = "Ball";
                    break;
                case 4:
                    Value = "Cup";
                    break;
                case 5:
                    Value = "2 Cups";
                    break;
                case 6:
                    Value = "3 Cups";
                    break;
                case 7:
                    Value = "4 Cups";
                    break;
                case 8:
                    Value = "1/2 Meter";
                    break;
                case 9:
                    Value = "3/4 Meter";
                    break;
                case 10:
                    Value = "Meter";
                    break;
            }

            return Value;
        }

        public Int16 PuttingAimingDistance(String valueParam)
        {
            Int16 Value = 0;

            switch (valueParam)
            {
                case null:
                    Value = 0;
                    break;
                case "Inside":
                    Value = 1;
                    break;
                case "Edge":
                    Value = 2;
                    break;
                case "Ball":
                    Value = 3;
                    break;
                case "Cup":
                    Value = 4;
                    break;
                case "2 Cups":
                    Value = 5;
                    break;
                case "3 Cups":
                    Value = 6;
                    break;
                case "4 Cups":
                    Value = 7;
                    break;
                case "1/2 Meter":
                    Value = 8;
                    break;
                case "3/4 Meter":
                    Value = 9;
                    break;
                case "Meter":
                    Value = 10;
                    break;
            }

            return Value;
        }
        //=========================================================================================================

        //=========================================================================================================
        /// <summary>
        /// Converts Soft, Medium, Hard and Very Hard values to string or integer depending on what is needed:
        /// 1 = Soft, 2 = Medium, 3 = Hard, 4 = Very Hard
        /// </summary>
        public string SoftMediumHardVeryConvert(Int16 valueParam)
        {
            String Value = null;

            switch (valueParam)
            {
                case 0:
                    Value = null;
                    break;
                case 1:
                    Value = "Soft";
                    break;
                case 2:
                    Value = "Medium";
                    break;
                case 3:
                    Value = "Hard";
                    break;
                case 4:
                    Value = "Very Hard";
                    break;
            }

            return Value;
        }

        public Int16 SoftMediumHardVeryConvert(String valueParam)
        {
            Int16 Value = 0;

            switch (valueParam)
            {
                case null:
                    Value = 0;
                    break;
                case "Soft":
                    Value = 1;
                    break;
                case "Medium":
                    Value = 2;
                    break;
                case "Hard":
                    Value = 3;
                    break;
                case "Very Hard":
                    Value = 4;
                    break;
            }

            return Value;
        }
        //=========================================================================================================

    }
}
