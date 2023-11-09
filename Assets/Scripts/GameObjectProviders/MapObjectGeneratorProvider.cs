using UnityEngine;

public class MapObjectGeneratorProvider : MapObjectProvider
{
    public MapObjectGenerator Generator;

    public override GameObject GetObject()
    {
        return Generator.GetObject(true);
    }
}
