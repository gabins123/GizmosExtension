using UnityEngine;

[AddComponentMenu("GizmosExtention/CubeGizmos", 1)]
public class DrawGizmosCube : GizmosDrawer
{
    public Color color = Color.green;
    public Vector3 center;
    public Vector3 size = Vector3.one;
    protected override void OnDraw()
    {
        if (mode == FrameMode.WireFrame)
        {
            transform.DrawWireFrameCube(size, center, color);
            return;
        }
        transform.DrawShadedFrameCube(size, center, color);
    }

}
