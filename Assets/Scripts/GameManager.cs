using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameHasEnded = false;
    public bool gameHasReplayed = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    private void Start()
    {
        instance = this;
        //First shot
        FindObjectOfType<InputHandler>().StartRecording();
        /*if (!InputHandler._isRecording && !InputHandler._isReplaying)
        {
            FindObjectOfType<InputHandler>().StartRecording();
        } 
        else if (InputHandler._isRecording)
        {
            FindObjectOfType<InputHandler>().StopRecording();
            FindObjectOfType<InputHandler>().StartReplay();
        }
        else if (InputHandler._isReplaying)
        {
            FindObjectOfType<InputHandler>().StartRecording();
        }
        else
        {
            FindObjectOfType<InputHandler>().StartRecording();
        }
        Debug.Log("isRecording: " + InputHandler._isRecording.ToString() + "\nisReplaying: " + InputHandler._isReplaying.ToString());*/
    }
    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }
        
    }
    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }
    public void Restart()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
