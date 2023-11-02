using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProspectiveCameraController : CameraController
{
    protected override void Move()
    {
        //transform.position = Vector3.Lerp(transform.position, centerPoint + OffSet, SmoothTime);
        transform.position = Vector3.SmoothDamp(transform.position, MoveToPos(), ref velocity, SmoothTime, MaxMoveSpeed); ;
    }

    protected override void Zoom()
    {
        float newZoom = Mathf.Lerp(MaxZoom, MinZoom, GetGreatestDistance() / ZoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }
}
