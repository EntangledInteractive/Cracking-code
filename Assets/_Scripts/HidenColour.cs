using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HidenColour : MonoBehaviour
{
    //public Sprite[] BlockColour;
    public static HidenColour instance;
	private int RandomColour;
	public int BlockNumber;
	//public GameController TempScript;
	public bool ShowColour = false;
	public Sprite blank;
	//public int CurrentLevel;
	// Use this for initialization
	void Start ()
	{
        instance = this;
        PickColour();

    }
	// Update is called once per frame
	void Update ()
	{
		
	}
    public void ColourShow()
    {
        ShowColour = true;
        if (ShowColour)
        {
            this.gameObject.GetComponent<Image>().sprite = NewColourChanger.Instance.Colour[BlockNumber];
            GloableVeribale.Coins -= 3;
        }
        GameStart.Unlocked(false);
    }
	public void PickColour ()
	{
        
		ShowColour = false;
		BlockNumber = 6;
        //CurrentLevel = GloableVeribale.PlayLevel;
		while (BlockNumber == 6) {
			RandomColour = Random.Range (0, 6);
		
			switch (RandomColour) {
			case 0:
				if (GloableVeribale.Instance.BlueBlock) {
					this.gameObject.GetComponent<Image> ().sprite = NewColourChanger.Instance.Colour[RandomColour];
					BlockNumber = RandomColour;
				
				}
				break;
			case 1:
				if (GloableVeribale.Instance.GreenBlock) {
					this.gameObject.GetComponent<Image> ().sprite = NewColourChanger.Instance.Colour[RandomColour];
					BlockNumber = RandomColour;
				
				}
				break;
			case 2:
				if (GloableVeribale.Instance.OrangeBlock) {
					this.gameObject.GetComponent<Image> ().sprite = NewColourChanger.Instance.Colour[RandomColour];
					BlockNumber = RandomColour;
				
				}
				break;
			case 3:
				if (GloableVeribale.Instance.PurpleBlock) {
					this.gameObject.GetComponent<Image> ().sprite = NewColourChanger.Instance.Colour[RandomColour];
					BlockNumber = RandomColour;
				
				}
				break;
			case 4:
				if (GloableVeribale.Instance.YellowBlock) {
					this.gameObject.GetComponent<Image> ().sprite = NewColourChanger.Instance.Colour[RandomColour];
					BlockNumber = RandomColour;
				
				}
				break;
			case 5:
				if (GloableVeribale.Instance.RedBlock) {
					this.gameObject.GetComponent<Image> ().sprite = NewColourChanger.Instance.Colour[RandomColour];
					BlockNumber = RandomColour;
				
				}
				break;	
			}
			if (!ShowColour) {
				this.gameObject.GetComponent<Image> ().sprite = blank;
			}
		}




	}
}

