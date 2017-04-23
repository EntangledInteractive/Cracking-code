using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {
    private AudioSource ButtonClick;
    // Use this for initialization
    void Start () {
        ButtonClick = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ButtonSound()
    {
        if (GloableVeribale.SfxOn)
        {
            ButtonClick.Play();
        }
    }
}
