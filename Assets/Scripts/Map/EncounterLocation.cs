public class EncounterLocation : SectorObjectLocation
{
    public enum EncounterLocationDifficulty
    {
        None = 0,
        Easy,
        Medium,
        Hard
    }

    public EncounterLocationDifficulty Difficulty;
    public Encounter Encounter;
}
