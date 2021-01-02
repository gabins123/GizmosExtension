using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Ballistics
{
    /// <summary>
    /// Checks the ballistic path for collisions.
    /// </summary>
    /// <returns><c>false</c>, if ballistic path was blocked by an object on the Layermask, <c>true</c> otherwise.</returns>
    /// <param name="arc">Arc.</param>
    /// <param name="lm">Anything in this layer will block the path.</param>
    public static bool CheckBallisticPath(Vector3[] arc, LayerMask lm)
    {

        RaycastHit hit;
        for (int i = 1; i < arc.Length; i++)
        {

            if (Physics.Raycast(arc[i - 1], arc[i] - arc[i - 1], out hit, (arc[i] - arc[i - 1]).magnitude, lm))
                return false;
        }
        return true;
    }

    public static Vector3 GetHitPosition(Vector3 startPos, Vector3 velocity, float timeTravel, float timeStep)
    {

        List<Vector3> path = CalculatePosArray(startPos, velocity, timeTravel, timeStep);
        RaycastHit hit;
        for (int i = 1; i < path.Count; i++)
        {

            //Debug.DrawRay (path [i - 1], path [i] - path [i - 1], Color.red, 10f);
            if (Physics.Raycast(path[i - 1], path[i] - path[i - 1], out hit, (path[i] - path[i - 1]).magnitude))
            {
                return hit.point;
            }
        }
        return Vector3.zero;
    }
    public static List<Vector3> GetHitPositionIndex(List<Vector3> path)
    {
        RaycastHit hit;
        for (int i = 1; i < path.Count; i++)
        {

            //Debug.DrawRay (path [i - 1], path [i] - path [i - 1], Color.red, 10f);
            if (Physics.Raycast(path[i - 1], path[i] - path[i - 1], out hit, (path[i] - path[i - 1]).magnitude))
            {
                var newPath = path.GetRange(0, i);
                newPath.Add(hit.point);
                return newPath;
            }
        }
        return path;
    }


    public static float CalculateMaxRange(float muzzleVelocity)
    {
        return (muzzleVelocity * muzzleVelocity) / -Physics.gravity.y;
    }

    public static float GetTimeOfFlight(float vel, float angle, float height)
    {

        return (2.0f * vel * Mathf.Sin(angle)) / -Physics.gravity.y;
    }
    public static List<Vector3> CalculatePosArray(Vector3 startPos, Vector3 velocity, float timeTravel,float timeStep)
    {
        int resolution = Mathf.FloorToInt(timeTravel / timeStep);
        List<Vector3> posArray = new List<Vector3>();
        for (int i = 0; i <= resolution; i++)
        {
            posArray.Add(CalculatePos(startPos, velocity, timeStep * i));
        }
        return posArray;
    }
    private static Vector3 CalculatePos(Vector3 startPos, Vector3 velocity, float t)
    {
        float x = velocity.x * t;
        float y = velocity.y * t - 9.81f * t * t / 2;
        float z = velocity.z * t;
        return new Vector3(x, y, z) + startPos;
    }
}