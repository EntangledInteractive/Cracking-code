using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour {
  
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void DeletePP()
    {
        PlayerPrefs.DeleteAll();
    }
    public void AdditiveScene(string name)
    {
        
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
        

    }

   

    public void SceneUnload(string Name)
    {
       
        SceneManager.UnloadSceneAsync(Name);
    }
    public void SetActiceScene(string name)
    {
        Scene myScene = SceneManager.GetSceneByName(name);
        SceneManager.SetActiveScene(myScene);
        
    }
    

}
