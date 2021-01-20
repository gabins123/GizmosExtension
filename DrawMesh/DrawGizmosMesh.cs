using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmosMesh : GizmosDrawer
{
    public Mesh mesh;
    public Vector3 center;
    public Color meshColor = Color.white;
    protected override void OnDraw()
    {
        Gizmos.color = meshColor;
        transform.DrawMesh(mesh, center);
    }
}
