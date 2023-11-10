namespace Dacen.ExtensionMethods.Transforms
{
    using Dacen.ExtensionMethods.Arrays;
    using UnityEngine;

    public static class ExtensionMethods_Transform
    {
        /// <summary>
        /// Destroys all children of this <see cref="Transform"/>
        /// </summary>
        /// <param name="transform">The transform to destroy all children of</param>
        public static void DestroyAllChildren(this Transform transform)
        {
            foreach (Transform child in transform)
                Object.Destroy(child.gameObject);
        }

        /// <summary>
        /// Gets a random child
        /// </summary>
        /// <param name="transform">The <see cref="Transform"/> to get a random child of</param>
        /// <returns>A random child</returns>
        public static Transform GetRandomChild(this Transform transform) => transform.GetChild(Random.Range(0, transform.childCount));

        /// <summary>
        /// Gets multiple random children
        /// </summary>
        /// <param name="transform">The <see cref="Transform"/> to get random children of</param>
        /// <param name="amount">The amount of random children to get</param>
        /// <returns>Random children</returns>
        public static Transform[] GetRandomChildren(this Transform transform, int amount)
        {
            int[] indexes = new int[transform.childCount];
            indexes.Fill();
            indexes.Shuffle();
            Transform[] randomChildren = new Transform[amount];
            for (int i = 0; i < amount; i++)
                randomChildren[i] = transform.GetChild(indexes[i]);
            return randomChildren;
        }

        /// <summary>
        /// Complicated math stuff, probably something with world space, screen space and shit
        /// </summary>
        /// <param name="rectTransform"></param>
        /// <param name="canvasRectTransform"></param>
        /// <returns></returns>
        public static Rect RectTransformToScreenSpace(this RectTransform rectTransform, RectTransform canvasRectTransform)
        {
            Vector2 size = Vector2.Scale(rectTransform.rect.size, rectTransform.lossyScale) / canvasRectTransform.localScale.x;
            return new Rect((Vector2)rectTransform.position / canvasRectTransform.localScale.x - (size * rectTransform.pivot), size);
        }
    }
}