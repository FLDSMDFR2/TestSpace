using UnityEngine;

public class OrthographicCameraController : CameraController
{
    protected Player player;

    protected override void Start()
    {
        player = targets[0].GetComponentInChildren<Player>();
        base.Start();
    }

    protected override void Move()
    {
        //transform.position = Vector3.Lerp(transform.position, centerPoint + OffSet, SmoothTime);
        transform.position = Vector3.SmoothDamp(transform.position, MoveToPos(), ref velocity, SmoothTime, MaxMoveSpeed); ;
    }

    protected override Vector3 MoveToPos()
    {
        Vector3 centerPoint = GetCenterPoint();
        var temp = GetMousePos();
        centerPoint += GetMousePos() + (OffSet + (player.MovementVelocity));

        return centerPoint;
    }

    protected override void Zoom()
    {
        float newZoom = Mathf.Lerp(MaxZoom, MinZoom, GetGreatestDistance() / ZoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }
}
