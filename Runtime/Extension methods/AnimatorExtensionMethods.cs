using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Dacen.ExtensionMethods.Animators
{
    public static class ExtensionMethods_Animators
    {
        public static async Task PlayStateTask(this Animator animator, string stateName, int layer = 0)
        {
            animator.Play(stateName, layer);
            while (!animator.GetCurrentAnimatorStateInfo(layer).IsName(stateName))
                await Task.Yield();
            while (animator.GetCurrentAnimatorStateInfo(layer).IsName(stateName))
                await Task.Yield();
        }

        public static async void PlayState(this Animator animator, string stateName, Action onStateEnd, int layer = 0)
        {
            animator.Play(stateName, layer);
            while (!animator.GetCurrentAnimatorStateInfo(layer).IsName(stateName))
                await Task.Yield();
            while (animator.GetCurrentAnimatorStateInfo(layer).IsName(stateName))
                await Task.Yield();
            onStateEnd.Invoke();
        }
    }
}