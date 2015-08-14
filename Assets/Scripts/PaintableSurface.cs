using UnityEngine;
using System.Collections;

public class PaintableSurface : MonoBehaviour {

	public int m_TextureResolution = 1024;

	private Texture2D m_Texture;

	// Use this for initialization
	void Start () {
		//Create white pixel array
		Color[] white = new Color[m_TextureResolution * m_TextureResolution];
		for(int i = 0; i < m_TextureResolution * m_TextureResolution; i++) {
			white[i] = Color.white;
		}

		//create and assign new white texture
		m_Texture = new Texture2D (m_TextureResolution, m_TextureResolution, TextureFormat.RGBA32, false);
		m_Texture.SetPixels (white);
		m_Texture.Apply ();
		GetComponent<Renderer> ().material.mainTexture = m_Texture;
	}

	public Texture2D GetSurface() {
		return m_Texture;
	}
}
