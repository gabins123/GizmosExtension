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
public class GizmosDrawer : MonoBehaviour
{
#if UNITY_EDITOR
    [GizmosEnum]
    public int gizmosLayer;
    public DrawGizmosType type;
    public FrameMode mode;
    protected virtual void OnDraw()
    {

    }
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
        return (new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("Assets/GizmosExtension/GizmosManager.asset")[0]).FindProperty("activatingLayers").intValue &= layer) != 0;
    }
}
