﻿using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	private Rigidbody m_RigidBody;

	public void Start() {
		m_RigidBody = GetComponent<Rigidbody> ();
	}

	public void Awake() {
		StartCoroutine(Expand (3, 1, 0f));
	}	

	public void OnCollisionEnter(Collision collision) {
		PaintableSurface ps = collision.gameObject.GetComponent<PaintableSurface> ();
		if (ps != null) {
			if(ps.Paint(GetComponent<Renderer>().material.color, collision)) {
				Destroy (gameObject);
			}
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

}
