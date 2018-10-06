using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Rigidbody2D following;
	public float lerpFactor;

	private void FixedUpdate() {
		Vector3 pos = following.transform.TransformPoint((Vector3)following.centerOfMass);

		transform.position = Vector3.Lerp(transform.position, pos, lerpFactor);
	}
}
