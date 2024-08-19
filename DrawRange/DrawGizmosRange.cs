using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmosRange : GizmosDrawer
{
    public float radius;
    public string rangeName;
    public Color borderColor = Color.yellow;
    public Color textColor = Color.red;
    public Color backgroundTextColor = Color.black;

    protected override void OnDraw()
    {
        Gizmos.color = borderColor;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
