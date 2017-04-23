using UnityEngine;
using System.Collections;

public class LevelSettings : MonoBehaviour
{
    public static LevelSettings instance;
    public int LevelNumber;
    public int NumberOfSlots;
    public int NumberOfTrys;
    public bool BlueBlock;
    public bool GreenBlock;
    public bool RedBlock;
    public bool YellowBlock;
    public bool PurpleBlock;
    public bool OrangeBlock;
    public int NumberOfColours;
    public int LevelStars;
    public int OneStar;
    public int TwoStar;
    public int ThreeStar;
    public bool TimerCallange;
    public int TimeForTimerCallange;
    public bool DesaperingCallange;
    public int DesaperingNumber;
    public bool ExpandinSlotChallange;
    public int FirstExpandstion;
    public int SecondExpandstion;
    public bool ColourShift;
    public bool HasLevelBeenCompleted = false;
    // Use this for initialization
    void Start()
    {
        instance = this;
        StarUpdate();
    }


    // Update is called once per frame
    void Update() {
     
    }
    public void StarUpdate()
    {

        LevelStars = PlayerPrefsManager.GetLevelStars(LevelNumber);
        if (PlayerPrefs.HasKey("Level" + LevelNumber + "Completed"))
        {
            if (PlayerPrefs.GetInt("Level" + LevelNumber + "Completed") == 1)
            {
                HasLevelBeenCompleted = true;
            }
        }
        else
        {
            PlayerPrefs.SetInt("Level" + LevelNumber + "Completed", 0);
            PlayerPrefs.Save();
            HasLevelBeenCompleted = false;
        }
        HasLevelBeenCompleted = PlayerPrefsManager.IsLevelUnlocked(LevelNumber);
    }
}
