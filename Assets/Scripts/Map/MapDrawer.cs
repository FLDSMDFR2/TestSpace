using System.Collections;
using UnityEngine;

public class MapDrawer : MonoBehaviour
{
    protected SectorMap map;
    protected MapCullManager mapCullManager;

    public GameObject Player;

    public float MapUpdateRate = 5;

    public virtual void DrawMap(SectorMap map, MapCullManager mapCullManager)
    {
        this.map = map;
        this.mapCullManager = mapCullManager;

        Draw();
        SetPlay();       
        
        StartCoroutine(UpdateMap());

        GameEventSystem.Map_OnDrawn(map);
    }

    public virtual void ClearMap()
    {
        if (map == null) return;

        StopCoroutine(UpdateMap());

        foreach (var sectorList in map.GetSectors())
        {
            foreach (var sector in sectorList)
            {
                if (sector.EncounterLocation != null && sector.EncounterLocation.Object != null) Destroy(sector.EncounterLocation.Object);

                foreach(var bgo in sector.BackgroundObjects)
                {
                    if (bgo.Object != null) Destroy(bgo.Object);
                }
                sector.BackgroundObjects.Clear();
            }
        }
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

    protected virtual void Draw()
    {
        foreach (var sectorList in map.GetSectors())
        {
            foreach (var sector in sectorList)
            {
                if (sector.EncounterLocation != null && sector.EncounterLocation.ObjectManager != null)
                {
                    var obj = sector.EncounterLocation.ObjectManager.GetObject(sector.EncounterLocation.ObjectType);
                    if (obj == null) continue;

                    obj.transform.position = sector.EncounterLocation.Location;
                    obj.transform.localScale = new Vector3(sector.EncounterLocation.Scale, sector.EncounterLocation.Scale, sector.EncounterLocation.Scale);
                    sector.SetMissionLocationObject(obj);
                }

                foreach (var bg in sector.BackgroundObjects)
                {
                    if (bg.ObjectManager == null) continue;
                    var obj = bg.ObjectManager.GetObject(bg.ObjectType);
                    if (obj == null) continue;

                    obj.transform.position = new Vector3(bg.Location.x, bg.Location.y, bg.Location.z);
                    obj.transform.localScale = new Vector3(bg.Scale, bg.Scale, bg.Scale);
                    obj.transform.rotation = Quaternion.Euler(0, 0, 90);

                    bg.Object = obj;
                    bg.Location = bg.Object.transform.position;
                }
            }
        }
    }
}
