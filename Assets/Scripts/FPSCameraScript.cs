using UnityEngine;
using System.Collections;

public class FPSCameraScript : MonoBehaviour {

	public Transform m_Target;
	public Texture2D m_Crosshair;
	public bool m_InvertX = false;
	public bool m_InvertY = true;
	public float m_SpeedX = 6f;
	public float m_SpeedY = 6f;

	void Start() {

	}

	void Update() {
		if (Input.GetMouseButtonDown (0)) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
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

	void OnGUI() {

		GUI.DrawTexture (new Rect (new Vector2 (Screen.width/2f, Screen.height/2f), new Vector2 (64, 64)), m_Crosshair);
	}
}
