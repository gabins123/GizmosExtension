using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmosMesh : GizmosDrawer
{
    public Mesh mesh;
    public Vector3 center;
    protected override void OnDraw()
    {
        transform.DrawMesh(mesh, center);
    }
}
