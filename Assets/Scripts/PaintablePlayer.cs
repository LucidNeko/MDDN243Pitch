using UnityEngine;
using System.Collections;

public class PaintablePlayer : MonoBehaviour, PaintableSurface
{

	private PlayerController m_PC;
	private Renderer m_Renderer;

	// Use this for initialization
	void Start ()
	{
		m_Renderer = GetComponentInChildren<Renderer> ();

		m_PC = GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.C)) {
			m_PC.CharacterColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
		}
	}

	public bool Paint(Color color, Collision info) {


//		m_PC.CharacterColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
		m_PC.CharacterColor = color;

		return true;
	}
}

