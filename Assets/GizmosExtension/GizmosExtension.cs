using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DrawGizmosType
{
    Always,
    SelectedOnly
}

public static class GizmosExtension
{
    //ex:  transform.DrawWirelessCube(width,height,depth,color);
    public static void DrawWireFrameCube(this Transform trans, float width, float height, float depth, Color color = default)
    {
        DrawWireFrameCube(trans.position, trans.rotation, width, height, depth, color);
    }
    //ex: GizmosExtension.DrawWirelessCube(transform.position,transform.rotation, width, height, depth, color);
    public static void DrawWireFrameCube(Vector3 position, Quaternion rotation,float width, float height, float depth, Color color = default)
    {
        Matrix4x4 cubeTransform = Matrix4x4.TRS(position, rotation, new Vector3(width,height,depth));
        Matrix4x4 oldGizmosMatrix = Gizmos.matrix;

        Gizmos.matrix *= cubeTransform;
        Gizmos.color = color;
        Vector3 topLeftFrontCorner = new Vector3(-0.5f, 0.5f, 0.5f);
        Vector3 topRightFrontCorner = new Vector3(0.5f, 0.5f, 0.5f);
        Vector3 bottomLeftFrontCorner = new Vector3(-0.5f, -0.5f, +0.5f);
        Vector3 bottomRightFrontCorner = new Vector3(+0.5f, -0.5f, +0.5f);
        Vector3 topLeftBehindCorner = new Vector3(-0.5f, 0.5f, -0.5f);
        Vector3 topRightBehindCorner = new Vector3(0.5f, 0.5f, -0.5f);
        Vector3 bottomLeftBehindCorner = new Vector3(-0.5f, -0.5f, -0.5f);
        Vector3 bottomRightBehindCorner = new Vector3(0.5f, -0.5f, -0.5f);

        Gizmos.DrawLine(topLeftFrontCorner, topRightFrontCorner);
        Gizmos.DrawLine(topRightFrontCorner, bottomRightFrontCorner);
        Gizmos.DrawLine(bottomRightFrontCorner, bottomLeftFrontCorner);
        Gizmos.DrawLine(bottomLeftFrontCorner, topLeftFrontCorner);

        Gizmos.DrawLine(topLeftBehindCorner, topRightBehindCorner);
        Gizmos.DrawLine(topRightBehindCorner, bottomRightBehindCorner);
        Gizmos.DrawLine(bottomRightBehindCorner, bottomLeftBehindCorner);
        Gizmos.DrawLine(bottomLeftBehindCorner, topLeftBehindCorner);

        Gizmos.DrawLine(topLeftFrontCorner, topLeftBehindCorner);
        Gizmos.DrawLine(topRightFrontCorner, topRightBehindCorner);
        Gizmos.DrawLine(bottomRightFrontCorner, bottomRightBehindCorner);
        Gizmos.DrawLine(bottomLeftFrontCorner, bottomLeftBehindCorner);

        Gizmos.matrix = oldGizmosMatrix;
    }
    public static void DrawShadedFrameCube(this Transform trans, float width, float height, float depth, Color color = default)
    {
        DrawShadedFrameCube(trans.position, trans.rotation, width, height, depth, color);
    }
    public static void DrawShadedFrameCube(Vector3 position, Quaternion rotation, float width, float height, float depth, Color color = default)
    {
        Matrix4x4 cubeTransform = Matrix4x4.TRS(position, rotation, new Vector3(width, height, depth));
        Matrix4x4 oldGizmosMatrix = Gizmos.matrix;

        Gizmos.matrix *= cubeTransform;
        Gizmos.color = color;
        Gizmos.DrawCube(Vector3.zero, Vector3.one);
        Gizmos.matrix = oldGizmosMatrix;
    }
}
