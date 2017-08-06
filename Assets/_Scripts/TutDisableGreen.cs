using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutDisableGreen : MonoBehaviour {
    public GameObject greenButton;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DisableGreen()
    {
        greenButton.gameObject.SetActive(false);
    }
    public void EnableGreen()
    {
        greenButton.gameObject.SetActive(true);
    }
}
