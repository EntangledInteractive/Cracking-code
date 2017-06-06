using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class backround : MonoBehaviour {
    public LevelManager myLevelManager;
    private Animator anim;
    // Use this for initialization
    void Start() {
        if (GetComponent<Animator>())
        {
            anim = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update() {
        //Scene myScene = SceneManager.GetActiveScene();
        //if (myScene.name == "Start" && anim.GetBool("Expand"))
        //{
        //    Debug.Log("checking if unload from level selection");

        //}
       
            }

    //private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    //{
    //    print("arg0 " + arg0.name);
    //    print("arg1 " + arg1.name);
    //    if (arg0.name == "Start" || arg1.name == "Start")
    //    {
    //        print("check name");
    //        anim.SetBool("Expand", false);
    //    }
    //}

    //private void CheckingUnloadLevel(Scene arg0)
    //{
    //    if (arg0.name == "Start" )
    //    {
    //        anim.SetBool("Expand", false);
    //    }
    //    else
    //    {
    //        Debug.Log("Do nothing");
    //    }

    //}

    public void callAddtiveScene(string name)
    {
        //SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
        myLevelManager.AdditiveScene(name);
    }
    //public void CheckingUnloadLevel(Scene firstLevel, Scene secondLevel)
    //{

    //}
}
