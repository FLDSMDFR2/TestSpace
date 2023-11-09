using System.Collections.Generic;
using UnityEngine;

public class MapObjectListProvider : MapObjectProvider
{
    public List<GameObject> Object;

    public override GameObject GetObject()
    {
        return Instantiate(Object[RandomGenerator.SeededRange(0, Object.Count)], Vector3.zero, Quaternion.identity, this.transform);
    }
}