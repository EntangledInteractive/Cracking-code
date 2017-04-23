using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
//using UnityEngine.Advertisements;
public class LevelSelection : MonoBehaviour
{
    //old code
	public int CurrentLevel;
	public int Kpi;
	public Text KpiCount;
	public Image[] PanelLights;
	public Image[] CodeLights;
	public Image[] ButtonColour;
	public Button[] ButtonOn;
	public GameObject[] GussedCorrectColour;
	public int CorrectGuess;
	public Text NumberOfTrys;
	public int AvaliableTrys;
	public Sprite WhitePanelLight;
	public Sprite GreenLight;
	public Sprite RedLight;
	public GameObject GussedPanel;
	public int TotalTrys;
	public GameObject GussedLightsPanel;
	public GameObject GussedLightsCorrect;
	public GameObject GussedBar;
	public GameObject SecondGussedPanel;
	public GameObject SecondGussedCorrect;
	public GameObject SecondBar;
    public GameObject GussedPanelTop;
	public Button CrackHandly;
	public bool GameBegin;
	public GameObject TheCanvas;
	//public Menu GameOverScreen;
	//public Menu GameScreen;
	public Text WinOrLose;
	//Time Challange
	public Text TimeLeft;
	public float TimeChallange;
	private string TimeFormat;
	//Disapering Challange;
	public int DisaperingNumber;
	// slot Expanding Challange;
	public int FirstExpanstion;
	public int secondExpanstion;
	public bool Expand = false;
	// colour shift challange;
	public int NewColour;
	public int OldColour;
	//Hacking tool
	public  bool HackingTool = false;
	//boss anger
	//public DevicesLeft MyDevices;
	// Use this for initialization
	void Start ()
	{
		GameBegin = false;

		if (PlayerPrefs.HasKey ("KPI")) {
			Kpi = PlayerPrefs.GetInt ("KPI");
		} else {
			PlayerPrefs.SetInt ("KPI", 15);
			PlayerPrefs.Save ();
		}

	}
	void Awake ()
	{
		//if (Advertisement.isSupported) {
		//	Advertisement.Initialize ("49766", true);
		//} else {
		//	Debug.Log ("Platform not supported");
		//}
	}

	// Update is called once per frame
	public void RestartGame ()
	{
		//CurrentLevel = LevelArray.Instance.CurrentLevel;
		
		
		for (int i=0; i < GloableVeribale.Instance.NumberOfSlots; i++) {
			PanelLights [i].transform.gameObject.SetActive (true);
			CodeLights [i].transform.gameObject.SetActive (true);

			
		}


	}
	public void GameStart ()
	{
        CurrentLevel = GloableVeribale.PlayLevel;


		for (int i=0; i < GloableVeribale.Instance.NumberOfSlots; i++) {
			PanelLights [i].transform.gameObject.SetActive (true);
			CodeLights [i].transform.gameObject.SetActive (true);
			CodeLights [i].GetComponent<HidenColour> ().PickColour ();

		}
//		GameScreen.GetComponent<NewColourChanger> ().NumberOfSlots = GloableVeribale.Instance.NumberOfSlots;
		NumberOfTrys.text = GloableVeribale.Instance.NumberOfTrys.ToString ();
		AvaliableTrys = GloableVeribale.Instance.NumberOfTrys;


		
		if (GloableVeribale.Instance.TimerCallange) {
			TimeLeft.gameObject.SetActive (true);
			TimeChallange = GloableVeribale.Instance.TimeForTimerCallange;
			TimeFormat = string.Format ("{00}", (int)TimeChallange % 60);

			TimeLeft.text = TimeFormat;
		} else {
			TimeLeft.gameObject.SetActive (false);
		}
		if (GloableVeribale.Instance.DesaperingCallange) {
			DisaperingNumber = GloableVeribale.Instance.DesaperingNumber;
		}
		if (GloableVeribale.Instance.ExpandinSlotChallange) {

			FirstExpanstion = GloableVeribale.Instance.FirstExpandstion;
			secondExpanstion = GloableVeribale.Instance.SecondExpandstion;
		}



    }

	public void HackingTools (bool HT)
	{
		HackingTool = HT;

	}
	public void ShowColour (int CodeLightNumber)
	{
		CodeLights [CodeLightNumber].GetComponent<HidenColour> ().ShowColour = true;
		for (int i=0; i<5; i++) {

			CodeLights [i].GetComponent<Button> ().enabled = false;

		}
		Kpi -= 5;
		HackingTool = false;
	}


	void Update ()
	{
		if (AvaliableTrys <= 0 && GameBegin == true) {
			Debug.Log ("game over");
			CrackHandly.interactable = false;
			WinOrLose.text = "Failed";
//			TheCanvas.GetComponent<MenuManager> ().ShowMenu (GameOverScreen);
			GameBegin = false;
//			MyDevices.GetComponent<DevicesLeft> ().livesLeft -= 1;
//			MyDevices.GetComponent<DevicesLeft> ().lostLife ();
//			MyDevices.GetComponent<DevicesLeft> ().RunOnce = true;

			GameReset ();

		}
		if (GloableVeribale.Instance.TimerCallange) {
			//if (!NewColourChanger.Instance.RunOnce) {
			//	TimeChallange -= Time.deltaTime;
			//	TimeFormat = string.Format ("{00}", (int)TimeChallange % 60);

			//	TimeLeft.text = TimeFormat;

			//}
			if (TimeChallange < 0) {
				CrakingCode ();
			}
		}
		if (GloableVeribale.Instance.ExpandinSlotChallange) {
			if (Expand) {
				if (TotalTrys == FirstExpanstion) {
					Debug.Log ("first expanstion");
					GloableVeribale.Instance.NumberOfSlots += 1;
					PanelLights [3].transform.gameObject.SetActive (true);
					CodeLights [3].transform.gameObject.SetActive (true);
					CodeLights [3].GetComponent<HidenColour> ().PickColour ();

					NewColourChanger.Instance.NumberOfSlots += 1;
					Expand = false;
				}
				if (TotalTrys == secondExpanstion) {
					Debug.Log ("Second expanstion");
					GloableVeribale.Instance.NumberOfSlots += 1;
					PanelLights [4].transform.gameObject.SetActive (true);
					CodeLights [4].transform.gameObject.SetActive (true);
					CodeLights [4].GetComponent<HidenColour> ().PickColour ();

					Expand = false;
					NewColourChanger.Instance.NumberOfSlots += 1;
				}
			}
		}
		KpiCount.text = Kpi.ToString ();
		if (HackingTool) {
			for (int i=0; i<5; i++) {

				CodeLights [i].GetComponent<Button> ().enabled = true;
			}

		} else {
			for (int i=0; i<5; i++) {

				CodeLights [i].GetComponent<Button> ().enabled = false;
			}

		}

	}

	public void CrakingCode ()
	{

		CorrectGuess = 0;
		AvaliableTrys -= 1;
		NumberOfTrys.text = AvaliableTrys.ToString ();
		if (GloableVeribale.Instance.TimerCallange) {
			TimeChallange = GloableVeribale.Instance.TimeForTimerCallange;
			TimeFormat = string.Format ("{00}", (int)TimeChallange % 60);

			TimeLeft.text = TimeFormat;
		}
		if (TotalTrys > 0) {
            for (int i=TotalTrys; i>0; i--) {
               

                GussedPanel.GetComponent<GuessedPanelLight> ().PanelLights [i].GetComponent<CanvasGroup> ().alpha = 1;
				GussedBar = GussedPanel.GetComponent<GuessedPanelLight> ().PanelLights [i].gameObject;
				SecondBar = GussedPanel.GetComponent<GuessedPanelLight> ().PanelLights [i - 1].gameObject;
				GussedLightsPanel = GussedBar.GetComponent<GuessedPanelLight> ().PanelLights [0];
				SecondGussedPanel = SecondBar.GetComponent<GuessedPanelLight> ().PanelLights [0];
				GussedLightsCorrect = GussedBar.GetComponent<GuessedPanelLight> ().PanelLights [1];
				SecondGussedCorrect = SecondBar.GetComponent<GuessedPanelLight> ().PanelLights [1];
				for (int k=0; k<5; k++) {
					if (SecondGussedPanel.GetComponent<GuessedPanelLight> ().PanelLights [k].activeSelf) {

						GussedLightsPanel.GetComponent<GuessedPanelLight> ().PanelLights [k].SetActive (true);
						GussedLightsPanel.GetComponent<GuessedPanelLight> ().PanelLights [k].GetComponent<Image> ().sprite = SecondGussedPanel.GetComponent<GuessedPanelLight> ().PanelLights [k].GetComponent<Image> ().sprite;
						GussedLightsCorrect.GetComponent<GuessedPanelLight> ().PanelLights [k].SetActive (true);
						GussedLightsCorrect.GetComponent<GuessedPanelLight> ().PanelLights [k].GetComponent<Image> ().sprite = SecondGussedCorrect.GetComponent<GuessedPanelLight> ().PanelLights [k].GetComponent<Image> ().sprite;


					} else {
						GussedLightsPanel.GetComponent<GuessedPanelLight> ().PanelLights [k].SetActive (false);
						GussedLightsCorrect.GetComponent<GuessedPanelLight> ().PanelLights [k].SetActive (false);
					}

				}
			}


		}

		GussedPanel.GetComponent<GuessedPanelLight> ().PanelLights [0].GetComponent<CanvasGroup> ().alpha = 1;
		for (int i =0; i<5; i++) {
			GussedBar = GussedPanel.GetComponent<GuessedPanelLight> ().PanelLights [0].gameObject;
			GussedLightsPanel = GussedBar.GetComponent<GuessedPanelLight> ().PanelLights [0];
			GussedLightsCorrect = GussedBar.GetComponent<GuessedPanelLight> ().PanelLights [1];
			if (PanelLights [i].IsActive ()) {
				GussedLightsPanel.GetComponent<GuessedPanelLight> ().PanelLights [i].SetActive (true);
				GussedLightsCorrect.GetComponent<GuessedPanelLight> ().PanelLights [i].SetActive (true);
			} else {
				GussedLightsPanel.GetComponent<GuessedPanelLight> ().PanelLights [i].SetActive (false);
				GussedLightsCorrect.GetComponent<GuessedPanelLight> ().PanelLights [i].SetActive (false);
			}
		}

		TotalTrys += 1;
        GussedPanelTop.gameObject.transform.position = GussedPanel.GetComponent<GuessedPanelLight>().PanelLights[TotalTrys].transform.position;

        if (GloableVeribale.Instance.ExpandinSlotChallange) {

			if (TotalTrys >= FirstExpanstion + 1) {
				GussedLightsPanel.GetComponent<GuessedPanelLight> ().PanelLights [3].SetActive (true);
				GussedLightsCorrect.GetComponent<GuessedPanelLight> ().PanelLights [3].SetActive (true);

			}
			if (TotalTrys >= secondExpanstion + 1) {
				GussedLightsPanel.GetComponent<GuessedPanelLight> ().PanelLights [4].SetActive (true);
				GussedLightsCorrect.GetComponent<GuessedPanelLight> ().PanelLights [4].SetActive (true);
			}

		}



		for (int i= 0; i <GloableVeribale.Instance.NumberOfSlots; i++) {
			GussedLightsPanel.GetComponent<GuessedPanelLight> ().PanelLights [i].GetComponent<Image> ().sprite = WhitePanelLight;
			GussedLightsCorrect.GetComponent<GuessedPanelLight> ().PanelLights [i].GetComponent<Image> ().sprite = RedLight;
			GussedLightsPanel.GetComponent<GuessedPanelLight> ().PanelLights [i].GetComponent<Image> ().sprite = PanelLights [i].GetComponent<Image> ().sprite;
			if (PanelLights [i].GetComponent<BlockScript> ().BlockNumber == CodeLights [i].GetComponent<HidenColour> ().BlockNumber) {

				CorrectGuess += 1;


			}
			if (CorrectGuess == GloableVeribale.Instance.NumberOfSlots) {
				Debug.Log ("YOU WIN");
				CrackHandly.interactable = false;
				GameWin ();
				//TheCanvas.GetComponent<MenuManager> ().ShowMenu (GameOverScreen);
				GameBegin = false;


			}
			PanelLights [i].GetComponent<BlockScript> ().BlockNumber = 7;
			PanelLights [i].sprite = WhitePanelLight;
			NewColourChanger.Instance.CurrentSlot = 0;

		}


		Debug.Log ("total right is " + CorrectGuess.ToString ());
		for (int i=0; i <CorrectGuess; i++) {
			GussedLightsCorrect.GetComponent<GuessedPanelLight> ().PanelLights [i].GetComponent<Image> ().sprite = GreenLight;

		}
		if (GloableVeribale.Instance.DesaperingCallange) {
			if (TotalTrys > DisaperingNumber) {
				for (int i =DisaperingNumber; i<16; i++) {
					GussedPanel.GetComponent<GuessedPanelLight> ().PanelLights [i].GetComponent<CanvasGroup> ().alpha = 0;

				}

			}
		}
		if (GloableVeribale.Instance.ColourShift) {
			NewColour = CodeLights [GloableVeribale.Instance.NumberOfSlots - 1].GetComponent<HidenColour> ().BlockNumber;
			for (int i=0; i<GloableVeribale.Instance.NumberOfSlots; i++) {
				OldColour = CodeLights [i].GetComponent<HidenColour> ().BlockNumber;
				CodeLights [i].GetComponent<HidenColour> ().BlockNumber = NewColour;
				NewColour = OldColour;
			}




		}
		if (GloableVeribale.Instance.ExpandinSlotChallange) {
			if (TotalTrys == FirstExpanstion) {
				Expand = true;
			}
			if (TotalTrys == secondExpanstion) {
				Expand = true;

			}
		}
		GameBegin = true;
	}

	public void GameReset ()
	{

		CrackHandly.interactable = true;
		NumberOfTrys.text = GloableVeribale.Instance.NumberOfTrys.ToString ();
		AvaliableTrys = GloableVeribale.Instance.NumberOfTrys;
		TotalTrys = 0;
		for (int i =0; i <16; i++) {
			GussedPanel.GetComponent<GuessedPanelLight> ().PanelLights [i].GetComponent<CanvasGroup> ().alpha = 0;
			GussedLightsPanel = GussedBar.GetComponent<GuessedPanelLight> ().PanelLights [0];
			GussedLightsCorrect = GussedBar.GetComponent<GuessedPanelLight> ().PanelLights [1];
			for (int j =0; j<5; j++) {
				GussedLightsPanel.GetComponent<GuessedPanelLight> ().PanelLights [j].SetActive (true);
				GussedLightsPanel.GetComponent<GuessedPanelLight> ().PanelLights [j].GetComponent<Image> ().sprite = WhitePanelLight;
				GussedLightsCorrect.GetComponent<GuessedPanelLight> ().PanelLights [j].SetActive (true);
				GussedLightsCorrect.GetComponent<GuessedPanelLight> ().PanelLights [j].GetComponent<Image> ().sprite = RedLight;

			}
		}
		for (int i=0; i < GloableVeribale.Instance.NumberOfSlots; i++) {
			PanelLights [i].transform.gameObject.SetActive (false);
			CodeLights [i].transform.gameObject.SetActive (false);
		}
		if (GloableVeribale.Instance.ExpandinSlotChallange) {
			GloableVeribale.Instance.NumberOfSlots = 3;
		}
        GussedPanelTop.gameObject.transform.position = GussedPanel.GetComponent<GuessedPanelLight>().PanelLights[0].transform.position;
    }

	void GameWin ()
	{
		WinOrLose.text = "Completed";
		if (TotalTrys <= GloableVeribale.Instance.ThreeStar) {
			GloableVeribale.Instance.LevelStars = 3;
			Debug.Log ("Awared Three Stars");
			SetStar (3);
		}
		if (TotalTrys <= GloableVeribale.Instance.TwoStar) {
			if (GloableVeribale.Instance.LevelStars < 3) {
				GloableVeribale.Instance.LevelStars = 2;
				Debug.Log ("Awared Two Stars");
				SetStar (2);
			}
		}
		if (TotalTrys <= GloableVeribale.Instance.OneStar) {
			if (GloableVeribale.Instance.LevelStars < 2) {
				GloableVeribale.Instance.LevelStars = 1;
				Debug.Log ("Awared One Stars");
				SetStar (1);
			}
		}

		if (!GloableVeribale.Instance.HasLevelBeenCompleted) {
			GloableVeribale.CompletedLevels += 1;
			PlayerPrefs.SetInt ("MaxPlayerLevel", CurrentLevel);
			//if (LevelArray.Instance.MaxPlayerLevel <= LevelArray.Instance.Level.Length) {
			//	LevelArray.Instance.CurrentLevel += 1;
			//}
			GloableVeribale.Instance.HasLevelBeenCompleted = true;
		}
		Kpi += 3;
		GameBegin = false;
		GameReset ();

	}
	void SetStar (int StarNumber)
	{
		if (PlayerPrefs.HasKey ("Level" + CurrentLevel + "NewStar")) {
			PlayerPrefs.SetInt ("Level" + CurrentLevel + "NewStar", StarNumber);
			PlayerPrefs.Save ();
			Debug.Log ("Saved " + StarNumber + " Stars for " + CurrentLevel);

		}

	}
	////public void PlayAdd ()
	////{
	////	GloableVeribale.Instance.AdCount += 1;
	////	if (GloableVeribale.Instance.AdCount == 3) {
			
	////		if (Advertisement.IsReady ()) {
	////			Advertisement.Show ();
	////		}
	////		GloableVeribale.Instance.AdCount = 0;
	////	}
	////}


}

