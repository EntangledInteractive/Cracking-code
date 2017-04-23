using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuessedPanelLight : MonoBehaviour {
	public static GuessedPanelLight Instance;
	public GameObject[] PanelLights;

	void Start ()
	{
		Instance = this;
	}
}
