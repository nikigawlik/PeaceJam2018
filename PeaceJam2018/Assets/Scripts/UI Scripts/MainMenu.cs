using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{



    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }


    public void ChangeTransform()
    {
        this.transform.localScale = Vector3.Lerp(this.transform.localScale, this.transform.localScale / 2, 20);
        this.transform.position += Vector3.up;
    }


}
