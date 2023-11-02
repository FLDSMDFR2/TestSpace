using UnityEngine;

public class SectorObjectLocation
{
    public enum MapObjectTypes
    {
        None = 0,
        BackGround,
        Encounter,
        Mission,
        Exit
    }

    public MapObjectTypes ObjectType = MapObjectTypes.None;
    public Vector3 Location = Vector3.negativeInfinity;
    public GameObject Object;
}
