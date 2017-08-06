using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutDisableBlue : MonoBehaviour {
    public GameObject blueButton;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void DisableBlue()
    {
        blueButton.gameObject.SetActive(false);
    }
    public void EnableBlue()
    {
        blueButton.gameObject.SetActive(true);
    }
}
