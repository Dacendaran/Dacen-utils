using Dacen.ExtensionMethods.Vectors;
using System.Collections.Generic;
using UnityEngine;

namespace Dacen.ExtensionMethods.Bounds
{
	public static class ExtensionMethods_Bounds
	{
		/// <summary>
		/// Creates new bounds at the same position, but applies a margin to the size
		/// </summary>
		/// <param name="bounds">The original <see cref="BoundsInt"/></param>
		/// <param name="margin">The margin to apply on all sides</param>
		/// <returns></returns>
		public static BoundsInt WithMargin(this BoundsInt bounds, Vector3Int margin)
		{
			return new BoundsInt(bounds.position - margin, bounds.size + margin * 2);
		}

		/// <summary>
		/// Creates new bounds at the same position, but applies a margin to the size
		/// </summary>
		/// <param name="bounds">The original <see cref="UnityEngine.Bounds"/></param>
		/// <param name="margin">The margin to apply on all sides</param>
		/// <returns></returns>
		public static UnityEngine.Bounds WithMargin(this UnityEngine.Bounds bounds, Vector3 margin)
		{
			return new UnityEngine.Bounds(bounds.center, bounds.size + margin * 2);
		}

		/// <summary>
		/// Checks if two bounds intersect with each other
		/// </summary>
		/// <param name="bounds"></param>
		/// <param name="other">The other bounds to check intersection against</param>
		/// <returns></returns>
		public static bool Intersects(this BoundsInt bounds, BoundsInt other)
		{
			return bounds.IntersectsOnX(other) && bounds.IntersectsOnY(other) && bounds.IntersectsOnZ(other);
		}

		/// <summary>
		/// Checks if two bounds intersect with each other on the x axis
		/// </summary>
		/// <param name="bounds"></param>
		/// <param name="other">The other bounds to check intersection against</param>
		/// <returns></returns>
		public static bool IntersectsOnX(this BoundsInt bounds, BoundsInt other)
		{
			return bounds.min.x < other.max.x && other.min.x < bounds.max.x;
		}

		/// <summary>
		/// Checks if two bounds intersect with each other on the y axis
		/// </summary>
		/// <param name="bounds"></param>
		/// <param name="other">The other bounds to check intersection against</param>
		/// <returns></returns>
		public static bool IntersectsOnY(this BoundsInt bounds, BoundsInt other)
		{
			return bounds.min.y < other.max.y && other.min.y < bounds.max.y;
		}

		/// <summary>
		/// Checks if two bounds intersect with each other on the z axis
		/// </summary>
		/// <param name="bounds"></param>
		/// <param name="other">The other bounds to check intersection against</param>
		/// <returns></returns>
		public static bool IntersectsOnZ(this BoundsInt bounds, BoundsInt other)
		{
			return bounds.min.z < other.max.z && other.min.z < bounds.max.z;
		}

		/// <summary>
		/// Checks if two bounds intersect with each other
		/// </summary>
		/// <param name="bounds"></param>
		/// <param name="other">The other bounds to check intersection against</param>
		/// <returns></returns>
		public static bool Intersects(this UnityEngine.Bounds bounds, UnityEngine.Bounds other)
		{
			return
			(
				bounds.min.x < other.max.x &&
				other.min.x < bounds.max.x &&
				bounds.min.y < other.max.y &&
				other.min.y < bounds.max.y &&
				bounds.min.z < other.max.z &&
				other.min.z < bounds.max.z
			);
		}

		/// <summary>
		/// Checks if two bounds intersect with each other on the x axis
		/// </summary>
		/// <param name="bounds"></param>
		/// <param name="other">The other bounds to check intersection against</param>
		/// <returns></returns>
		public static bool IntersectsOnX(this UnityEngine.Bounds bounds, UnityEngine.Bounds other)
		{
			return bounds.min.x < other.max.x && other.min.x < bounds.max.x;
		}

		/// <summary>
		/// Checks if two bounds intersect with each other on the y axis
		/// </summary>
		/// <param name="bounds"></param>
		/// <param name="other">The other bounds to check intersection against</param>
		/// <returns></returns>
		public static bool IntersectsOnY(this UnityEngine.Bounds bounds, UnityEngine.Bounds other)
		{
			return bounds.min.y < other.max.y && other.min.y < bounds.max.y;
		}

		/// <summary>
		/// Checks if two bounds intersect with each other on the z axis
		/// </summary>
		/// <param name="bounds"></param>
		/// <param name="other">The other bounds to check intersection against</param>
		/// <returns></returns>
		public static bool IntersectsOnZ(this UnityEngine.Bounds bounds, UnityEngine.Bounds other)
		{
			return bounds.min.z < other.max.z && other.min.z < bounds.max.z;
		}

		/// <summary>
		/// Checks if the bounds contain a position
		/// </summary>
		/// <param name="bounds"></param>
		/// <param name="position"></param>
		/// <returns>Do the bounds contain the passed position?</returns>
		public static bool Contains(this BoundsInt bounds, Vector3 position)
		{
			return position.x >= bounds.xMin && position.x <= bounds.xMax &&
				   position.y >= bounds.yMin && position.y <= bounds.yMax &&
				   position.z >= bounds.zMin && position.z <= bounds.zMax;
		}

		public static List<Vector3Int> GetAllIntPositionsWithin(this UnityEngine.Bounds bounds)
		{
			List<Vector3Int> intPositionsWithin = new();

			Vector3Int min = bounds.min.CeilToInt();
			Vector3Int max = bounds.max.FloorToInt();
			for(int x = min.x; x < max.x; x++)
			{
				for(int y = min.y; y < max.y; y++)
				{
					for(int z = min.z; z < max.z; z++)
					{
						intPositionsWithin.Add(new Vector3Int(x, y, z));
					}
				}
			}

			return intPositionsWithin;
		}
	}
}
