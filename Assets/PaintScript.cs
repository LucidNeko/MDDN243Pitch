using UnityEngine;
using System.Collections;

public class PaintScript : MonoBehaviour {

	public Texture2D m_PaintMask;
	public int m_TextureResolution = 1024;


	private Texture2D m_Texture;
	private RenderTexture m_RenderTexture;
	private Color32[] m_PaintMaskPixels;

	// Use this for initialization
	void Start () {
//		m_Texture = GetComponent<Renderer> ().material.mainTexture as Texture2D;

//		m_RenderTexture = new RenderTexture (m_Texture.width, m_Texture.height, 24, RenderTextureFormat.ARGB32);
//		Graphics.Blit (m_PaintMask, m_RenderTexture);
//		GetComponent<Renderer> ().material.mainTexture = m_RenderTexture;



//		m_PaintMaskPixels = m_PaintMask.GetPixels32 ();
//
//		m_Texture = GetComponent<Renderer> ().material.mainTexture as Texture2D;

//		Texture2D temp = new Texture2D(m_Texture.width, m_Texture.height, m_Texture.format, m_Texture.mipmapCount != 0);
//
//		var pixels = m_Texture.GetPixels32 ();
//		temp.SetPixels32(pixels);
//		temp.Apply ();
//
//		m_Texture = temp;
		Color[] white = new Color[m_TextureResolution * m_TextureResolution];
		for(int i = 0; i < m_TextureResolution * m_TextureResolution; i++) {
			white[i] = Color.white;
		}

		m_Texture = new Texture2D (m_TextureResolution, m_TextureResolution, TextureFormat.RGBA32, false);
		m_Texture.SetPixels (white);
		m_Texture.Apply ();
		GetComponent<Renderer> ().material.mainTexture = m_Texture;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision info) {
//		m_Texture.SetPixels32 (m_PaintMaskPixels);
//		m_Texture.Apply ();

//		foreach (ContactPoint p in info.contacts) {
//
//			RaycastHit hit = new RaycastHit();
//			Ray ray = new Ray(p.point - p.normal, p.normal);
//			if(p.thisCollider.Raycast(ray, out hit, 1.1f)){
//				Vector2 texCoord = hit.textureCoord;
//				Debug.Log(texCoord);
//				int x = (int)(texCoord.x * m_Texture.width);
//				int y = (int)(texCoord.y * m_Texture.height);
//
//				int width = 51;
//				int height = 51;
//				int x0 = x - width/2;
//				int y0 = y - height/2;
//
//				Color[] colors = new Color[width*height];
//				for(int i = 0; i < width*height; i++) {
//					colors[i] = Color.red;
//				}
//
//				m_Texture.SetPixels(x0, y0, width, height, colors);
////				m_Texture.SetPixel(x, y, Color.red);
//				m_Texture.Apply();
//			}
//		}


//		for (int i = 0; i < 100; i++) {
//			Debug.Log ("efhukshef");
//			m_Texture.SetPixel (Random.Range (0, 1024), Random.Range (0, 1024), new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
//			m_Texture.Apply();
//		}
	}
}
