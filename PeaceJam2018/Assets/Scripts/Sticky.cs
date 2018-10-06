﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : MonoBehaviour {
    private Sticky coreObject = null;

	private void Start() {
		PlayerController pc = GetComponent<PlayerController>();
		if(pc != null) {
			CoreObject = this;
		}
	}

    public Sticky CoreObject
    {
        get
        {
            return coreObject;
        }

        set
        {
            coreObject = value;
        }
    }

    public void AttachBlob(Sticky otherSticky) {
		if(coreObject != null) {
			Rigidbody2D blobRB = otherSticky.GetComponent<Rigidbody2D>();

			Destroy(blobRB);
			otherSticky.gameObject.transform.SetParent(this.transform);

			otherSticky.coreObject = coreObject;
		}
	}

	// old spring based system

    // public void AttachBlob(Sticky other) {
	// 	Rigidbody2D blobRB = other.GetComponent<Rigidbody2D>();
	// 	Rigidbody2D meRB = this.GetComponent<Rigidbody2D>();

	// 	SpringJoint2D spring = other.gameObject.AddComponent<SpringJoint2D>();
	// 	spring.connectedBody = meRB;
	// 	spring.frequency = 300;

	// 	other.coreObject = coreObject;
	// 	// player mass
	// 	coreObject.GetComponent<PlayerController>().AdditionalMass += this.GetComponent<Rigidbody2D>().mass;
	// }
}
