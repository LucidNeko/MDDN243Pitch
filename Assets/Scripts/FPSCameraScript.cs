using UnityEngine;
using System.Collections;

public class FPSCameraScript : MonoBehaviour {

	public Transform m_Target;
	public bool m_InvertX = false;
	public bool m_InvertY = true;
	public float m_SpeedX = 6f;
	public float m_SpeedY = 6f;

	private GameObject m_Player;
	private Rigidbody m_PlayerRigidBody;

	// Use this for initialization
	void Start () {
		GameObject m_Player = GameObject.FindGameObjectWithTag ("Player");
		m_PlayerRigidBody = m_Player.GetComponent<Rigidbody> ();
	}

	void FixedUpdate() {
		Vector3 forward = transform.TransformDirection(Vector3.forward);
		forward.Scale (new Vector3(1, 0, 1));
		Quaternion look = Quaternion.LookRotation (forward);

//		m_PlayerRigidBody.MoveRotation (look);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = m_Target.position;

		float dx = Input.GetAxis ("Mouse X") * m_SpeedX;
		float dy = Input.GetAxis ("Mouse Y") * m_SpeedY;
		if(m_InvertX) { dx = -dx; }
		if(m_InvertY) { dy = -dy; }

		transform.Rotate (0, dx, 0, Space.World);
		transform.Rotate (dy, 0, 0, Space.Self);
	}
}
