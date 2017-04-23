using UnityEngine;
using System.Collections;

public class TotalNumberOfLevels : MonoBehaviour {
    public int totalNumberOfLevels;
    // Use this for initialization
    void Awake()
    {
        foreach(Transform child in transform)
                {
            totalNumberOfLevels += 1;
        }
        GloableVeribale.NumberOfLevels = totalNumberOfLevels;
    }
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
