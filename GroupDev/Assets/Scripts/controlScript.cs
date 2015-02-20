using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class controlScript: MonoBehaviour {
	
	public string destination = "";
	bool click = false;
	bool inside = false;
	public bool pc2 = false;
	Color color = Color.red;

	//public GameObject textToEdit;
	public Text text;

	public void enter()
	{
		//renderer.material.color = Color.white;
		inside = true;
	}
	public void leave()
	{
		//renderer.material.color = color;
		inside = false;
	}
	public void clicked()
	{
		//renderer.material.color = color;
		if (inside)
		{
			switch(destination)
			{
				case "movement":
					break;
				case "punch":
					break;
				case "kick":
					break;
				case "jump":
					break;
			}
		}
		/*if (inside)
		{
			if (isQuit)
				Application.Quit();
			else if (isControl)
				Application.LoadLevel(3);
			else
				Application.LoadLevel(1);
		}*/
	}
	void Update()
	{
		if (inside && Input.GetMouseButtonDown(0))
		{
			click = true;
		}
		if (click && Input.anyKey)
		{
			/*Text[] tempText = GetComponentsInChildren<Text>();
			foreach(Text subText in tempText)
			{
				text = subText;
				break;
			}*/


			//text = GetComponent<Text>();
			//if (Input.inputString != "")
			//{
			char input = Input.inputString[0];
			string inputAS = input.ToString();
			switch(destination)
			{
			case "movement":
				break;
                case "punch":
                    if (pc2)
                        PlayerPrefs.SetString("punchP2",inputAS);
                    else
                        PlayerPrefs.SetString("punch",inputAS);
    				if (inputAS != " ")
    					text.text = inputAS.ToUpper();
    				else
    					text.text = "Space";
				break;
			case "kick":
                    if (pc2)
                        PlayerPrefs.SetString("kickP2",inputAS);
                    else
    				    PlayerPrefs.SetString("kick",inputAS);
    				if (inputAS != " ")
    					text.text = inputAS.ToUpper();
    				else
    					text.text = "Space";
				break;
			case "jump":
                    if (pc2)
                        PlayerPrefs.SetString("jumpP2",inputAS);
                    else
                        PlayerPrefs.SetString("jump",inputAS);
    				if (inputAS != " ")
    					text.text = inputAS.ToUpper();
    				else
    					text.text = "Space";
				break;
            }
			//}
			click = false;
        }
		//click = false;
		/*if (Input.GetMouseButtonDown(0))
		{
			click = true;
		}*/
	}
}
