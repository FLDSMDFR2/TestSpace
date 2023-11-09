using UnityEngine;

public abstract class MapObjectProvider : ObjectProvider
{
    [Header("Map Object Provider")]
    public MapObjectTypes ObjectType;
    public float MaxSize;
    public float MinSize;
    public float YValueOffset;
    public float Padding;
}

