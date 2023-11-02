using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class UIWaypointMarker : MonoBehaviour
{
    public Image WaypointImage;
    protected GameObject target;

    protected float imageMinX;
    protected float imageMaxX;

    protected float imageMinY;
    protected float imageMaxY;

    protected virtual void Awake()
    {
        if (WaypointImage == null) return;

        imageMinX = WaypointImage.GetPixelAdjustedRect().width / 2;
        imageMaxX = Screen.width - imageMinX;

        imageMinY = WaypointImage.GetPixelAdjustedRect().height / 2;
        imageMaxY = Screen.height - imageMinY;

        GameEventSystem.Map_Drawn += GameEventSystem_Map_Drawn;
        GameEventSystem.Encounter_MissionChange += GameEventSystem_Sector_MissionChange;
    }

    private void GameEventSystem_Map_Drawn(SectorMap map)
    {
        SetTarget(map.GetActiveMissionSector().EncounterLocation.Object);
    }

    private void GameEventSystem_Sector_MissionChange(Encounter encounter)
    {
        if (encounter != null) SetTarget(encounter.gameObject);
    }

    protected virtual void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    protected virtual void Update()
    {
        if (WaypointImage == null) return;
        if (target == null)
        {
            if (WaypointImage.gameObject.activeSelf) WaypointImage.gameObject.SetActive(false);
            return;
        }

        if (!WaypointImage.gameObject.activeSelf) WaypointImage.gameObject.SetActive(true);
        var pos = Camera.main.WorldToScreenPoint(target.transform.position);
        pos.x = Mathf.Clamp(pos.x, imageMinX, imageMaxX);
        pos.y = Mathf.Clamp(pos.y, imageMinY, imageMaxY);
        WaypointImage.transform.position = pos;
    }
}
