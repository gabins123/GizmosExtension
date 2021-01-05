using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmosRange : GizmosDrawer
{
    public float radius;
    public string rangeName;
    protected override void OnDraw()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
        CustomGizmos.DrawString(rangeName, transform.position, Color.red);
    }

}
