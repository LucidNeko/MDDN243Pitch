using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public Texture2D m_SplatterTexture;

	private Rigidbody m_RigidBody;

	private Vector3[] m_RandomVectors = new Vector3[100];

	private Color[] m_SplatterPixels;

	public void Start() {
		m_RigidBody = GetComponent<Rigidbody> ();


		float factor = 0.5f;
		for(int i = 0; i < m_RandomVectors.Length; i++) {
			m_RandomVectors[i] = new Vector3(Random.Range(-factor, factor), Random.Range(-factor, factor), Random.Range(-factor, factor));
		}

		m_SplatterPixels = m_SplatterTexture.GetPixels ();
	}

	public void Awake() {
		StartCoroutine(Expand (3, 1, 0f));
	}	

	public void OnCollisionEnter(Collision collision) {
		MakePaint (collision);
	}

	public void Update() {
//		Debug.Log(m_RigidBody.velocity);
	}

	private void MakePaint(Collision info) {
		PaintableSurface ps = info.gameObject.GetComponent<PaintableSurface> ();

		if (ps) {
			Texture2D surface = ps.GetSurface();

			Vector3 dir = info.relativeVelocity;
//			float mag = dir.magnitude;
			dir.Normalize();
			dir = -dir; //face from bullet to surface

			foreach (ContactPoint p in info.contacts) {

				Vector2[] uvs = new Vector2[100];
				for(int i = 0; i < uvs.Length; i++) {
					RaycastHit hit;
					Ray ray = new Ray(m_RigidBody.position-dir*0.1f, (dir + m_RandomVectors[i]).normalized);
					if(p.otherCollider.Raycast(ray, out hit, 10f)) {
						Vector2 uv = hit.textureCoord;
						int x = (int)(uv.x * surface.width);
						int y = (int)(uv.y * surface.height);
						uvs[i] = new Vector2(x, y);
					}
				}

				foreach(Vector2 v in uvs) {
					surface.SetPixel((int)v.x, (int)v.y, Color.red);
				}
				surface.Apply();

//				RaycastHit hit;
//				Ray ray = new Ray(m_RigidBody.position, dir);
//				if(p.otherCollider.Raycast(ray, out hit, 10f)) {
//					Vector2 uv = hit.textureCoord;
//					int x = (int)(uv.x * surface.width);
//					int y = (int)(uv.y * surface.height);
//
//					Vector3 r = new Vector3();
//
//					for(int i = 10; i < 20; i++) {
//
//					}
//
//					surface.SetPixel(x, y, Color.red);
//					surface.Apply();
//				}


//				Ray ray = new Ray(p.point + p.normal, -p.normal);
//				if(p.otherCollider.Raycast(ray, out hit, 1.1f)){
//					Vector2 uv = hit.textureCoord;
//					int x = (int)(uv.x * surface.width);
//					int y = (int)(uv.y * surface.height);
//					
//					int width = 51;
//					int height = 51;
//					int x0 = x - width/2;
//					int y0 = y - height/2;
//
//					x0 = Mathf.Clamp(x0, 0, surface.width-width);
//					y0 = Mathf.Clamp(y0, 0, surface.height-height);
//					
//					Color[] colors = new Color[width*height];
//					for(int i = 0; i < width*height; i++) {
//						colors[i] = Color.red;
//					}
//					
//					surface.SetPixels(x0, y0, width, height, colors);
//					//				m_Texture.SetPixel(x, y, Color.red);
//					surface.Apply();
//				}

			}

			
			Destroy (gameObject);
		}
	}

	public IEnumerator Expand(float size, float duration, float delay) {
//		yield return new WaitForSeconds (delay);

		Vector3 start = transform.localScale;
		Vector3 end = new Vector3 (size, size, size);

		float t = 0;
		while (t < 1) {
			transform.localScale = Vector3.Lerp(start, end, t);
			t += Time.deltaTime * duration;
			yield return null;
		}
	}

//	void OnCollisionEnter(Collision info) {
//		//		m_Texture.SetPixels32 (m_PaintMaskPixels);
//		//		m_Texture.Apply ();
//		
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
//				//				m_Texture.SetPixel(x, y, Color.red);
//				m_Texture.Apply();
//			}
//		}
//		
//		
//		//		for (int i = 0; i < 100; i++) {
//		//			Debug.Log ("efhukshef");
//		//			m_Texture.SetPixel (Random.Range (0, 1024), Random.Range (0, 1024), new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
//		//			m_Texture.Apply();
//		//		}
//	}

}
