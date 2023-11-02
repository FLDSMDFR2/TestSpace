using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundPlanetGenerator : MonoBehaviour
{
    public PlanetProvider Provider;
    public float Speed;
    protected Vector3 direction;

    [Header("Background")]
    public float MaxSize;
    public float MinSize;
    public float YValue;

    protected List<GameObject> planetList = new List<GameObject>();
    protected bool clearList;

    protected virtual void Awake()
    {
        var dirX = RandomGenerator.SeededRange(0f, 1f);
        var dirZ = RandomGenerator.SeededRange(0f, 1f);
        direction = new Vector3 (dirX, 0F, dirZ);
    }

    //protected virtual void Update()
    //{
    //    if (planetList.Count <= 0) return;

    //    foreach (GameObject go in planetList)
    //    {
    //        var pos = (direction * (Speed * Time.deltaTime));
    //        go.transform.position = new Vector3(go.transform.position.x + pos.x, go.transform.position.y, go.transform.position.z + pos.z);
    //    }

    //    if (clearList) planetList.Clear();
    //    clearList = false;
    //}

    public virtual GameObject CreatePlanet(Vector3 loc)
    {
        var scale = RandomGenerator.SeededRange(MinSize, MaxSize);
        var planet = Provider.GetNewPlanet(true);
        planet.transform.position = new Vector3(loc.x, -(scale + YValue), loc.z);
        planet.transform.localScale = new Vector3(scale, scale, scale);
        planet.transform.rotation = Quaternion.Euler(0, 0, 90);

        var palentScript = planet.GetComponent<Planet>();
        if (palentScript != null)
        {
            palentScript.HasRings = RandomGenerator.SeededRandomBool();
        }

        planetList.Add(planet);
        planet.SetActive(true);
        return planet;
    }

    public virtual void ClearPlanets()
    {
        clearList = true;
    }
}
