using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public void Awake() {
		StartCoroutine(Expand (6, 1, 0.001f));
	}	

	public void OnCollisionEnter(Collision collision) {
//		Destroy (gameObject);
		MakePaint (collision);
	}

	private void MakePaint(Collision info) {

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

}
