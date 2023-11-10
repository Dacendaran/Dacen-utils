using UnityEngine;
using UnityEngine.UI;

namespace Dacen.ExtensionMethods.UI.Images
{
    public static class ExtensionMethods_Images
    {
        /// <summary>
        /// Adjusts the alpha channel
        /// </summary>
        /// <param name="image">The image to adjust the alpha channel for</param>
        /// <param name="alpha">The new alpha value</param>
        public static void AdjustAlpha(this Image image, float alpha) => image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
    }
}