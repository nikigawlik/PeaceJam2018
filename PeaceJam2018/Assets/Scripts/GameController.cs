using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject player;
	public Sprite[] colorWheel;

    private static GameController instance;

    public static GameController Instance
    {
        get
        {
			if(instance == null) {
				instance = Object.FindObjectOfType<GameController>();
			}
            return instance;
        }

        set
        {
            instance = value;
        }
    }

    private void Start() {
		Instance = this;
	}
}
