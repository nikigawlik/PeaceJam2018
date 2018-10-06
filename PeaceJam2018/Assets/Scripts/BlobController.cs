using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobController : MonoBehaviour {
	private bool isAttached = false;

	private void OnCollisionEnter2D(Collision2D other) {
		if(!isAttached) {
			Sticky otherStick = other.collider.gameObject.GetComponent<Sticky>();
			Sticky myStick = GetComponent<Sticky>();

			if(otherStick != null) {
				// calculate difference in colors
				int colorDifference = Mathf.Abs(otherStick.colorID - myStick.colorID);
				// handle case where it wraps over
				if(colorDifference == GameController.instance.colorWheel.Length-1) {
					colorDifference = 1;
				}

				if(colorDifference <= 1) {
					bool success = otherStick.AttachBlob(this.GetComponent<Sticky>());
					this.isAttached = success;
				}
			}
		}
	}
}
