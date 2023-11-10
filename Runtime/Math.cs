using System;

namespace Dacen.Math
{
    public static class DacenMath
    {
        /// <summary>
        /// Maps a value from within one range to another.
        /// For example: Mapping 2 from range 1 - 3 to range 10 - 15 => 13
        /// </summary>
        /// <param name="value">The value to map</param>
        /// <param name="from_min">The min value of the range the value is currently in</param>
        /// <param name="from_max">The max value of the range the value is currently in</param>
        /// <param name="to_min">The min value of the range the value should be mapped to</param>
        /// <param name="to_max">The max value of the range the value should be mapped to</param>
        /// <returns>The mapped value</returns>
        public static float Map(float value, float from_min, float from_max, float to_min, float to_max)
        {            
            if (value <= from_min)
                return to_min;
            else if (value >= from_max)
                return to_max;           
            return (to_max - to_min) * ((value - from_min) / (from_max - from_min)) + to_min;
        }

        public static float CalculatePercentage(float value, float percentage) => value / (100 / percentage);

        public static float FloorToMultipleOf(float valueToFloor, float divider) => valueToFloor - (valueToFloor % divider);

        public static float CeilToMultipleOf(float valueToCeil, float divider)
        {
            if (valueToCeil % divider == 0)
                return valueToCeil;
            return FloorToMultipleOf(valueToCeil, divider) + divider;
        }

        public static float RoundToMultipleOf(float valueToRound, float divider)
        {
            if (valueToRound % divider == 0)
                return valueToRound;
            float downModulo = valueToRound % divider;
            if (downModulo > divider / 2)
                return FloorToMultipleOf(valueToRound, divider);
            return CeilToMultipleOf(valueToRound, divider);
        }

        public static bool FlipCoin(int chanceForTrue = 50)
        {
            return UnityEngine.Random.Range(0, 100) < chanceForTrue;
        }
    }
}
