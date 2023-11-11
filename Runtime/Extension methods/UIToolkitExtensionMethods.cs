using UnityEngine.UIElements;

namespace Dacen.ExtensionMethods.UI.Toolkit
{
    public static class ExtensionMethods_UIToolkit
    {
        public static T WithName<T>(this T visualElement, string name) where T : VisualElement
        {
            visualElement.name = name;
            return visualElement;
        }

        public static T WithClass<T>(this T visualElement, string className) where T : VisualElement
        {
            visualElement.AddToClassList(className);
            return visualElement;
        }

        public static T WithClasses<T>(this T visualElement, params string[] classNames) where T : VisualElement
        {
            foreach(string className in classNames)
            {
                visualElement.AddToClassList(className);
    }
            return visualElement;
        }

        public static T WithParent<T>(this T visualElement, VisualElement parent) where T : VisualElement
        {
            parent.Add(visualElement);
            return visualElement;
        }

		public static T WithChild<T>(this T visualElement, VisualElement child) where T : VisualElement
        {
            visualElement.Add(child);
            return visualElement;
        }


		public static T WithChildren<T>(this T visualElement, params VisualElement[] children) where T : VisualElement
        {
            foreach(var child in children)
            {
                visualElement.Add(child);
            }
            return visualElement;
        }
    }
}
