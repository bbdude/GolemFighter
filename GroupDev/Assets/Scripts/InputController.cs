using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterMotor))]
[AddComponentMenu ("Character/InputController")]
public class InputController : MonoBehaviour {

	private CharacterMotor motor;
	private Animator anim;
	AnimatorStateInfo CurrentState;

	void OnTriggerEnter(Collider other) {
		//Destroy(other.gameObject);
		if (motor.whocontroller == 1 && other.collider.tag == "Player2")
		{
			//Destroy(other.gameObject);
		}
		else if (motor.whocontroller == 2 && other.collider.tag == "Player1")
		{
			//Destroy(other.gameObject);
		}
	}

	public void Awake()
	{
		this.motor = (CharacterMotor)this.GetComponent(typeof(CharacterMotor));
		Animator[] tempAnim;
		tempAnim = GetComponentsInChildren<Animator>();
		foreach(Animator subAnim in tempAnim)
			this.anim = subAnim;

		CurrentState = anim.GetCurrentAnimatorStateInfo (0);
		//this.anim = (Animator)this.GetComponent(typeof(Animator));
	}
	public void Update()
	{
		Vector3 inputControl = Vector3.zero;
		if (motor.whocontroller == 1)
		{
			inputControl = new Vector3(Input.GetAxis("Strafe"), (float)0, Input.GetAxis("Vertical"));
		}
		else if (motor.whocontroller == 2)
		{
			inputControl = new Vector3(Input.GetAxis("StrafeP2"), (float)0, Input.GetAxis("VerticalP2"));
		}


		if (motor.ghostControl)
		{
			Vector3 vector = new Vector3(/*Input.GetAxis("Horizontal")*/0, (float)0, /*Input.GetAxis("Vertical")*/5);
			if (vector != Vector3.zero)
			{
				float num = vector.magnitude;
				vector /= num;
				num = Mathf.Min((float)1, num);
				num *= num;
				vector *= num;
			}
			this.motor.inputMoveDirection = this.transform.rotation * vector;

			//this.motor.inputJump = Input.GetButton("Jump");
		}
		else
		{
			//if punch animation is playing stop the movement
			//if (anim.animation.IsPlaying("Punch1"))
			/*int hash = Animator.StringToHash ("Punch1");
			if (CurrentState.nameHash == Animator.StringToHash ("Punch1"))
			{*/
			if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Punch1"))
			{
				// Avoid any reload.
				inputControl.z = 0;
				inputControl.x = 0;
				this.motor.inputMoveDirection = Vector3.zero;
			}
			Vector3 vector = inputControl;
			if (vector != Vector3.zero)
			{
				float num = vector.magnitude;
				vector /= num;
				num = Mathf.Min((float)1, num);
				num *= num;
				vector *= num;
			}
			this.motor.inputMoveDirection = this.transform.rotation * vector;
			
			if (motor.whocontroller == 1)
				this.motor.inputJump = Input.GetButton("Jump");
			
			if (motor.whocontroller == 2)
				this.motor.inputJump = Input.GetButton("JumpP2");
		}
	}
}
