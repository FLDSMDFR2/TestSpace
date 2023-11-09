using UnityEngine;

[RequireComponent(typeof(MapDrawer))]
public class MapLoader : MonoBehaviour
{
    public int TotalSectorsX = 10;
    public int TotalSectorsZ = 10;

    public int SectorSize = 1000;

    public int CullingDistance = 2;

    public int EncounterDistanceDifficulty = 2;
    public int MissionsToComplete = 2;

    public MapObjectManager MapObjectManager;

    protected SectorMap map;
    protected MapCullManager cullManager;
    protected MapBuilder backGroundObjects;
    protected MapBuilder encounterLocations;
    protected MapBuilder playerSpawn;
    protected MapBuilder missionEncounterLocations;
    protected MapBuilder exitLocation;

    protected MapBuilder mapValidator;
    protected EncounterManager encounterManager;
    protected MapDrawer mapDrawer;

    protected static int mapBoundsX = 10;
    protected static int mapBoundsZ = 10;

    protected virtual void Awake()
    {
        mapBoundsX = TotalSectorsX * SectorSize;
        mapBoundsZ = TotalSectorsZ * SectorSize;

        mapDrawer = GetComponent<MapDrawer>();
        GameEventSystem.Game_Start += GameEventSystem_Game_Start;
    }

    protected virtual void GameEventSystem_Game_Start()
    {
        if (BuildMap())
        {
            GameEventSystem.Map_OnBuilt(map);
            mapDrawer.ClearMap();   
            mapDrawer.DrawMap(map, cullManager);
        }
        else
        {
            Debug.Log("Map Build Failed");
        }
    }

    public virtual bool BuildMap()
    {
        var tryCount = 50;
        var isValidMap = false;
        while (!isValidMap && tryCount > 0)
        {
            tryCount--;

            //build map
            map = new SectorMap(TotalSectorsX, TotalSectorsZ, SectorSize);

            // set player spawn
            playerSpawn = new MapBuilderPlayerSpawn(map);
            playerSpawn.PerformBuilderProcess();

            //create background objects
            backGroundObjects = new MapBuilderBackGroundObjects(map, MapObjectManager);
            backGroundObjects.PerformBuilderProcess();

            //create encounter locations
            encounterLocations = new MapBuilderEncounterObjects(map, MapObjectManager, EncounterDistanceDifficulty);
            encounterLocations.PerformBuilderProcess();

            //create mission locations
            missionEncounterLocations = new MapBuilderMissionEncounterLocations(map, MissionsToComplete);
            missionEncounterLocations.PerformBuilderProcess();

            // create exit location
            exitLocation = new MapBuilderExit(map, MapObjectManager);
            exitLocation.PerformBuilderProcess();

            // validate we have a good map
            mapValidator = new MapBuilderValidator(map, MissionsToComplete);
            mapValidator.PerformBuilderProcess();
            isValidMap = ((MapBuilderValidator)mapValidator).IsValidMap();
        }

        encounterManager = new EncounterManager(map);
        cullManager = new MapCullManager(map, CullingDistance);

        return isValidMap;
    }

    public static int MapBoundsX()
    {
        return mapBoundsX;
    }
    public static int MapBoundsZ()
    {
        return mapBoundsZ;
    }
}
