using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;
    public float SmoothTime = 0.3f;


    private bool isLocal = true;
    public void ChangeType(bool type)
    {
        isLocal = type;

        if (isLocal)
        {
            Offset = transform.localPosition - Target.localPosition;
        }
        else
        {
            Offset = transform.position - Target.position;
        }
       
    }
 
    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
       ChangeType(isLocal);
        


    }

    private void FixedUpdate()
    {
        // update position
        if (Target != null)
        {
            if (isLocal)
            {
                Vector3 targetPosition = Target.localPosition + Offset;
                transform.localPosition = Vector3.SmoothDamp(transform.localPosition, targetPosition, ref velocity, SmoothTime);

            }
            else
            {
                Vector3 targetPosition = Target.position + Offset;
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);
            }


        }
    }
}
