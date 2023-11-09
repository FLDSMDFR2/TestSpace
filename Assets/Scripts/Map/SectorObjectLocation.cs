using UnityEngine;

public class SectorObjectLocation
{
    public MapObjectTypes ObjectType = MapObjectTypes.None;
    public Vector3 Location = Vector3.negativeInfinity;
    public float Scale = 0;
    public MapObjectManager ObjectManager = null;
    public GameObject Object = null;
}
