using UnityEngine;
using System.Collections;
using HardCodeLab.TutorialMaster;
using UnityEngine.SceneManagement;
public class TutorialCaller : MonoBehaviour
{
   // public GameObject StartTut;
    public GameObject TutUIBacround;
    public GameObject SkipTut;
    public void StartTutorial()
    {
        tutorial.Start(0);
    }
    public void SetTutorialPanel()
    {
        //StartTut.gameObject.SetActive(true);
        TutUIBacround.SetActive(true);
        SkipTut.gameObject.SetActive(true);
        tutorial.Start(0);
        print("Tut is runing " + SceneManager.GetActiveScene().name);

    }
}