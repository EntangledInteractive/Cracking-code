using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using UnityEngine.Advertisements;
public class LevelArray : MonoBehaviour
{
	
	public static GameObject[] Level;
	public int CurrentLevel;
	public int MaxPlayerLevel;

	


	void OnApplicationQuit ()
	{
		PlayerPrefs.SetInt ("MaxPlayerLevel", CurrentLevel);
		PlayerPrefs.Save ();
	}
	


}
