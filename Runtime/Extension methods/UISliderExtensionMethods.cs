using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Dacen.ExtensionMethods.UI.Sliders
{
    public static class ExtensionMethods_Sliders
    {
        /// <summary>
        /// Makes the <see cref="Slider.value"/> reach its target over time (await-able)
        /// </summary>
        /// <param name="slider">The slider to tween the value for</param>
        /// <param name="to">The target value</param>
        /// <param name="timeInMilliseconds">The time it takes for the <see cref="Slider"/> to reach its new value</param>
        /// <returns>The task (not frame-perfect, since <see cref="Task.Yield"/> is used)</returns>
        public static async Task TweenValueTask(this Slider slider, float to, int timeInMilliseconds)
        {
            int direction = to < slider.value ? -1 : 1;
            to = Mathf.Clamp(to, slider.minValue, slider.maxValue);
            float valueToAddPerMillisecond = (to - slider.value) / timeInMilliseconds;
            while ((direction == -1 && slider.value > to) || (direction == 1 && slider.value < to))
            {
                slider.value += valueToAddPerMillisecond * Time.deltaTime * 1000;
                await Task.Yield();
            }
            slider.value = to;
        }

        /// <summary>
        /// Makes the <see cref="Slider.value"/> reach its target over time (not await-able)
        /// </summary>
        /// <param name="slider">The slider to tween the value for</param>
        /// <param name="to">The target value</param>
        /// <param name="timeInMilliseconds">The time it takes for the <see cref="Slider"/> to reach its new value</param>
        public static async void TweenValue(this Slider slider, float to, int timeInMilliseconds)
        {
            int direction = to < slider.value ? -1 : 1;
            to = Mathf.Clamp(to, slider.minValue, slider.maxValue);
            float valueToAddPerMillisecond = (to - slider.value) / timeInMilliseconds;
            while ((direction == -1 && slider.value > to) || (direction == 1 && slider.value < to))
            {
                slider.value += valueToAddPerMillisecond * Time.deltaTime * 1000;
                await Task.Yield();
            }
            slider.value = to;
        }
    }
}