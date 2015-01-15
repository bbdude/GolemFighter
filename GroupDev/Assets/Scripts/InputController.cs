using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterMotor))]
[AddComponentMenu ("Character/InputController")]
public class InputController : MonoBehaviour {

	private CharacterMotor motor;
	public void Awake()
	{
		this.motor = (CharacterMotor)this.GetComponent(typeof(CharacterMotor));
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
			inputControl = new Vector3(Input.GetAxis("Strafe2"), (float)0, Input.GetAxis("VerticalP2"));
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
				this.motor.inputJump = Input.GetButton("Jump2");
		}
	}
}
