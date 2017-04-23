using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewColourChanger : MonoBehaviour
{
	public static NewColourChanger Instance;
	public Sprite[] Colour;
	public Image[] PanelLights;
	public int CurrentSlot;
	public int NumberOfSlots;
	public bool RunOnce = true;
	public Sprite SelectedPanel;
    

	// Use this for initialization
	void Start ()
	{
		Instance = this;
        
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (CurrentSlot < GloableVeribale.Instance.NumberOfSlots) {
			PanelLights [CurrentSlot].sprite = SelectedPanel;
		}
	}

	public void PanelLightChanger (int ColourNumber)
	{
        if (RunOnce)
        {
            RunOnce = false;
        }
		PanelLights [CurrentSlot].GetComponent<BlockScript> ().BlockNumber = ColourNumber;
		switch (ColourNumber) {
		case 0:
			PanelLights [CurrentSlot].sprite = Colour [0];
			break;
		case 1:
			PanelLights [CurrentSlot].sprite = Colour [1];
			break;
		case 2:
			PanelLights [CurrentSlot].sprite = Colour [2];
			break;
		case 3:
			PanelLights [CurrentSlot].sprite = Colour [3];
			break;
		case 4:
			PanelLights [CurrentSlot].sprite = Colour [4];
			break;
		case 5:
			PanelLights [CurrentSlot].sprite = Colour [5];
			break;
		case 6:
			PanelLights [CurrentSlot].sprite = Colour [6];
			break;
		case 7:
			PanelLights [CurrentSlot].sprite = Colour [7];
			break;
		default:
			PanelLights [CurrentSlot].sprite = Colour [8];
			break;
		}

	}

	public void SlotIncress ()
	{

		CurrentSlot += 1;
		if (CurrentSlot >= GloableVeribale.Instance.NumberOfSlots) {
			
			CurrentSlot = GloableVeribale.Instance.NumberOfSlots;
		}
	}

	public void SlotDecress ()
	{
				
		CurrentSlot -= 1;
		if (CurrentSlot < 0) {
			CurrentSlot = 0;		
		}
				
	}

	
}
