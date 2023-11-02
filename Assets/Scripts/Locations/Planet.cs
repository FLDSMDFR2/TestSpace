using UnityEngine;

public class Planet : MonoBehaviour
{
    public bool HasRings;
    public GameObject Rings;

    protected virtual void OnEnable()
    {
        if (HasRings) Rings.SetActive(true);
        else Rings.SetActive(false);
    }
}
