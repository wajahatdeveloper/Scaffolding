﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Includes 2D Geometry functions.
/// </summary>
public static class Geometry2D
{
    /// <summary>
    /// Finds the closest <see cref="Vector2"/> in <paramref name="allTargets"/> on XY plane.
    /// </summary>
    public static Vector2 FindClosest2D(this Vector2 origin, IList<Vector2> allTargets)
    {
        if (allTargets == null)
        {
            throw new ArgumentNullException("allTargets");
        }

        switch (allTargets.Count)
        {
            case 0: return Vector2.zero;
            case 1: return allTargets[0];
        }

        float closestDistance = Mathf.Infinity;
        var closest = Vector2.zero;

        foreach (var iteratingTarget in allTargets)
        {
            float distanceSqr = (iteratingTarget - origin).sqrMagnitude;

            if (distanceSqr < closestDistance)
            {
                closestDistance = distanceSqr;
                closest = iteratingTarget;
            }
        }

        return closest;
    }

    /// <summary>
    /// Finds the closest <see cref="Transform"/> in <paramref name="allTargets"/> on XY plane.
    /// </summary>
    public static Transform FindClosest2D(this Vector2 origin, IList<Transform> allTargets)
    {
        if (allTargets == null)
        {
            throw new ArgumentNullException("allTargets");
        }

        switch (allTargets.Count)
        {
            case 0: return null;
            case 1: return allTargets[0];
        }

        float closestDistance = Mathf.Infinity;
        Transform closest = null;

        foreach (var iteratingTarget in allTargets)
        {
            float distanceSqr = (iteratingTarget.Position2D() - origin).sqrMagnitude;

            if (distanceSqr < closestDistance)
            {
                closestDistance = distanceSqr;
                closest = iteratingTarget;
            }
        }

        return closest;
    }

    /// <summary>
    /// Finds the closest <see cref="GameObject"/> in <paramref name="allTargets"/> on XY plane.
    /// </summary>
    public static GameObject FindClosest2D(this Vector2 origin, IList<GameObject> allTargets)
    {
        if (allTargets == null)
        {
            throw new ArgumentNullException("allTargets");
        }

        switch (allTargets.Count)
        {
            case 0: return null;
            case 1: return allTargets[0];
        }

        float closestDistance = Mathf.Infinity;
        GameObject closest = null;

        foreach (var iteratingTarget in allTargets)
        {
            float distanceSqr = (iteratingTarget.transform.Position2D() - origin).sqrMagnitude;

            if (distanceSqr < closestDistance)
            {
                closestDistance = distanceSqr;
                closest = iteratingTarget;
            }
        }

        return closest;
    }

    /// <summary>
    /// <para>Returns the 2D center of all the points given.</para>
    /// <para>If <paramref name="weighted"/> is true, center point will be closer to the area that points are denser; if false, center will be the geometric exact center of bounding box of points.</para>
    /// </summary>
    public static Vector2 FindCenter2D(this IList<Vector2> points, bool weighted)
    {
        switch (points.Count)
        {
            case 0: return Vector2.zero;
            case 1: return points[0];
        }

        if (weighted)
        {
            return points.Aggregate(Vector2.zero, (current, point) => current + point) / points.Count;
        }

        var bound = new Bounds { center = points[0] };
        foreach (var point in points)
        {
            bound.Encapsulate(point);
        }

        return bound.center;
    }

    /// <summary>
    /// <para>Returns the 2D center of all the points given.</para>
    /// <para>If <paramref name="weighted"/> is true, center point will be closer to the area that points are denser; if false, center will be the geometric exact center of bounding box of points.</para>
    /// </summary>
    public static Vector2 FindCenter2D(this IList<GameObject> gameObjects, bool weighted)
    {
        return gameObjects.FindCenter(weighted);
    }

    /// <summary>
    /// <para>Returns the 2D center of all the points given.</para>
    /// <para>If <paramref name="weighted"/> is true, center point will be closer to the area that points are denser; if false, center will be the geometric exact center of bounding box of points.</para>
    /// </summary>
    public static Vector2 FindCenter2D(this IList<Transform> transforms, bool weighted)
    {
        return transforms.FindCenter(weighted);
    }

    /// <summary>
    /// Converts polar coordinates to cartesian coordinates.
    /// </summary>
    /// <param name="radius">Magnitude of position vector.</param>
    /// <param name="angle">Positive rotation of position vector from +x (in radians).</param>
    /// <returns> Cartesian equivelant of given polar coordinates. </returns>
    public static Vector2 PolarToCartesian(float radius, float angle)
    {
        var x = radius * Mathf.Cos(angle);
        var y = radius * Mathf.Sin(angle);

        return new Vector2(x, y);
    }

    /// <summary>
    /// Converts cartesian coordinates to polar coordinates.
    /// </summary>
    /// <param name="cartesian">Carteisan coordinates.</param>
    /// <param name="radius">Magnitude of position vector.</param>
    /// <param name="angle">Positive rotation of position vector from +x.</param>
    public static void CartesianToPolar(this Vector2 cartesian, out float radius, out float angle)
    {
        radius = cartesian.magnitude;
        angle = Mathf.Atan2(cartesian.y, cartesian.x);
    }

    /// <summary>
    /// Returns the positive angle of <paramref name="vector2"/> in radians. This method takes +X axis as 0 degrees.
    /// </summary>
    public static float Rotation(this Vector2 vector2)
    {
        return Mathf.Atan2(vector2.y, vector2.x);
    }

    /// <summary>
    /// Rotates the Vector2 by given angle (in radians).
    /// </summary>
    public static Vector2 Rotate(this Vector2 v, float degrees)
    {
        float sin = Mathf.Sin(degrees);
        float cos = Mathf.Cos(degrees);

        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }

    /// <summary>
    /// Determines if AABBs represented with given parameters are overlapping.
    /// </summary>
    public static bool IsOverlapping(Vector2 aMin, Vector2 aMax, Vector2 bMin, Vector2 bMax)
    {
        return !(bMin.x > aMax.x || aMin.x > bMax.x || aMin.y > bMax.y || bMin.y > aMax.y);
    }

    /// <summary>
    /// <para> Determines if given point is inside given polygon. Polygon can be concave or convex. </para>
    /// </summary>
    /// <remarks>
    /// This method uses an algorithm that casts an imaginary ray counting amount of sides it intersects until it reaches the point.
    /// If the count is even, point is outside; if count is odd, point is inside.
    /// </remarks>
    public static bool IsInPoly(this Vector2 point, IList<Vector2> verticesOfPolygon)
    {
        //
        // Original raycast algorithm: http://www.ecse.rpi.edu/Homepages/wrf/Research/Short_Notes/pnpoly.html
        // C# conversion:              http://stackoverflow.com/a/16391873/5504706
        // Reformatted by:             S. Tarık Çetin - cetinsamedtarik[at]gmail[dot]com
        //

        //Get shared variables.
        var vertexCount = verticesOfPolygon.Count;
        var px = point.x;
        var py = point.y;

        //Vertex count can't be less than 3.
        if (vertexCount < 3) return false;

        bool inside = false;
        for (int i = 0, j = vertexCount - 1; i < vertexCount; j = i++)
        {
            //Get points.
            var ix = verticesOfPolygon[i].x;
            var iy = verticesOfPolygon[i].y;
            var jx = verticesOfPolygon[j].x;
            var jy = verticesOfPolygon[j].y;

            //Cast the ray.
            if ((iy > py) != (jy > py) && px < (jx - ix) * (py - iy) / (jy - iy) + ix)
            {
                inside = !inside;
            }
        }

        return inside;
    }
}