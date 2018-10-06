using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {
	public float acceleration;
	public float maxSpeed;
	public float rotationAcceleration;
	public float rotationMaxSpeed;

    [HideInInspector]
    private float additionalMass = 0f;

    private Rigidbody2D rb;

    public float AdditionalMass
    {
        get
        {
            return additionalMass;
        }

        set
        {
            additionalMass = value;
        }
    }

    private void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate() {
		Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

		// rb.AddForce(input * acceleration * (rb.mass + AdditionalMass));
		rb.velocity += (input * acceleration * (rb.mass + AdditionalMass)) * Time.fixedDeltaTime;
		rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);

		float rotationAcc = (Input.GetAxis("RotateLeft") - Input.GetAxis("RotateRight")) * rotationAcceleration;

		// rb.AddTorque(rotationAcc * rb.mass);
		rb.angularVelocity += rotationAcc * Time.fixedDeltaTime;
		rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, -rotationMaxSpeed, rotationMaxSpeed);
	}
}
