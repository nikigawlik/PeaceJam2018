using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public GameObject player;
	public Sprite[] colorWheel;
	public float timer = 60;
	public Text timerText;
	public GameObject gameOverScreen;
	public Text gameOverPeopleFoundText;
	public Text gameOverPeopleNotFoundText;


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
		Time.timeScale = 1f;
	}

	private void Update() {
		timer -= Time.deltaTime;
		
		// game recap
		if(timer <= 0) {
			timer = 0;
			Time.timeScale = 0;

			gameOverScreen.SetActive(true);

			int numberOfPeople = Object.FindObjectsOfType<Sticky>().Length - 1;
			int numberOfPeopleFound = player.GetComponentsInChildren<Sticky>().Length - 1;

			gameOverPeopleFoundText.text = numberOfPeopleFound.ToString();
			gameOverPeopleNotFoundText.text = (numberOfPeople - numberOfPeopleFound).ToString();
		}

		string str = "";

		float minutes = Mathf.Floor(timer / 60);
		float seconds = Mathf.RoundToInt(timer%60);
		
		if(minutes < 10) {
			str += "0";
		} 
		str +=  minutes.ToString();
		str +=  ":";
		if(seconds < 10) {
			str += "0";
		}
		str += Mathf.RoundToInt(seconds).ToString();
		

		timerText.text = str;
	}

	public void Restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Quit() {
		SceneManager.LoadScene("Menu");
	}
}
