using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
   // public AudioClip[] levelMusicChangerArray;
    private AudioSource audioScource;
    private float MusicVolume;
    private int SfxVolume;
    public bool musictest;
    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioScource = GetComponent<AudioSource>();
    }

    void Start () {
        
        if (PlayerPrefs.HasKey(PlayerPrefsManager.MasterVolumeString()))
        {
            MusicVolume = PlayerPrefsManager.GetMasterVolume();
        }
        else
        {
            PlayerPrefsManager.SetMasterVolume(1);
            PlayerPrefs.Save();
            MusicVolume = PlayerPrefsManager.GetMasterVolume();
        }
        if (PlayerPrefs.HasKey(PlayerPrefsManager.SFXSting()))
        {
            SfxVolume = PlayerPrefsManager.GetSFXOnOFf();
        }else
        {
            PlayerPrefsManager.SetSFXOnOff(1);
            PlayerPrefs.Save();
            SfxVolume= PlayerPrefsManager.GetSFXOnOFf();

        }
        MusicControl();
    }
    public void MusicControl()
    {

        if (MusicVolume > 0)
        {
            MusicOnOff(true);
        }
        else
        {
            MusicOnOff(false);
        }
        if(SfxVolume > 0)
        {
            SfxOnOff(true);
        }else
        {
            SfxOnOff(false);
        }
    }
    public void MusicOnOff(bool OnOff)
    {
        audioScource = GetComponent<AudioSource>();
    
        musictest = OnOff;
        if (OnOff)
        {
           // print("music on gv");
            PlayerPrefsManager.SetMasterVolume(1);
            PlayerPrefs.Save();
        
            audioScource.volume = PlayerPrefsManager.GetMasterVolume();
            audioScource.enabled = true;
            audioScource.Play();
        }
        else
        {
            //print("music off gv");
            PlayerPrefsManager.SetMasterVolume(0);
            PlayerPrefs.Save();
            MusicVolume = PlayerPrefsManager.GetMasterVolume();
            audioScource.volume = MusicVolume;
            audioScource.Stop();
            audioScource.enabled = false;
        }
    }
    public void SfxOnOff(bool sfx)
    {
        if (sfx)
        {
            GloableVeribale.SfxOn = true;
            PlayerPrefsManager.SetSFXOnOff(1);
            PlayerPrefs.Save();
        }
        else
        {
            GloableVeribale.SfxOn = false;
            PlayerPrefsManager.SetSFXOnOff(0);
            PlayerPrefs.Save();
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
    //void OnLevelWasLoaded(int level)
    //{
    //    AudioClip thisLevelMusic = levelMusicChangerArray[level];
    //    Debug.Log("Playing clip: " + thisLevelMusic);
    //    if (thisLevelMusic)//if there is music in the array
    //    {
    //        audioScource.clip = thisLevelMusic;
    //        audioScource.loop = true;
    //        audioScource.Play();
    //    }
    //}
    public void ChangeVolume(float Volume)
    {

        audioScource.volume = Volume;
    }
}
