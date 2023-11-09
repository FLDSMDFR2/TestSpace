using UnityEditor;
using UnityEngine;

public class OrthographicCameraController : CameraController
{
    protected Ship ship;

    protected override void Start()
    {
        ship = targets[0].GetComponentInChildren<Ship>();
        base.Start();
    }

    protected override void Move()
    {
        transform.position = Vector3.SmoothDamp(transform.position, MoveToPos(), ref velocity, SmoothTime, MaxMoveSpeed);
    }

    protected override Vector3 MoveToPos()
    {
        Vector3 centerPoint = GetCenterPoint();
        centerPoint += GetMousePos() + (OffSet + (ship.MovementVelocity));

        return centerPoint;
    }

    protected override void Zoom()
    {
        float newZoom = Mathf.Clamp(MinZoom + ship.MovementVelocity.magnitude, MinZoom, MaxZoom);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);
    }
}
