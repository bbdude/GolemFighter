using UnityEngine;
using System.Collections;

public class BounceScript : MonoBehaviour {

	// Use this for initialization
	float power = 1000.0f;
	void OnTriggerEnter(Collider other) {
		if ((other.collider.tag == "Player1") || (other.collider.tag == "Player2"))
		{
			Rigidbody[] tempRigid;
			Rigidbody rigid = new Rigidbody();
			tempRigid = other.transform.GetComponentsInParent<Rigidbody>();
			foreach(Rigidbody subRigid in tempRigid)
			{
				rigid = subRigid;
				break;
			}
			rigid.AddForce(Vector3.up*100.0f, ForceMode.Acceleration);
		}
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
