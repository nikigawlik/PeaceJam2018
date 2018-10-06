using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobController : MonoBehaviour {
	private bool isAttached = false;

	private void OnCollisionEnter2D(Collision2D other) {
		if(!isAttached) {
			Sticky stick = other.collider.GetComponent<Sticky>();

			if(stick != null) {
				stick.AttachBlob(this.GetComponent<Sticky>());
				this.isAttached = true;
			}
		}
	}
}
