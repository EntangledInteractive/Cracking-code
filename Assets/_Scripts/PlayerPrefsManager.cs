using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";
    const string LEVEL_STARS = "level_Stars_";
    const string COMPLETED_LEVELS = "completed_levels";
    const string DEVICES = "Devices";
    const string COINS = "Coins";
    const string SFX = "Sfx";
    const string TUTORIALON = "Tutorian_ON";
    const string TUTLS = "TutSL";
    const string TUTGS = "TutGS";
    const string TUTES = "TutES";
    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume out of range");
        }
    }
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }
    public  static string MasterVolumeString()
    {
        return MASTER_VOLUME_KEY;
    }
    public static void SetSFXOnOff(int Sfx)
    {
        PlayerPrefs.SetInt(SFX, Sfx);

    }
    public static int GetSFXOnOFf()
    {
        return PlayerPrefs.GetInt(SFX);
    }
    public static string SFXSting()
    {
        return SFX;
    }
    public static void SetDifficulty(float diff)
    {
        if(diff >=1f && diff <=3f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, diff);
        }else
        {
            Debug.LogError("Difficulty is out of range");
        }
    }
    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
    public static void UnlockLevel(int level)
    {
        if (level <= GloableVeribale.NumberOfLevels)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); // use 1 for true
        }
        else
        {
            Debug.LogError("trying to unlock level not in build order");
        }

    }
    public static bool IsLevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);
        if (level <= GloableVeribale.NumberOfLevels)
        {
            return isLevelUnlocked;
        }
        else
        {
            Debug.LogError("trying to unlock level not in build order");
            return false;

        }

    }
    public static void SetLevelStars(int Level,int stars)
    {

        if(stars >=0 && stars <4)
        {
            PlayerPrefs.SetInt(LEVEL_STARS + Level.ToString(), stars);
        }
       // Debug.Log("stare set for level " + Level.ToString());
    }
    public static int GetLevelStars(int Level)
    {
        return PlayerPrefs.GetInt(LEVEL_STARS + Level.ToString());
    }
    public static string LevelStar(int level)
    {
        return LEVEL_STARS+level.ToString();
    }
    public static void SetCompletedLevels(int levelNumber)
    {
        if (levelNumber <= GloableVeribale.NumberOfLevels )
        {
            PlayerPrefs.SetInt(COMPLETED_LEVELS,levelNumber); 
        }
    }
    public static int GetCompletedLevels()
    {
        return PlayerPrefs.GetInt(COMPLETED_LEVELS);
    }
    public static string CompletetedSting()
    {
        return COMPLETED_LEVELS;
    }
    public static void SetDevicesLeft(int devicesLeft)
    {
        if(devicesLeft >0 && devicesLeft < 6)
        {
            PlayerPrefs.SetInt(DEVICES, devicesLeft);
        }
    }
    public static int GetDevicesLeft()
    {
        return PlayerPrefs.GetInt(DEVICES);
    }
    public static string DevicesString()
    {
        return DEVICES;
    }
    public static void SetCoins(int coin)
    {
        PlayerPrefs.SetInt(COINS, coin);
    }
    public static int GetCoins()
    {
        return PlayerPrefs.GetInt(COINS);
    }
    public static string CoinString()
    {
        return PlayerPrefs.GetString(COINS).ToString();
    }
    public static void SetTutorialOnOff(int OnOff)
    {
        PlayerPrefs.SetInt(TUTORIALON, OnOff);
    }
    public static int GetTutorialOnOff()
    {
        return PlayerPrefs.GetInt(TUTORIALON);
    }
    public static string TutorialOnOffString()
    {
        return TUTORIALON;
    }    
    public static void SetTutLS(int TutLSonOff)
    {
        PlayerPrefs.SetInt(TUTLS, TutLSonOff);
    }
    public static int GetTutLS()
    {
        return PlayerPrefs.GetInt(TUTLS);
    }
    public static string TutLSString()
    {
        return TUTLS;
    }
    public static void SetTutGS(int TutGSonOff)
    {
        PlayerPrefs.SetInt(TUTGS, TutGSonOff);
    }
    public static int GetTutGS()
    {
        return PlayerPrefs.GetInt(TUTGS);
    }
    public static string TutGSString()
    {
        return TUTGS;
    }
    public static void SetTutES(int TutESonOff)
    {
        PlayerPrefs.SetInt(TUTES, TutESonOff);
    }
    public static int GetTutES()
    {
        return PlayerPrefs.GetInt(TUTES);
    }
    public static string TutESString()
    {
        return TUTES;
    }
}
