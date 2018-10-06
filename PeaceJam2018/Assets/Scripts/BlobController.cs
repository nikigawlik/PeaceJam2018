using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobController : MonoBehaviour {
	public float repellForce = 10f;

	private bool isAttached = false;
	private Rigidbody2D rb;

	private void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if(!isAttached) {
			Sticky otherStick = other.collider.gameObject.GetComponent<Sticky>();
			Sticky myStick = GetComponent<Sticky>();

			if(otherStick != null)
            {
                // calculate difference in colors
                int colorDifference = 0;
                colorDifference = ColorDifference(otherStick.colorID, myStick.colorID);

                if (colorDifference <= 1)
                {
                    bool success = otherStick.AttachBlob(this.GetComponent<Sticky>());
                    this.isAttached = success;
                }
            }
        }
	}

    private void OnTriggerStay2D(Collider2D other) {
		if(!isAttached) {
			RepellTrigger repellTrigger = other.GetComponent<RepellTrigger>();
			if(repellTrigger != null) {
				Sticky otherSticky = repellTrigger.attachedTo.GetComponent<Sticky>();
				Sticky mySticky = GetComponent<Sticky>();

				if(otherSticky != mySticky) {
					int dif = ColorDifference(mySticky.colorID, otherSticky.colorID);

					if(dif > 1) {
						// repell
						Vector2 delta = transform.position - otherSticky.transform.position;
						rb.AddForce(delta.normalized * rb.mass * repellForce);
					}
				}
			}
		}
	}

    private static int ColorDifference(int id1, int id2)
    {
        int colorDifference = Mathf.Abs(id1 - id2);
        // handle case where it wraps over
        if (colorDifference == GameController.Instance.colorWheel.Length - 1)
        {
            colorDifference = 1;
        }

        return colorDifference;
    }
}
