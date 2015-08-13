using UnityEngine;
using System.Collections;

public class PaintScript : MonoBehaviour {

	public Texture2D m_PaintMask;

	private Texture2D m_Texture;
	private Color32[] m_PaintMaskPixels;

	// Use this for initialization
	void Start () {
		m_PaintMaskPixels = m_PaintMask.GetPixels32 ();

		m_Texture = GetComponent<Renderer> ().material.mainTexture as Texture2D;
		Texture2D temp = new Texture2D(m_Texture.width, m_Texture.height, m_Texture.format, m_Texture.mipmapCount != 0);

		var pixels = m_Texture.GetPixels32 ();
		temp.SetPixels32(pixels);
		temp.Apply ();

		m_Texture = temp;
		GetComponent<Renderer> ().material.mainTexture = m_Texture;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision info) {
		m_Texture.SetPixels32 (m_PaintMaskPixels);
		m_Texture.Apply ();


//		for (int i = 0; i < 100; i++) {
//			Debug.Log ("efhukshef");
//			m_Texture.SetPixel (Random.Range (0, 1024), Random.Range (0, 1024), new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
//			m_Texture.Apply();
//		}
	}
}
