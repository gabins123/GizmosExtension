using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrajectory : GizmosDrawer
{
    [Space(10f)]
    [Header("Gizmos Property")]
    public Vector3 velocityDir;
    public float velocityValue;
    [Range(0.001f,1)]
    public float timeStep;
    public float timeTravel;

    public Transform endPos;

    public float pointRadius;
    public bool isDetectCollider;
    protected override void OnDraw()
    {
        if (transform == null || endPos == null || timeStep == 0)
            return;
        CalculatedVelocity();
        var array = Ballistics.CalculatePosArray(transform.position, velocityDir * velocityValue, timeTravel, timeStep);
        if(isDetectCollider)
        {
            array = Ballistics.GetHitPositionIndex(array);
        }
        for (int i = 0; i < array.Count; i++)
        {
            Gizmos.DrawWireSphere(array[i], pointRadius);
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(endPos.position, pointRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + velocityDir * velocityValue);
    }

    private void CalculatedVelocity()
    {
        if (timeTravel == 0)
        {
            velocityDir = Vector3.zero;
            return;
        }

        float x = endPos.position.x / timeTravel;
        float y = (2*endPos.position.y + 9.81f* timeTravel * timeTravel) /2/ timeTravel;
        float z = endPos.position.z / timeTravel;
        velocityDir = new Vector3(x, y, z);
        velocityValue = velocityDir.magnitude;
        velocityDir.Normalize();
    }
}
