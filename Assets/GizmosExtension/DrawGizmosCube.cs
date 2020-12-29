using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public enum FrameMode
{
    ShadedFrame,
    WireFrame
}
[AddComponentMenu("GizmosExtention/CubeGizmos", 1)]
public class DrawGizmosCube : MonoBehaviour
{
#if UNITY_EDITOR
    public DrawGizmosType type;
    public FrameMode mode;
    public Color color = Color.green;
    public Vector3 center;
    public Vector3 size = Vector3.one;

    private void OnDrawGizmos()
    {
        if (type == DrawGizmosType.Always)
        {
            if(mode == FrameMode.WireFrame)
            {
                transform.DrawWireFrameCube(size,center, color);
                return;
            }
            transform.DrawShadedFrameCube(size, center, color);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if(type == DrawGizmosType.SelectedOnly)
        {
            if (mode == FrameMode.WireFrame)
            {
                transform.DrawWireFrameCube(size, center, color);
                return;
            }
            transform.DrawShadedFrameCube(size, center, color);
        }

    }
#endif
}
