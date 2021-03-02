using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour {

	public Transform goal;
	public float speed = 1f;
	public float rotSpeed = 0.4f;


	void MovetoGoal()
    {
		Vector3 lookAtGoal = new Vector3(goal.position.x,
										this.transform.position.y,
										goal.position.z);
		Vector3 direction = lookAtGoal - this.transform.position;

		this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
												Quaternion.LookRotation(direction),
												Time.deltaTime * rotSpeed);
	}
	
	// Update is called once per frame
	void LateUpdate () {

		MovetoGoal();
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Bullet")
		{
			SoundManager.PlaySound("hit");
			Destroy(gameObject);
		}
	}

}
