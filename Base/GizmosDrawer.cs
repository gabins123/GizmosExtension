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
public abstract class GizmosDrawer : MonoBehaviour
{
    [GizmosEnum]
    [Header("Gizmos Drawer")]
    public int gizmosLayer;
    public DrawGizmosType type;
    protected abstract void OnDraw();
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (type == DrawGizmosType.Always)
        {
            if (IsActivating(gizmosLayer))
            {
                OnDraw();
            }
        }
    }
    private void OnDrawGizmosSelected()
    {

        if (type == DrawGizmosType.SelectedOnly)
        {
            if (IsActivating(gizmosLayer))
            {
                OnDraw();
            }
        }
    }
#endif
    public bool IsActivating(int layer)
    {
        return (GizmosLayerManager.instance.activatingLayers &= layer) != 0;
    }
}
