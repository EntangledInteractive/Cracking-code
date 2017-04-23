using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsControlle : MonoBehaviour {
    public Toggle MusicOnOff;
    public Toggle SfxOnOff;
    public Toggle TutorialOnOff;
    public MusicManager GameMusic;
	// Use this for initialization
	void Start () {
        print("options window open");
        GameMusic = GameObject.FindObjectOfType<MusicManager>();
        if (PlayerPrefsManager.GetMasterVolume() > 0)
        {
            print("music was on");
            MusicOnOff.isOn = true;
        }
        else
        {
            print("music was off");
            MusicOnOff.isOn = false;
        }
        if(GloableVeribale.SfxOn)
        {
            SfxOnOff.isOn = true;
        }
        else
        {
            SfxOnOff.isOn = false;
        }
        if (GloableVeribale.TutorialEnabled)
        {
            TutorialOnOff.isOn = true;
        }else
        {
            TutorialOnOff.isOn = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        //if(MusicOnOff.isOn == true)
        //{ 
        //    GloableVeribale.Instance.MusicControl();
        //}
        //else if(MusicOnOff.isOn == false)
        //{
            
        //    GloableVeribale.Instance.MusicControl();
        //}

    }
    public void SetMusic(bool OnOff)
    {
        GameMusic.MusicOnOff(OnOff);
    }
    public void SetSfx(bool SfxOnOff)
    {
        GameMusic.SfxOnOff(SfxOnOff);
    }
    public void SetTutorialOnOff()
    {
        if (TutorialOnOff.isOn)
        {
            GloableVeribale.TutorialEnabled = true;
        }
        else
        {
            GloableVeribale.TutorialEnabled = false;
        }
    }
}
