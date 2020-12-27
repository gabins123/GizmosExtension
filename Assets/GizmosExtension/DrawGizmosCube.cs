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

public class DrawGizmosCube : MonoBehaviour
{
#if UNITY_EDITOR
    public DrawGizmosType type;
    public FrameMode mode;
    public Color color;
    [Min(0)]
    public float height;
    [Min(0)]
    public float width;
    [Min(0)]
    public float depth;

    private void OnDrawGizmos()
    {
        if (type == DrawGizmosType.Always)
        {
            if(mode == FrameMode.WireFrame)
            {
                transform.DrawWireFrameCube(width,height,depth,color);
                return;
            }
            transform.DrawShadedFrameCube(width, height, depth, color);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if(type == DrawGizmosType.SelectedOnly)
        {
            if (mode == FrameMode.WireFrame)
            {
                transform.DrawWireFrameCube(width, height, depth, color);
                return;
            }
            transform.DrawShadedFrameCube(width, height, depth, color);
        }

    }
#endif
}
