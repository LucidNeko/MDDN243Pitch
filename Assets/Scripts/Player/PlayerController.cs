using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	public GunScript m_Gun;
	private Renderer[] m_GunMaterials;
	private Material m_PlayerMaterial;


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
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void Fire() {
		m_Gun.Fire (m_Color);
	}
}

