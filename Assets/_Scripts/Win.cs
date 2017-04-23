using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Win : MonoBehaviour {
    public Image[] Stars;
    public Sprite GoldStar;
    public Text Title;
	// Use this for initialization
	void Start () {
        Title.text = "Safe " + GloableVeribale.Instance.LevelNumber.ToString()+" Unlocked";
        int NumberStar = PlayerPrefsManager.GetLevelStars(GloableVeribale.Instance.LevelNumber);
        for (int i = 0; i < NumberStar; i++)
        {
            Stars[i].sprite = GoldStar;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
