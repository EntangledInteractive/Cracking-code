using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using UnityEngine.Advertisements;
public class LevelGetter : MonoBehaviour
{

    //	public int StarLevel;
    //	public Text MyLevel;
    //	public GameObject CurrentLevel;
    public Text NumberOfColour;
    private LevelSettings MyLevel;
    //private GloableVeribale LevelInfo;
    public Text NumberOfTrys;
    public Text NumberOfSlots;
    public Image TimeChallange;
    public Image DisaperingChallange;
    public Image ExpandingChallange;
    public Image ColourShiftChallange;   
   	public Image[] Stars;
   	public Sprite goldstar;
   	public Sprite shadowStar;
    
    //	public DevicesLeft MyDevice;
    //  public bool Playing;
    void Awake()
    {
        LevelUpDate();
       
    }

    void Start()
    {
        LevelUpDate();

    }

    //	// Update is called once per frame
    void Update()
    {
        for (int i = 0; i < MyLevel.LevelStars; i++)
        {
            Stars[i].sprite = goldstar;
        }

        //		if (MyDevice.GetComponent<DevicesLeft> ().livesLeft > 0) {		
        //			if (CurrentLevel <= LevelArray.Instance.MaxPlayerLevel) {
        //				StartButton.interactable = true;
        //				//Debug.Log ("Player Level is " + PlayerPrefs.GetInt ("CurrentPLayerLevel").ToString ());
        //			} else {
        //				StartButton.interactable = false;
        //			}


        //		} else {
        //			StartButton.interactable = false;


        //		}
    }

    public void LevelUpDate()
    {
        if (GameObject.Find("Level " + GloableVeribale.PlayLevel))
        {
            MyLevel = GameObject.Find("Level " + GloableVeribale.PlayLevel).GetComponent<LevelSettings>();
          
            
            MyLevel.LevelStars = PlayerPrefsManager.GetLevelStars(MyLevel.LevelNumber);
            // this load the information for the level ever time theplayer move up or down a level
            NumberOfSlots.text = MyLevel.NumberOfSlots.ToString();
            GloableVeribale.Instance.NumberOfSlots = MyLevel.NumberOfSlots;
            NumberOfTrys.text = MyLevel.NumberOfTrys.ToString();
            GloableVeribale.Instance.NumberOfTrys = MyLevel.NumberOfTrys;
            GloableVeribale.Instance.BlueBlock = MyLevel.BlueBlock;
            GloableVeribale.Instance.RedBlock = MyLevel.RedBlock;
            GloableVeribale.Instance.GreenBlock = MyLevel.GreenBlock;
            GloableVeribale.Instance.YellowBlock = MyLevel.YellowBlock;
            GloableVeribale.Instance.PurpleBlock = MyLevel.PurpleBlock;
            GloableVeribale.Instance.OrangeBlock = MyLevel.OrangeBlock;
            GloableVeribale.Instance.LevelNumber = MyLevel.LevelNumber;
            GloableVeribale.Instance.GameEnd = false;
            if (MyLevel.TimerCallange)
            {
                TimeChallange.color = new Vector4(1, 1, 1, 1);
                GloableVeribale.Instance.TimerCallange = true;
                GloableVeribale.Instance.TimeForTimerCallange = MyLevel.TimeForTimerCallange;
            }
            else {
                TimeChallange.color = new Vector4(.1f, .1f, .1f, .1f);
                GloableVeribale.Instance.TimerCallange = false;
            }
            if (MyLevel.DesaperingCallange){
                DisaperingChallange.color = new Vector4(1, 1, 1, 1);
                GloableVeribale.Instance.DesaperingCallange = true;
                GloableVeribale.Instance.DesaperingNumber = MyLevel.DesaperingNumber;
            }
            else {
                DisaperingChallange.color = new Vector4(.1f, .1f, .1f, .1f);
                GloableVeribale.Instance.DesaperingCallange = false;

            }
            if (MyLevel.ExpandinSlotChallange)
            {
                ExpandingChallange.color = new Vector4(1, 1, 1, 1);
                GloableVeribale.Instance.ExpandinSlotChallange = true;
                GloableVeribale.Instance.FirstExpandstion = MyLevel.FirstExpandstion;
                GloableVeribale.Instance.SecondExpandstion = MyLevel.SecondExpandstion;

            }
            else {
                ExpandingChallange.color = new Vector4(.1f, .1f, .1f, .1f);
                GloableVeribale.Instance.ExpandinSlotChallange = false;
            }
            if (MyLevel.ColourShift)
            {
                ColourShiftChallange.color = new Vector4(1, 1, 1, 1);
                GloableVeribale.Instance.ColourShift = true;

            }
            else {
                ColourShiftChallange.color = new Vector4(.1f, .1f, .1f, .1f);
                GloableVeribale.Instance.ColourShift = false;
            }
            for(int i =0; i <Stars.Length; i++)
            {
                Stars[i].sprite = shadowStar;
            }
            for(int i = 0; i < MyLevel.LevelStars; i++)
            {
                Stars[i].sprite = goldstar;
            }
            GloableVeribale.Instance.LevelStars = MyLevel.LevelStars;
            GloableVeribale.Instance.OneStar = MyLevel.OneStar;
            GloableVeribale.Instance.TwoStar = MyLevel.TwoStar;
            GloableVeribale.Instance.ThreeStar = MyLevel.ThreeStar;
            GloableVeribale.Instance.HasLevelBeenCompleted = MyLevel.HasLevelBeenCompleted;
        }
        else
        {
            
            print("No level found");
        }

    }
    //    public void PlayAnimation()
    //    {
    //        Debug.Log("i am playing");
    //        GetComponent<Animator>().SetBool("PageUp", Playing);

    //    }
}






