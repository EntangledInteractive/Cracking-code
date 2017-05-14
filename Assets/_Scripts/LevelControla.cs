using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using ExaGames.Common;
using HardCodeLab.TutorialMaster;

public class LevelControla : MonoBehaviour
{
    public Text playerLevel;
    public Button UpB;
    public Button DownB;
    public Button StartB;
    //private static bool DoesLevelExist = true;
    public Image Clipboard;
    public Sprite BegingCB;
    public Sprite MiddleCB;
    public Sprite EndCB;
    public Text devicesLeft;
    //life system
    public LivesManager LivesManager;   
    public Text LivesText;   
    public Text TimeToNextLifeText;
    // coins
    public Text coin;
    //public GameObject TutorialPanel;
    public GameObject tutTextbox;
    public Button skipTutButton;
    

    public void OnLivesChanged()
    {
        LivesText.text = LivesManager.Lives.ToString();
    }

    /// <summary>
    /// Time to next life changed event handler, changes the label value.
    /// </summary>
    public void OnTimeToNextLifeChanged()
    {
        TimeToNextLifeText.text = LivesManager.RemainingTimeString;
    }
    public void ComsumeLive()
    {
        if (!GloableVeribale.PlayOn)
        {
            LivesManager.ConsumeLife();
        }
       
    }
    void Awake()
    {
        if (GloableVeribale.PlayLevel >= GloableVeribale.NumberOfLevels)
        {
            Clipboard.sprite = EndCB;
            UpB.gameObject.SetActive(false);
        }
        else
        {
            Clipboard.sprite = MiddleCB;
            UpB.gameObject.SetActive(true);
        }
        if (GloableVeribale.PlayLevel < 2)
        {
            Clipboard.sprite = BegingCB;
            UpB.gameObject.SetActive(true);
        }
        else
        {
            Clipboard.sprite = MiddleCB;
            UpB.gameObject.SetActive(true);
        }
        SetTutorialPanel();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coin.text = PlayerPrefsManager.GetCoins().ToString();
        playerLevel.text = "Level " + GloableVeribale.PlayLevel.ToString();
       // devicesLeft.text = PlayerPrefsManager.GetDevicesLeft().ToString();
        if (GloableVeribale.PlayLevel > 1)
        {

            DownB.interactable = true;
        }
        else
        {
            DownB.interactable = false;

        }


        if (GloableVeribale.PlayLevel <= PlayerPrefsManager.GetCompletedLevels())
        {
            if (LivesManager.Lives > 0)
            {
                StartB.interactable = true;
            }else
            {
                StartB.interactable = false;
            }
            UpB.interactable = true;


        }
        else
        {
            StartB.interactable = false;
        }

        if(LivesManager.Lives == 5)
        {
            TimeToNextLifeText.gameObject.SetActive(false);
        }else
        {
            TimeToNextLifeText.gameObject.SetActive(true);
        }


    }
    public void LevelUp()
    {
        GloableVeribale.PlayLevel += 1;
        if (GloableVeribale.PlayLevel >= GloableVeribale.NumberOfLevels)
        {
            GloableVeribale.PlayLevel = GloableVeribale.NumberOfLevels;
            UpB.interactable = false;
            Clipboard.sprite = EndCB;
            UpB.gameObject.SetActive(false);
        }
        else
        {
            UpB.gameObject.SetActive(true);
            UpB.interactable = true;
            Clipboard.sprite = MiddleCB;
        }
        PlayerPrefs.SetInt("MaxPlayerLevel", GloableVeribale.PlayLevel);
        PlayerPrefs.Save();

        //LevelSettings.instance.StarUpdate();
    }
    public void LevelDown()
    {
        GloableVeribale.PlayLevel -= 1;
        if (GloableVeribale.PlayLevel < 2)
        {
            GloableVeribale.PlayLevel = 1;
            DownB.interactable = false;
            Clipboard.sprite = BegingCB;
            UpB.gameObject.SetActive(true);
        }
        else
        {
            UpB.gameObject.SetActive(true);
            UpB.interactable = true;
            Clipboard.sprite = MiddleCB;
        }
        PlayerPrefs.SetInt("MaxPlayerLevel", GloableVeribale.PlayLevel);
        PlayerPrefs.Save();
        // LevelSettings.instance.StarUpdate();

    }
    public void SetTutorialPanel()
    {
        if (GloableVeribale.TutorialEnabled == true)
        {
            skipTutButton.gameObject.SetActive(true);
            tutTextbox.gameObject.SetActive(true);
            tutorial.Start(0);
        } 
        
    }
    public void HidtutTextbox()
    {
        
            tutTextbox.gameObject.SetActive(false);
        skipTutButton.gameObject.SetActive(false);

    }
    public void TutStop()
    {
        tutorial.Stop();
    }

}
