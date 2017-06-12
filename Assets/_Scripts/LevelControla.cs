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
    public Sprite GoPlay;
    public Sprite StopPlay;
    //private static bool DoesLevelExist = true;

    public Text devicesLeft;
    //life system
    public LivesManager LivesManager;
    public Text LivesText;
    public Text TimeToNextLifeText;
    // coins
    public Text coin;
    public GameObject TutUIBacround;
    public Button SkipTut;
    public Button StartTut;


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

            UpB.gameObject.SetActive(false);
        }
        else
        {

            UpB.gameObject.SetActive(true);
        }
        if (GloableVeribale.PlayLevel < 2)
        {

            UpB.gameObject.SetActive(true);
        }
        else
        {

            UpB.gameObject.SetActive(true);
        }
        if (GloableVeribale.TutorialEnabled == true && GloableVeribale.TutLS == true)
        {
            // Debug.Log("LS tut loaded");
            SetTutorialPanel();
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coin.text = PlayerPrefsManager.GetCoins().ToString();
        playerLevel.text = "Safe " + GloableVeribale.PlayLevel.ToString();
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
                StartB.GetComponent<Image>().sprite = GoPlay;
            }
            else
            {
                StartB.interactable = false;
                StartB.GetComponent<Image>().sprite = StopPlay;
            }
            UpB.interactable = true;


        }
        else
        {
            StartB.interactable = false;
            StartB.GetComponent<Image>().sprite = StopPlay;
        }

        if (LivesManager.Lives == 5)
        {
            TimeToNextLifeText.gameObject.SetActive(false);
        }
        else
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

            UpB.gameObject.SetActive(false);
        }
        else
        {
            UpB.gameObject.SetActive(true);
            UpB.interactable = true;

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

            UpB.gameObject.SetActive(true);
        }
        else
        {
            UpB.gameObject.SetActive(true);
            UpB.interactable = true;

        }
        PlayerPrefs.SetInt("MaxPlayerLevel", GloableVeribale.PlayLevel);
        PlayerPrefs.Save();
        // LevelSettings.instance.StarUpdate();

    }
    public void SetTutorialPanel()
    {
        StartTut.gameObject.SetActive(true);
        TutUIBacround.SetActive(true);
        SkipTut.gameObject.SetActive(true);
        tutorial.Start(0);


    }
    public void hideTutUiPanel()
    {
        TutUIBacround.SetActive(false);
        SkipTut.gameObject.SetActive(false);
        GloableVeribale.TutLS = false;
        StartTut.gameObject.SetActive(false);
        GloableVeribale.SaveTut();
        PlayerPrefs.Save();
    }
    public void SkipTutButton()
    {
        tutorial.Stop();
        StartTut.gameObject.SetActive(false);
        GloableVeribale.SaveTut();
        PlayerPrefs.Save();
    }
    public void HideStartTut()
    {
        StartTut.gameObject.SetActive(false);
        PlayerPrefs.Save();
    }
   

}
