using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dacen.Utils.Strings
{
    public static class StringUtils
    {
        /// <summary>
        /// Makes the char at the specified index lower cased
        /// </summary>
        /// <param name="str">The string to make the char at the specified index lower cased</param>
        /// <param name="charIndex">The index of the char to make lower cased</param>
        /// <returns>The edited string</returns>
        public static string CharToLowerCase(string str, int charIndex)
        {
            if (string.IsNullOrEmpty(str) || str.Length <= charIndex || char.IsLower(str[charIndex]))
                return str;

            if (charIndex == 0)
                return char.ToLower(str[charIndex]) + str.Substring(1);
            else if (charIndex == str.Length - 1)
                return str.Substring(0, charIndex) + char.ToLower(str[charIndex]);
            return str.Substring(0, charIndex) + char.ToLower(str[charIndex]) + str.Substring(charIndex + 1);
        }

        /// <summary>
        /// Makes the char at the specified index upper cased
        /// </summary>
        /// <param name="str">The string to make the char at the specified index upper cased</param>
        /// <param name="charIndex">The index of the char to make upper cased</param>
        /// <returns>The edited string</returns>
        public static string CharToUpperCase(string str, int charIndex)
        {
            if (string.IsNullOrEmpty(str) || str.Length <= charIndex || char.IsUpper(str[charIndex]))
                return str;

            if (charIndex == 0)
                return char.ToUpper(str[charIndex]) + str.Substring(1);
            else if (charIndex == str.Length - 1)
                return str.Substring(0, charIndex) + char.ToUpper(str[charIndex]);
            return str.Substring(0, charIndex) + char.ToUpper(str[charIndex]) + str.Substring(charIndex + 1);
        }

        public struct RichTextQuad
        {
            public int materialIndex;
            public int height;
            public Rect rect;
            public RichTextQuad(int _materialIndex, int _height, Rect _rect)
            {
                materialIndex = _materialIndex;
                height = _height;
                rect = _rect;
            }
        }

        /// <summary>
        /// Wraps a string into the html tags TMPro supports
        /// </summary>
        /// <param name="str">The string to wrap into html tags</param>
        /// <param name="bolt">Should the bold tag be applied?/param>
        /// <param name="italic">Should the italic tag be applied?</param>
        /// <param name="size">Specify a number, if the size tag should be applied with that number</param>
        /// <param name="color">Specify a color, if the color tag should be applied with that color</param>
        /// <param name="material">Specify a material index, if the material tag should be applied with that index</param>
        /// <param name="quad">Specify a <see cref="RichTextQuad"/>, if the squad tag should be applied with that squad</param>
        /// <returns>The string wrapped in html tags</returns>
        public static string ToTMProRichText(string str, bool bolt = false, bool italic = false, int? size = null, Color? color = null, int? material = null, RichTextQuad? quad = null)
        {
            string richTextString = str;
            if (bolt)
                richTextString = $"<b>{richTextString}</b>";
            if (italic)
                richTextString = $"<i>{richTextString}</i>";
            if (size != null)
                richTextString = $"<size={size}>{richTextString}</size>";
            if (color != null)
                richTextString = $"<color=#{ColorUtility.ToHtmlStringRGBA(color.Value)}>{richTextString}</color>";
            if (material != null)
                richTextString = $"<material={material}>{richTextString}</material>";
            if (quad != null)
            {
                RichTextQuad quadValue = quad.Value;
                richTextString = $"<quad material={quadValue.materialIndex} size={quadValue.height} x={quadValue.rect.x} y={quadValue.rect.y} width={quadValue.rect.width} height={quadValue.rect.height}>{richTextString}";
            }
            return richTextString;
        }

        /// <summary>
        /// Created a string with the passed length, containing only the passed character
        /// </summary>
        /// <param name="length">The length of the string to create</param>
        /// <param name="character">The character that the created string consists of</param>
        /// <returns></returns>
        public static string Create(int length, char character)
        {
            string str = "";
            for(int i = 0; i < length; i++)
            {
                str += character;
            }
            return str;
        }
    }
}