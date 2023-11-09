using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlanetSpawner : MonoBehaviour
{
    public PlanetGenerator Provider;

    [Header("Background")]
    public float MaxSize;
    public float MinSize;
    public float YValue;

    public float ReseatTime = 5;

    protected List<GameObject> planetList = new List<GameObject>();
    protected bool clearList;

    protected virtual void Awake()
    {
        var dirX = RandomGenerator.SeededRange(0f, 1f);
        var dirZ = RandomGenerator.SeededRange(0f, 1f);
    }

    protected virtual void Start()
    {
        StartCoroutine(CreatePlanets());
    }

    protected virtual IEnumerator CreatePlanets()
    {
        while (true)
        {
            ClearPlanets();

            for (int x = 0; x < 10; x++)
            {
                for (int z = 0; z < 10; z++)
                {
                    //CreatePlanet(transform.position + new Vector3( x * MaxSize, 0, z * MaxSize));
                }
            }

            yield return new WaitForSeconds(ReseatTime);
        }
    }

    //public virtual GameObject CreatePlanet(Vector3 loc)
    //{
    //    var scale = RandomGenerator.SeededRange(MinSize, MaxSize);
    //    var planet = Provider.GetNewObject(RandomGenerator.UnseededRandomBool());
    //    planet.transform.position = new Vector3(loc.x, -(scale + YValue), loc.z);
    //    planet.transform.localScale = new Vector3(scale, scale, scale);
    //    planet.transform.rotation = Quaternion.Euler(0, 0, 90);

    //    var palentScript = planet.GetComponent<Planet>();
    //    if (palentScript != null)
    //    {
    //        palentScript.HasRings = RandomGenerator.SeededRandomBool();
    //    }

    //    planetList.Add(planet);
    //    planet.SetActive(true);
    //    return planet;
    //}

    protected virtual void ClearPlanets()
    {
        foreach (var planet in planetList)
        {
            Destroy(planet);
        }

        planetList.Clear();
    }
}

