using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//using PlayerPrefs = PreviewLabs.PlayerPrefs;
public class GloableVeribale : MonoBehaviour
{
    public static GloableVeribale Instance= null;
    public static int PlayLevel = 1;
    public static int Coins;
    public float WaitTimer;
    public bool RunOnce;
    public static int NumberOfLevels = 21;
    public static int CompletedLevels = 1;
    public static int AdCount;
    //public static int DeviceLeft;
    public static bool PlayOn = false;
    public static bool SfxOn = true;
    public static bool TutorialEnabled = true;
    public static bool TutLS = true;
    public static bool TutGS = true;
    public static bool TutES = true;

    //Game Level infromation
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


    public int testint;
    public bool tutTest;
    public int coinTest;
    
    
    public bool GameEnd;
    //game backround music    
    public AudioSource Asource;    
    public bool  Sfxtest;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            print("Duplicate Game Controller self-destructing!");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
           
        RunOnce = true;
        SetUpLevel();
      

    }
    public void SetUpLevel()
    {
        if (PlayerPrefs.HasKey("MaxPlayerLevel"))
        {
            PlayLevel = PlayerPrefs.GetInt("MaxPlayerLevel");
            if (PlayerPrefs.HasKey(PlayerPrefsManager.CompletetedSting()))
            {

                CompletedLevels = PlayerPrefsManager.GetCompletedLevels();
            }
            else
            {
                PlayerPrefsManager.SetCompletedLevels(1);
                PlayerPrefs.Save();
                CompletedLevels = PlayerPrefsManager.GetCompletedLevels();
            }
        }
        else
        {
            PlayerPrefs.SetInt("MaxPlayerLevel", 1);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.HasKey(PlayerPrefsManager.CoinString()))
        {
            //Debug.Log("there is coins");
            Coins = PlayerPrefsManager.GetCoins();
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefsManager.SetCoins(5);
            Coins = PlayerPrefsManager.GetCoins();
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.HasKey(PlayerPrefsManager.TutorialOnOffString()))
        {
            if(PlayerPrefsManager.GetTutorialOnOff() == 1)
            {
                TutorialEnabled = true;
            }else
            {
                TutorialEnabled = false;
            }
        }
        if (PlayerPrefs.HasKey(PlayerPrefsManager.TutLSString()))
        {
            if (PlayerPrefsManager.GetTutLS() == 1)
            {
                TutLS = true;
            }
            else
            {
                TutLS = false;
            }
        }
        if (PlayerPrefs.HasKey(PlayerPrefsManager.TutGSString()))
        {
            if (PlayerPrefsManager.GetTutGS() == 1)
            {
                TutGS = true;
            }
            else
            {
                TutGS = false;
            }
        }
        if (PlayerPrefs.HasKey(PlayerPrefsManager.TutESString()))
        {
            if (PlayerPrefsManager.GetTutES() == 1)
            {
                TutES = true;
            }
            else
            {
                TutES = false;
            }
        }


    }
    
    
    void Start()
    {
        Instance = this;
        WaitTimer = Time.time + WaitTimer;

        for (int i = 1; i < NumberOfLevels; i++)
        {
            if (PlayerPrefs.HasKey(PlayerPrefsManager.LevelStar(i)))
            {
                //Debug.Log("there is a star for " + i + " it has " + PlayerPrefsManager.GetLevelStars(i));
            }
            else
            {
                PlayerPrefsManager.SetLevelStars(i, 0);

            }
           
        }
        if (PlayerPrefs.HasKey(PlayerPrefsManager.TutorialOnOffString()))
        {
            if(PlayerPrefsManager.GetTutorialOnOff() == 1 )
            {
                TutorialEnabled = true;
                Debug.Log("checking if tutorial are on");
            }
            else
            {
                TutorialEnabled = false;
                Debug.Log("checking if tutorial are off");
            }
            
        }
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
            if (RunOnce)
            {
            if (WaitTimer > 0)
            {
                if (Time.time > WaitTimer)
                {
                    SceneManager.LoadScene(1);
                    RunOnce = false;

                }
            }
            }

        testint = PlayLevel;
        //deciveTest = DeviceLeft;
        coinTest = Coins;
        Sfxtest = SfxOn;
        tutTest = TutorialEnabled;
    }
    void OnApplicationPause()
    {
        int tutTF;
        int tutLS;
        int tutGS;
        int tutES;
        Debug.Log("pausing the game");
        PlayerPrefsManager.SetCoins(Coins);
        if (TutorialEnabled == true)
        {
            tutTF = 1;
        }
        else
        {
            tutTF = 0;

        }
        PlayerPrefsManager.SetTutorialOnOff(tutTF);
        if (TutLS == true)
        {
            tutLS = 1;
        }
        else
        {
            tutLS = 0;
        }
        PlayerPrefsManager.SetTutLS(tutLS);
        if (TutGS == true)
        {
            tutGS = 1;
        }
        else
        {
            tutGS = 0;
        }
        PlayerPrefsManager.SetTutLS(tutGS);
        if (TutES == true)
        {
            tutES = 1;
        }
        else
        {
            tutES = 0;
        }
        PlayerPrefsManager.SetTutLS(tutES);
        PlayerPrefs.Save();
    }
}

