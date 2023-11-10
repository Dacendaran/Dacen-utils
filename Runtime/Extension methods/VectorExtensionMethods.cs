using System.Collections.Generic;
using UnityEngine;

namespace Dacen.ExtensionMethods.Vectors
{
	public enum VectorAxis { X, Y, Z }

	public static class VectorExtensionMethods
	{
		/// <summary>
		/// Checks if this vector is approximately equal to another one
		/// </summary>
		/// <param name="vector"></param>
		/// <param name="otherVector"></param>
		/// <param name="tolerance">Until which squared distance are the two vectors considered equal?</param>
		/// <returns>Are the two vectors approximately equal?</returns>
		public static bool Approximately(this Vector3 vector, Vector3 otherVector, float squaredDistanceTolerance = 0.1f)
		{
			return (vector - otherVector).sqrMagnitude < squaredDistanceTolerance;
		}

		/// <summary>
		/// Get the neighbours of this vector
		/// </summary>
		/// <param name="vector">The vector to get neighbours for</param>
		/// <param name="offset">The offset of the neighbours from the original vector</param>
		/// <param name="includeDiagonals">Should the diagonal neighbours be included?</param>
		/// <returns>The neighbouring vectors</returns>
		public static List<Vector3> GetNeighbours(this Vector3 vector, float offset = 1, bool includeDiagonals = false)
		{
			if (!includeDiagonals)
			{
				return new List<Vector3>()
				{
					new Vector3(vector.x + offset, vector.y,          vector.z),		  // Right
					new Vector3(vector.x - offset, vector.y,          vector.z),		  // Left
					new Vector3(vector.x,          vector.y + offset, vector.z),		  // Top
					new Vector3(vector.x,          vector.y - offset, vector.z),		  // Bottom
					new Vector3(vector.x,          vector.y,          vector.z + offset), // Front
					new Vector3(vector.x,          vector.y,          vector.z - offset), // Back
				};
			}

			return new List<Vector3>()
			{
				new Vector3(vector.x,          vector.y + offset, vector.z),		  // Top
				new Vector3(vector.x,          vector.y - offset, vector.z),		  // Bottom
				new Vector3(vector.x + offset, vector.y,          vector.z),		  // Right
				new Vector3(vector.x - offset, vector.y,          vector.z),		  // Left				
				new Vector3(vector.x,          vector.y,          vector.z + offset), // Front
				new Vector3(vector.x,          vector.y,          vector.z - offset), // Back

				new Vector3(vector.x + offset, vector.y + offset, vector.z + offset), // Top right front
				new Vector3(vector.x - offset, vector.y + offset, vector.z + offset), // Top left fron
				new Vector3(vector.x + offset, vector.y + offset, vector.z - offset), // Top right back
				new Vector3(vector.x - offset, vector.y + offset, vector.z - offset), // Top left back

				new Vector3(vector.x + offset, vector.y - offset, vector.z + offset), // Bottom right front
				new Vector3(vector.x - offset, vector.y - offset, vector.z + offset), // Bottom left fron
				new Vector3(vector.x + offset, vector.y - offset, vector.z - offset), // Bottom right back
				new Vector3(vector.x - offset, vector.y - offset, vector.z - offset), // Bottom left back
			};
		}

		/// <summary>
		/// Get the absolute vector (no negative coordinates)
		/// </summary>
		/// <param name="vector">The vector to get the absolute one from</param>
		/// <returns>The absolute vector (no negative coordinates)</returns>
		public static Vector3 ToAbsolute(this Vector3 vector)
		{
			return new Vector3(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));
		}

		/// <summary>
		/// Get the absolute vector (no negative coordinates)
		/// </summary>
		/// <param name="vector">The vector to get the absolute one from</param>
		/// <returns>The absolute vector (no negative coordinates)</returns>
		public static Vector2 ToAbsolute(this Vector2 vector)
		{
			return new Vector2(Mathf.Abs(vector.x), Mathf.Abs(vector.y));
		}

		/// <summary>
		/// Gets the axis where the vector is the longest (can be more than one axis, if coordinates are equal)
		/// </summary>
		/// <param name="vector">The vector to get the main axis for</param>
		/// <returns>The axis where the vector is the longest</returns>
		public static List<VectorAxis> GetMainAxis(this Vector3 vector)
		{
			vector = vector.ToAbsolute();
			List<VectorAxis> mainAxis = new();

			if(vector.x >= vector.y && vector.x >= vector.z)
			{
				mainAxis.Add(VectorAxis.X);
			}
			if (vector.y >= vector.x && vector.y >= vector.z)
			{
				mainAxis.Add(VectorAxis.Y);
			}
			if (vector.z >= vector.x && vector.z >= vector.y)
			{
				mainAxis.Add(VectorAxis.Z);
			}

			return mainAxis;
		}

		public static Vector3Int CeilToInt(this Vector3 vector)
		{
			return new Vector3Int(Mathf.CeilToInt(vector.x), Mathf.CeilToInt(vector.y), Mathf.CeilToInt(vector.z));
		}

		public static Vector3Int FloorToInt(this Vector3 vector)
		{
			return new Vector3Int(Mathf.FloorToInt(vector.x), Mathf.FloorToInt(vector.y), Mathf.FloorToInt(vector.z));
		}
	}
}
