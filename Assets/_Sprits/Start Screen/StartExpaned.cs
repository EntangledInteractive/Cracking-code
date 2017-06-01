using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartExpaned : MonoBehaviour {
    public Animator anim;
    public AnimationClip startExp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PlayExpand()
    {
        anim.SetBool("Expand", true);
        
    }
}
