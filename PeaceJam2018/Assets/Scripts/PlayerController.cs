using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {
	public float acceleration;
	public float maxSpeed;

	private Rigidbody2D rb;

	private void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate() {
		Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

		rb.AddForce(input * acceleration * rb.mass);
		rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);

	}
}
