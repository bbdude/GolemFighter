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

	public  string sendThroughParse(char key)
	{
		string returnVal = "";
		string hold = key.ToString().ToUpper();
		switch(key)
		{
		case 'a': case 'A': case 'b': case 'B': case 'c': case 'C': case 'd': case 'D': case 'e': case 'E': case 'f': case 'F': case 'g': case 'G': case 'h': case 'H': case 'i': case 'I': case 'j': case 'J': case 'k': case 'K': case 'l': case 'L': case 'm': case 'M': case 'n': case 'N': case 'o': case 'O': case 'p': case 'P': case 'q': case 'Q': case 'r': case 'R': case 's': case 'S': case 't': case 'T': case 'u': case 'U': case 'v': case 'V': case 'w': case 'W': case 'x': case 'X': case 'y': case 'Y': case 'z': case 'Z':
				returnVal = hold;
			break;
		case '0':case '1':case '2':	case '3':case '4':case '5':	case '6':case '7':case '8':	case '9':
			returnVal = "Keypad" + key.ToString();
			break;
		case '.':
			returnVal = "Period";
			break;
		case ' ':
			returnVal = "Space";
				break;
		case '/':
			returnVal = "Slash";
			break;
		case '*':
			returnVal = "Asterisk";
			break;
		case '-':
			returnVal = "Minus";
			break;
		case '+':
			returnVal = "Plus";
			break;
		case '=':
			returnVal = "Equals";
			break;
		case ';':
			returnVal = "SemiColin";
			break;
		case '\'':
			returnVal = "Quote";
			break;
		case ',':
			returnVal = "Comma";
			break;
		case '[':
			returnVal = "LeftBracket";
			break;
		case ']':
			returnVal = "RightBracket";
			break;
		case '\\':
			returnVal = "BackSlash";
			break;
		}
		return returnVal;
	}

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
			string inputAS = sendThroughParse(input);

			switch(destination)
			{
			case "movement":
				break;
                case "punch":
                    if (pc2)
                        PlayerPrefs.SetString("punchP2",inputAS);
                    else
                        PlayerPrefs.SetString("punch",inputAS);
    				//if (inputAS != " ")
    					text.text = inputAS;
				break;
			case "kick":
                    if (pc2)
                        PlayerPrefs.SetString("kickP2",inputAS);
                    else
    				    PlayerPrefs.SetString("kick",inputAS);
    				//if (inputAS != " ")
    					text.text = inputAS;
				break;
			case "jump":
                    if (pc2)
                        PlayerPrefs.SetString("jumpP2",inputAS);
                    else
                        PlayerPrefs.SetString("jump",inputAS);
    				//if (inputAS != " ")
    					text.text = inputAS;
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
