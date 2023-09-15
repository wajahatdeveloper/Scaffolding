using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public static class StringExtensions
{
	public const string WholeNumber = @"^-?\d+$";
	public const string FloatingNumber = @"^-?\d*(\.\d+)?$";

	public const string AlphanumericWithoutSpace = @"^[a-zA-Z0-9]*$";
	public const string AlphanumericWithSpace = @"^[a-zA-Z0-9 ]*$";

	public const string Email = @"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})*$";
	public const string URL = @"(https?:\/\/)?(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)";

	/// <summary>
	/// Replace all but matching parts of the input string
	/// </summary>
	public static string KeepMatching(this Regex regex, string input) => regex.Matches(input).Cast<Match>()
		.Aggregate(string.Empty, (a, m) => a + m.Value);	

	/// <summary>
    		/// "Camel case string" => "CamelCaseString" 
    		/// </summary>
    		public static string ToCamelCase(this string message) {
    			message = message.Replace("-", " ").Replace("_", " ");
    			message = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(message);
    			message = message.Replace(" ", "");
    			return message;
    		}
    
    		/// <summary>
    		/// "CamelCaseString" => "Camel Case String"
    		/// </summary>
    		public static string SplitCamelCase(this string camelCaseString)
    		{
    			if (string.IsNullOrEmpty(camelCaseString)) return camelCaseString;
    
    			string camelCase = Regex.Replace(Regex.Replace(camelCaseString, @"(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2"), @"(\p{Ll})(\P{Ll})", "$1 $2");
    			string firstLetter = camelCase.Substring(0, 1).ToUpper();
    
    			if (camelCaseString.Length > 1)
    			{
    				string rest = camelCase.Substring(1);
    
    				return firstLetter + rest;
    			}
    
    			return firstLetter;
    		}
    
    		/// <summary>
    		/// Convert a string value to an Enum value.
    		/// </summary>
    		public static T AsEnum<T>(this string source, bool ignoreCase = true) where T : Enum => (T) Enum.Parse(typeof(T), source, ignoreCase);

            /// <summary>
            /// Converts a hex code into corresponding color. Supports RGB and RGBA
            /// </summary>
            /// <param name="hex">Color hex code, without prefixes.</param>
            /// <returns></returns>
            public static Color ParseColor(this string hex) {
	            int length = hex.Length;
	            if(!(length == 6 || length == 8))
		            throw new ArgumentException($"Color Hex code {hex} is not a valid hex code.");

	            var color = new Color32();
	            if(
		            byte.TryParse(hex.Substring(0, 2), NumberStyles.AllowHexSpecifier, NumberFormatInfo.InvariantInfo, out byte r) &&
		            byte.TryParse(hex.Substring(2, 2), NumberStyles.AllowHexSpecifier, NumberFormatInfo.InvariantInfo, out byte g) &&
		            byte.TryParse(hex.Substring(4, 2), NumberStyles.AllowHexSpecifier, NumberFormatInfo.InvariantInfo, out byte b))
	            {
		            color.r = r;
		            color.b = b;
		            color.g = g;
	            } else
		            throw new ArgumentException($"Color Hex code {hex} is not a valid hex code.");

	            if(length == 8)
		            if(byte.TryParse(hex.Substring(6, 2), NumberStyles.AllowHexSpecifier, NumberFormatInfo.InvariantInfo, out byte a))
			            color.a = a;
		            else
			            throw new ArgumentException($"Color Hex code {hex} is not a valid hex code.");
	            else
		            color.a = 0xFF;

	            return color;
            }
    
    		/// <summary>
    		/// Number presented in Roman numerals
    		/// </summary>
    		public static string ToRoman(this int i)
    		{
    			if (i > 999) return "M" + ToRoman(i - 1000);
    			if (i > 899) return "CM" + ToRoman(i - 900);
    			if (i > 499) return "D" + ToRoman(i - 500);
    			if (i > 399) return "CD" + ToRoman(i - 400);
    			if (i > 99) return "C" + ToRoman(i - 100);
    			if (i > 89) return "XC" + ToRoman(i - 90);
    			if (i > 49) return "L" + ToRoman(i - 50);
    			if (i > 39) return "XL" + ToRoman(i - 40);
    			if (i > 9) return "X" + ToRoman(i - 10);
    			if (i > 8) return "IX" + ToRoman(i - 9);
    			if (i > 4) return "V" + ToRoman(i - 5);
    			if (i > 3) return "IV" + ToRoman(i - 4);
    			if (i > 0) return "I" + ToRoman(i - 1);
    			return "";
    		}
            
            /// <summary>
            /// Get the "message" string with the "surround" string at the both sides 
            /// </summary>
            public static string SurroundedWith(this string message, string surround) => surround + message + surround;
		
            /// <summary>
            /// Get the "message" string with the "start" at the beginning and "end" at the end of the string
            /// </summary>
            public static string SurroundedWith(this string message, string start, string end) => start + message + end;

            /// <summary>
            /// Surround string with "color" tag
            /// </summary>
            public static string Colored(this string message, UnityConsoleColors color) => $"<color={color}>{message}</color>";

            /// <summary>
            /// Surround string with "color" tag
            /// </summary>
            public static string Colored(this string message, Color color) => $"<color={color.ColorToHex()}>{message}</color>";

            /// <summary>
            /// Surround string with "color" tag
            /// </summary>
            public static string Colored(this string message, string colorCode) => $"<color={colorCode}>{message}</color>";

            /// <summary>
            /// Surround string with "size" tag
            /// </summary>
            public static string Sized(this string message, int size) => $"<size={size}>{message}</size>";
		
            /// <summary>
            /// Surround string with "u" tag
            /// </summary>
            public static string Underlined(this string message) => $"<u>{message}</u>";

            /// <summary>
            /// Surround string with "b" tag
            /// </summary>
            public static string Bold(this string message) => $"<b>{message}</b>";

            /// <summary>
            /// Surround string with "i" tag
            /// </summary>
            public static string Italics(this string message) => $"<i>{message}</i>";
            
            /// <summary>
            /// Represents list of supported by Unity Console color names
            /// </summary>
            public enum UnityConsoleColors
            {
	            // ReSharper disable InconsistentNaming
	            aqua,
	            black,
	            blue,
	            brown,
	            cyan,
	            darkblue,
	            fuchsia,
	            green,
	            grey,
	            lightblue,
	            lime,
	            magenta,
	            maroon,
	            navy,
	            olive,
	            purple,
	            red,
	            silver,
	            teal,
	            white,

	            yellow
	            // ReSharper restore InconsistentNaming
            }
}
