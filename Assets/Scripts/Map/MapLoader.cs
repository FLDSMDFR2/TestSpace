using UnityEngine;

public class MapLoader : MonoBehaviour
{
    public int TotalSectorsX = 10;
    public int TotalSectorsZ = 10;

    public int SectorSize = 1000;

    public int CullingDistance = 2;

    public int EncounterDistanceDifficulty = 2;
    public int MissionsToComplete = 2;

    protected SectorMap map;
    protected MapCullManager cullManager;
    protected MapBuilder backGroundObjects;
    protected MapBuilder encounterLocations;
    protected MapBuilder playerSpawn;
    protected MapBuilder missionEncounterLocations;
    protected MapBuilder exitLocation;

    protected MapBuilder mapValidator;
    protected EncounterManager encounterManager;

    protected virtual void Awake()
    {
        var isValidMap = false;
        while (!isValidMap)
        {
            //build map
            map = new SectorMap(TotalSectorsX, TotalSectorsZ, SectorSize);

            // set player spawn
            playerSpawn = new MapBuilderPlayerSpawn(map);
            playerSpawn.PerformBuilderProcess();

            //create background objects
            backGroundObjects = new MapBuilderBackGroundObjects(map);
            backGroundObjects.PerformBuilderProcess();

            //create encounter locations
            encounterLocations = new MapBuilderEncounterObjects(map, EncounterDistanceDifficulty);
            encounterLocations.PerformBuilderProcess();

            //create mission locations
            missionEncounterLocations = new MapBuilderMissionEncounterLocations(map, MissionsToComplete);
            missionEncounterLocations.PerformBuilderProcess();

            // create exit location
            exitLocation = new MapBuilderExit(map);
            exitLocation.PerformBuilderProcess();

            // validate we have a good map
            mapValidator = new MapBuilderValidator(map, MissionsToComplete);
            mapValidator.PerformBuilderProcess();
            isValidMap = ((MapBuilderValidator)mapValidator).IsValidMap();
        }

        encounterManager = new EncounterManager(map);
        cullManager = new MapCullManager(map, CullingDistance);
    }

    protected virtual void Start()
    {
        GameEventSystem.Map_OnBuilt(map);
    }

    public virtual SectorMap GetMap()
    {
        return map;
    }

    public virtual MapCullManager GetMapCullManager()
    {
        return cullManager;
    }
}
