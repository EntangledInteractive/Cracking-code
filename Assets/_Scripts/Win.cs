using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using HardCodeLab.TutorialMaster;
using UnityEngine.SceneManagement;


public class Win : MonoBehaviour {
    public Image[] Stars;
    public Sprite GoldStar;
    public Text Title;
    public GameObject TutUIBacround;
    public GameObject SkipTut;
    // Use this for initialization
    void Start () {
        Title.text = "Safe " + GloableVeribale.Instance.LevelNumber.ToString()+" Unlocked";
        int NumberStar = PlayerPrefsManager.GetLevelStars(GloableVeribale.Instance.LevelNumber);
        for (int i = 0; i < NumberStar; i++)
        {
            Stars[i].sprite = GoldStar;
        }
        if (GloableVeribale.TutorialEnabled)
        {
            SetTutorialPanel();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void SetTutorialPanel()
    {
        //StartTut.gameObject.SetActive(true);
        TutUIBacround.SetActive(true);
        SkipTut.gameObject.SetActive(true);
        tutorial.Start(1);
        print("Tut is runing " + SceneManager.GetActiveScene().name);

    }
}
