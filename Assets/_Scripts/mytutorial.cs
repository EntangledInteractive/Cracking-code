using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class mytutorial : MonoBehaviour {
    public Image[] tutImage;
    public int tutNumber = 0;
    private LevelControla levCont;
    public int tutlengeth;
   
    // Use this for initialization
    void Start () {
        tutImage[tutNumber].gameObject.SetActive(true);
        levCont = FindObjectOfType<LevelControla>();
       tutlengeth = tutImage.Length;
    }
	
	// Update is called once per frame
	void Update () {
        //tutorial
    }
    public void MyTutorial()
    {
        tutImage[tutNumber].gameObject.SetActive(false);
        tutNumber += 1;

        if (tutNumber >= tutlengeth)
        {
            Debug.Log("check tutorial");
            GloableVeribale.TutorialEnabled = false;
            //levCont.SetTutorialPanel();
            PlayerPrefsManager.SetTutorialOnOff(0);
            PlayerPrefs.Save();
        }else 
        {
            Debug.Log("Next tutorial");
            
            tutImage[tutNumber].gameObject.SetActive(true);
        }
    }
    
}
