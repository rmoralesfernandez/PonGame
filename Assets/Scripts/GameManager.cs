using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Ball checkScore;

    // Update is called once per frame
    void Update()
    {
        if (checkScore.CheckScore() == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
            {
                SceneManager.LoadScene("Game");
            }

            if (Input.GetKeyDown(KeyCode.M) || Input.GetMouseButton(0))
            {
                SceneManager.LoadScene("Menu");
            }

            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                SceneManager.LoadScene("GameIA");
            }
        } 
    }
}
