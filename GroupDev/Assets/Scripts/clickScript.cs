using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
[SerializeField]
public class clickScript : MonoBehaviour {
	RaycastHit hit;
	
	[SerializeField]
	public GameObject text3D;

	// Use this for initialization
	void Start () {
	
	}


	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0) )
		{
			/*if ( UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() )
			{
				//Debug.Log("just a button click, no need to invoke onFingerUp events");
                return;
            }*/

			RaycastHit hit = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			if(Physics.Raycast(ray, out hit))
				print(hit.collider.transform.gameObject.name);
        }
    }
}
