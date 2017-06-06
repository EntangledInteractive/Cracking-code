using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameStart : MonoBehaviour
{
    // the number of trys that the player will have before they fail the level
    public Text NumerOfTrys;
    public int Trys;
    //this is the number of slots the level will start with
    private int Slots;
    //lights that display the colour the player has selected
    public GameObject[] ColourLights;
    // lights that house the secret code
    public GameObject[] ToolLights;
    // these buttons are for the player to input the colour combination
    public Button ButtonBlue;
    public Button ButtonRed;
    public Button ButtonGreen;
    public Button ButtonYellow;
    public Button ButtonPurple;
    public Button ButtonOrange;
    //need to test the code the player put in
    private int CorrectGuess;
    private int TotalTrys;
    public Sprite WhitePanelLight;
    public Sprite GreenLight;
    public Sprite RedLight;
    public GameObject GussedPanel;
    public GameObject GussedLightsPanel;
    public GameObject GussedLightsCorrect;
    public GameObject GussedBar;
    public GameObject SecondGussedPanel;
    public GameObject SecondGussedCorrect;
    public GameObject SecondBar;
    public GameObject GussedPanelTop;
    //used for the time challange when active
    public Text TimeChallangeText;
    private float TimeChallangeTime;
    private string TimeFormat;
    //used for the disapering challange when active
    private int DisaperingNumber;
    // slot Expanding Challange;
    public int FirstExpanstion;
    public int secondExpanstion;
    public bool Expand = false;
    // colour shift challange;
    public int NewColour;
    public int OldColour;
    //color unlock
    public static bool Unlock;
    public bool TestUnlock;
    public Text TotalCoins;
    public GameObject UnlockButton;
    public Button BUnlock;
    public bool AnimFinshed = false;
    //check the player has wun on the last try
    private bool LastTryWin=false;
    // Use this for initialization
    void OnGameStart()
    {
        Slots = GloableVeribale.Instance.NumberOfSlots;
        NumerOfTrys.text = GloableVeribale.Instance.NumberOfTrys.ToString();
        Trys = GloableVeribale.Instance.NumberOfTrys;
        for (int i = 0; i < Slots; i++)
        {
            ColourLights[i].gameObject.SetActive(true);
            ToolLights[i].gameObject.SetActive(true);
        }
        if (GloableVeribale.Instance.BlueBlock)
        {
            ButtonBlue.interactable = true;
        }
        else
        {
            ButtonBlue.interactable = false;
        }
        if (GloableVeribale.Instance.RedBlock)
        {
            ButtonRed.interactable = true;
        }
        else
        {
            ButtonRed.interactable = false;
        }

        if (GloableVeribale.Instance.GreenBlock)
        {
            ButtonGreen.interactable = true;
        }
        else
        {
            ButtonGreen.interactable = false;
        }
        if (GloableVeribale.Instance.YellowBlock)
        {
            ButtonYellow.interactable = true;
        }
        else
        {
            ButtonYellow.interactable = false;
        }
        if (GloableVeribale.Instance.PurpleBlock)
        {
            ButtonPurple.interactable = true;
        }
        else
        {
            ButtonPurple.interactable = false;
        }
        if (GloableVeribale.Instance.OrangeBlock)
        {
            ButtonOrange.interactable = true;
        }
        else
        {
            ButtonOrange.interactable = false;
        }
        if (GloableVeribale.Instance.TimerCallange)
        {
            TimeChallangeText.gameObject.SetActive(true);
            TimeChallangeTime = GloableVeribale.Instance.TimeForTimerCallange;
            TimeFormat = string.Format("{00}", (int)TimeChallangeTime % 60);
            TimeChallangeText.text = TimeFormat;
        }
        if (GloableVeribale.Instance.DesaperingCallange)
        {
            DisaperingNumber = GloableVeribale.Instance.DesaperingNumber;
        }
        if (GloableVeribale.Instance.ExpandinSlotChallange)
        {

            FirstExpanstion = GloableVeribale.Instance.FirstExpandstion;
            secondExpanstion = GloableVeribale.Instance.SecondExpandstion;
        }
        AnimFinshed = true;
    }
    void Start()
    {
        // OnGameStart();

    }

    // Update is called once per frame
    void Update()
    {


        if (GloableVeribale.Instance.TimerCallange)
        {
            if (!NewColourChanger.Instance.RunOnce)
            {
                TimeChallangeTime -= Time.deltaTime;
                TimeFormat = string.Format("{00}", (int)TimeChallangeTime % 60);

                TimeChallangeText.text = TimeFormat;
            }

            if (TimeChallangeTime < 0)
            {
                TestCombination();
            }

        }
        if (GloableVeribale.Instance.ExpandinSlotChallange)
        {
            if (Expand)
            {
                if (TotalTrys == FirstExpanstion)
                {
                    Debug.Log("first expanstion");
                    GloableVeribale.Instance.NumberOfSlots += 1;
                    ColourLights[3].transform.gameObject.SetActive(true);
                    ToolLights[3].transform.gameObject.SetActive(true);
                    ToolLights[3].GetComponent<HidenColour>().PickColour();

                    NewColourChanger.Instance.NumberOfSlots += 1;
                    Expand = false;
                }
                if (TotalTrys == secondExpanstion)
                {
                    Debug.Log("Second expanstion");
                    GloableVeribale.Instance.NumberOfSlots += 1;
                    ColourLights[4].transform.gameObject.SetActive(true);
                    ToolLights[4].transform.gameObject.SetActive(true);
                    ToolLights[4].GetComponent<HidenColour>().PickColour();

                    Expand = false;
                    NewColourChanger.Instance.NumberOfSlots += 1;
                }
            }
        }
        if (Unlock)
        {
            //this.GetComponent<Animator>().SetBool("UnlockActive", true);
            for (int i = 0; i < Slots; i++)
            {
                ToolLights[i].GetComponent<Button>().enabled = true;
                ToolLights[i].GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            //this.GetComponent<Animator>().SetBool("UnlockActive", false);
            for (int i = 0; i < Slots; i++)
            {
                ToolLights[i].GetComponent<Button>().interactable = false;
                ToolLights[i].GetComponent<Button>().enabled = false;

            }
        }
        TotalCoins.text = GloableVeribale.Coins.ToString();
        TestUnlock = Unlock;
        if (GloableVeribale.Coins <= 1)
        {
            BUnlock.interactable = false;
        }
        else
        {
            BUnlock.interactable = true;
        }
        if (Trys <= 0 && GloableVeribale.Instance.GameEnd == false && AnimFinshed == true && LastTryWin == false)
        {
            GameOver();
        }


    }
    public void UnlockUesedMessage()
    {
        if (Unlock)
        {
            Unlocked(false);
        }
        else
        {
            Unlocked(true);

        }

    }
    void GameOver()
    {

        GloableVeribale.Instance.GameEnd = true;
        GloableVeribale.PlayOn = false;
        SceneManager.LoadScene("lose", LoadSceneMode.Additive);
        print("you have lost");
    }
    public void TestCombination()
    {

        CorrectGuess = 0;
        Trys -= 1;
        NumerOfTrys.text = Trys.ToString();
        if (GloableVeribale.Instance.TimerCallange)
        {

            TimeChallangeTime = GloableVeribale.Instance.TimeForTimerCallange;
            TimeFormat = string.Format("{00}", (int)TimeChallangeTime % 60);

            TimeChallangeText.text = TimeFormat;
        }
        if (TotalTrys > 0)
        {

            for (int i = TotalTrys; i > 0; i--)
            {


                GussedPanel.GetComponent<GuessedPanelLight>().PanelLights[i].GetComponent<CanvasGroup>().alpha = 1;
                GussedBar = GussedPanel.GetComponent<GuessedPanelLight>().PanelLights[i].gameObject;
                SecondBar = GussedPanel.GetComponent<GuessedPanelLight>().PanelLights[i - 1].gameObject;
                GussedLightsPanel = GussedBar.GetComponent<GuessedPanelLight>().PanelLights[0];
                SecondGussedPanel = SecondBar.GetComponent<GuessedPanelLight>().PanelLights[0];
                GussedLightsCorrect = GussedBar.GetComponent<GuessedPanelLight>().PanelLights[1];
                SecondGussedCorrect = SecondBar.GetComponent<GuessedPanelLight>().PanelLights[1];
                for (int k = 0; k < 5; k++)
                {
                    if (SecondGussedPanel.GetComponent<GuessedPanelLight>().PanelLights[k].activeSelf)
                    {

                        GussedLightsPanel.GetComponent<GuessedPanelLight>().PanelLights[k].SetActive(true);
                        GussedLightsPanel.GetComponent<GuessedPanelLight>().PanelLights[k].GetComponent<Image>().sprite = SecondGussedPanel.GetComponent<GuessedPanelLight>().PanelLights[k].GetComponent<Image>().sprite;
                        GussedLightsCorrect.GetComponent<GuessedPanelLight>().PanelLights[k].SetActive(true);
                        GussedLightsCorrect.GetComponent<GuessedPanelLight>().PanelLights[k].GetComponent<Image>().sprite = SecondGussedCorrect.GetComponent<GuessedPanelLight>().PanelLights[k].GetComponent<Image>().sprite;


                    }
                    else
                    {
                        GussedLightsPanel.GetComponent<GuessedPanelLight>().PanelLights[k].SetActive(false);
                        GussedLightsCorrect.GetComponent<GuessedPanelLight>().PanelLights[k].SetActive(false);
                    }

                }
            }
        }
        GussedPanel.GetComponent<GuessedPanelLight>().PanelLights[0].GetComponent<CanvasGroup>().alpha = 1;
        for (int i = 0; i < 5; i++)
        {
            GussedBar = GussedPanel.GetComponent<GuessedPanelLight>().PanelLights[0].gameObject;
            GussedLightsPanel = GussedBar.GetComponent<GuessedPanelLight>().PanelLights[0];
            GussedLightsCorrect = GussedBar.GetComponent<GuessedPanelLight>().PanelLights[1];
            if (ColourLights[i].gameObject.activeSelf)
            {
                GussedLightsPanel.GetComponent<GuessedPanelLight>().PanelLights[i].SetActive(true);
                GussedLightsCorrect.GetComponent<GuessedPanelLight>().PanelLights[i].SetActive(true);
            }
            else
            {
                GussedLightsPanel.GetComponent<GuessedPanelLight>().PanelLights[i].SetActive(false);
                GussedLightsCorrect.GetComponent<GuessedPanelLight>().PanelLights[i].SetActive(false);
            }
        }

        TotalTrys += 1;



        for (int i = 0; i < Slots; i++)
        {
            GussedLightsPanel.GetComponent<GuessedPanelLight>().PanelLights[i].GetComponent<Image>().sprite = WhitePanelLight;
            GussedLightsCorrect.GetComponent<GuessedPanelLight>().PanelLights[i].GetComponent<Image>().sprite = RedLight;
            GussedLightsPanel.GetComponent<GuessedPanelLight>().PanelLights[i].GetComponent<Image>().sprite = ColourLights[i].GetComponent<Image>().sprite;

            if (ColourLights[i].GetComponent<BlockScript>().BlockNumber == ToolLights[i].GetComponent<HidenColour>().BlockNumber)
            {
                CorrectGuess += 1;

                if (CorrectGuess == Slots)
                {
                    LastTryWin = true;
                    GetComponent<Animator>().SetBool("levelCompleted", true);
                    //WinCondition();
                }
            }
            ColourLights[i].GetComponent<BlockScript>().BlockNumber = 7;
            ColourLights[i].GetComponent<Image>().sprite = WhitePanelLight;
            NewColourChanger.Instance.CurrentSlot = 0;
        }

        for (int i = 0; i < CorrectGuess; i++)
        {
            GussedLightsCorrect.GetComponent<GuessedPanelLight>().PanelLights[i].GetComponent<Image>().sprite = GreenLight;

        }

        if (GloableVeribale.Instance.DesaperingCallange)
        {
            if (TotalTrys > DisaperingNumber)
            {
                for (int i = DisaperingNumber; i < 16; i++)
                {
                    GussedPanel.GetComponent<GuessedPanelLight>().PanelLights[i].GetComponent<CanvasGroup>().alpha = 0;

                }

            }
        }
        if (GloableVeribale.Instance.ColourShift)
        {
            NewColour = ToolLights[Slots - 1].GetComponent<HidenColour>().BlockNumber;
            for (int i = 0; i < Slots; i++)
            {
                OldColour = ToolLights[i].GetComponent<HidenColour>().BlockNumber;
                ToolLights[i].GetComponent<HidenColour>().BlockNumber = NewColour;
                NewColour = OldColour;
            }




        }
        if (GloableVeribale.Instance.ExpandinSlotChallange)
        {
            if (TotalTrys == FirstExpanstion)
            {
                Slots += 1;
                Expand = true;
            }
            if (TotalTrys == secondExpanstion)
            {
                Slots += 1;
                Expand = true;

            }
        }
    }
    void WinCondition()
    {
        if (TotalTrys <= GloableVeribale.Instance.OneStar)
        {
            if (GloableVeribale.Instance.LevelStars < 1)
            {
                SetStar(1);
                Debug.Log("Awared 1 Stars");
            }
        }
        if (TotalTrys <= GloableVeribale.Instance.TwoStar)
        {
            if (GloableVeribale.Instance.LevelStars < 2)
            {
                SetStar(2);
                Debug.Log("Awared 2 Stars");
            }

        }
        if (TotalTrys <= GloableVeribale.Instance.ThreeStar)
        {
            if (GloableVeribale.Instance.LevelStars < 3)
            {
                SetStar(3);
                Debug.Log("Awared 3 Stars");
            }
        }
        if (!PlayerPrefsManager.IsLevelUnlocked(GloableVeribale.PlayLevel))
        {
            PlayerPrefsManager.SetCompletedLevels(GloableVeribale.PlayLevel + 1);
            GloableVeribale.Coins += 3;
            PlayerPrefsManager.UnlockLevel(GloableVeribale.PlayLevel);
        }
        PlayerPrefsManager.SetCoins(GloableVeribale.Coins);
        PlayerPrefs.Save();
        print("Unlocked Safe: " + GloableVeribale.CompletedLevels);
        GloableVeribale.PlayOn = true;
        GloableVeribale.Instance.GameEnd = true;
        SceneManager.LoadScene("End", LoadSceneMode.Additive);
    }
    void SetStar(int StarNumber)
    {
        if (PlayerPrefs.HasKey(PlayerPrefsManager.LevelStar(GloableVeribale.PlayLevel)))
        {
            PlayerPrefsManager.SetLevelStars(GloableVeribale.PlayLevel, StarNumber);
        }
        else
        {
            //  Debug.Log("in setstar and there is no key");
        }
    }
    public static void Unlocked(bool isLocked)
    {
        Unlock = isLocked;
    }
}

