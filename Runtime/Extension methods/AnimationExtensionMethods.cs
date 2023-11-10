using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Dacen.ExtensionMethods.Animations
{
    public static class ExtensionMethods_Animations
    {
        public static async Task PlayAnimationTask(this Animation animation, string animationName)
        {
            animation.Play(animationName);
            while (animation.IsPlaying(animationName))
                await Task.Yield();
        }

        public static async void PlayAnimation(this Animation animation, string animationName, Action onAnimationEnd)
        {
            animation.Play(animationName);
            while (animation.IsPlaying(animationName))
                await Task.Yield();
            onAnimationEnd.Invoke();
        }
    }
}