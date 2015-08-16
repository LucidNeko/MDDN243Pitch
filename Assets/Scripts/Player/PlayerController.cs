using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	public float m_Speed = 6f;
	
	public Color m_StartingColor;

	public GunScript m_Gun;
	private Renderer[] m_GunMaterials;
	private Material m_PlayerMaterial;

	private Rigidbody m_RigidBody;
	private Animator m_Animator;

	private Color m_Color = Color.white;
	public Color CharacterColor {
		get { return m_Color; }
		set {
			m_Color = value;
		foreach (Renderer r in m_GunMaterials) {
				r.material.color = m_Color;
			}
			m_PlayerMaterial.color = m_Color;
		}
	}

	// Use this for initialization
	void Start ()
	{
		m_GunMaterials = m_Gun.GetComponentsInChildren<Renderer> ();
		m_PlayerMaterial = GetComponentInChildren<Renderer> ().material;

		m_RigidBody = GetComponent<Rigidbody> ();
		m_Animator = GetComponent<Animator> ();

		m_RigidBody.constraints = RigidbodyConstraints.FreezeRotationX | 
								  RigidbodyConstraints.FreezeRotationY | 
								  RigidbodyConstraints.FreezeRotationZ;

		CharacterColor = m_StartingColor;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.F)) {
			m_Gun.GetComponent<Animator>().speed = 10;
		}

		if (Input.GetKeyUp (KeyCode.F)) {
			m_Gun.GetComponent<Animator>().speed = 1;
		}
	}

	public void Fire() {
		m_Gun.Fire (m_Color);
	}

	public void Move(Vector3 move, bool jump) {

		//If we're moving
		if (move.x != 0 || move.y != 0 || move.z != 0) {
			//look in move direction
			Quaternion look = Quaternion.LookRotation(move);
			m_RigidBody.MoveRotation(look);
		}

		//Set animator properties
		m_Animator.SetFloat ("Speed", move.magnitude * m_Speed);
	}
}

