using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MapLoader))]
public class MapDrawer : MonoBehaviour
{
    protected MapLoader loader;
    protected SectorMap map;
    protected MapCullManager mapCullManager;

    public BackGroundPlanetGenerator backGroundPlanetGenerator;
    public GameObject Player;

    public float MapUpdateRate = 5;

    public GameObject TESTEventEasy;
    public GameObject TESTEventMedium;
    public GameObject TESTEventHard;
    public GameObject TESTExit;

    protected virtual void Awake()
    {
        loader = GetComponent<MapLoader>();
    }

    protected virtual void Start()
    {
        map = loader.GetMap();
        mapCullManager = loader.GetMapCullManager();

        DrawMap();
        SetPlay();       
        
        StartCoroutine(UpdateMap());

        GameEventSystem.Map_OnDrawn(map);
    }

    protected virtual IEnumerator UpdateMap()
    {
        while(true)
        {
            yield return new WaitForSeconds(MapUpdateRate);

           //mapCullManager.CullMap(map.GetSector(Player.transform.position));
        }
    }

    protected virtual void SetPlay()
    {
        var sector = map.GetPlayerSpawnSector();
        if (sector != null)
        {
            Player.transform.position = new Vector3((sector.SectorPosX * map.SectorSize) + (map.SectorSize / 2), 0f, (sector.SectorPosZ * map.SectorSize) + (map.SectorSize / 2));
            Camera.main.transform.position = Player.transform.position;
        }
        //mapCullManager.CullMap(sector);
    }

    protected virtual void DrawMap()
    {
        foreach (var sectorList in map.GetSectors())
        {
            foreach (var sector in sectorList)
            {
                if (sector.EncounterLocation != null)
                {
                    if (sector.EncounterLocation.ObjectType == SectorObjectLocation.MapObjectTypes.Encounter ||
                       sector.EncounterLocation.ObjectType == SectorObjectLocation.MapObjectTypes.Mission)
                    {
                        if (sector.EncounterLocation.Difficulty == EncounterLocation.EncounterLocationDifficulty.Easy)
                        {
                            sector.SetMissionLocationObject(Instantiate(TESTEventEasy, new Vector3(sector.EncounterLocation.Location.x, -100, sector.EncounterLocation.Location.z), Quaternion.identity));
                        }
                        else if (sector.EncounterLocation.Difficulty == EncounterLocation.EncounterLocationDifficulty.Medium)
                        {
                            sector.SetMissionLocationObject(Instantiate(TESTEventMedium, new Vector3(sector.EncounterLocation.Location.x, -100, sector.EncounterLocation.Location.z), Quaternion.identity));
                        }
                        else if (sector.EncounterLocation.Difficulty == EncounterLocation.EncounterLocationDifficulty.Hard)
                        {
                            sector.SetMissionLocationObject(Instantiate(TESTEventHard, new Vector3(sector.EncounterLocation.Location.x, -100, sector.EncounterLocation.Location.z), Quaternion.identity));
                        }
                        else
                        {
                            Debug.Log("No Difficulty");
                        }
                    }
                    else if (sector.EncounterLocation.ObjectType == SectorObjectLocation.MapObjectTypes.Exit)
                    {
                        sector.SetMissionLocationObject(Instantiate(TESTExit, new Vector3(sector.EncounterLocation.Location.x, -100, sector.EncounterLocation.Location.z), Quaternion.identity));
                    }
                }

                foreach (var bg in sector.BackgroundLocations)
                {
                    bg.Object = backGroundPlanetGenerator.CreatePlanet(bg.Location);
                    bg.Location = bg.Object.transform.position;
                }
            }
        }
    }
}
