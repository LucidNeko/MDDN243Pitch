using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float m_Speed = 6f;

	private PlayerController m_PlayerController;
	private Rigidbody m_RigidBody;
	private Animator m_Animator;

	// Use this for initialization
	void Start () {
		m_Animator = GetComponent<Animator> ();

		m_RigidBody = GetComponent<Rigidbody> ();	

		m_RigidBody.constraints = RigidbodyConstraints.FreezeRotationX | 
								  RigidbodyConstraints.FreezeRotationY | 
								  RigidbodyConstraints.FreezeRotationZ;

		m_PlayerController = GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		if (h != 0 || v != 0) {
			Vector3 move = new Vector3 (h, 0, v);
			move = Camera.main.transform.TransformDirection (move);
			move.Scale(new Vector3(1,0,1));



			Quaternion look = Quaternion.LookRotation(move);
			m_RigidBody.MoveRotation(look);
		}

		m_Animator.SetFloat ("Speed", (new Vector3(h,0,v) * m_Speed).magnitude);

		if (Input.GetMouseButton (0)) {
			m_PlayerController.Fire();
		}
	}
}
