using UnityEngine;

public abstract class MapObjectGenerator : MonoBehaviour
{
    [Header("Object Generator")]
    public GameObject Prefab;
    public Material Material;

    public abstract GameObject GetObject(bool isBackground);
}
