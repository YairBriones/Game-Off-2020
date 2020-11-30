using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameActive=false;
    public bool gameOver = false;

    public GameObject title;
    public GameObject exitButton; 
    public GameObject startButton; 
    public GameObject gameOverButton;
    public GameObject gameOverText;
    // Start is called before the first frame update
    public void StartGame()
    {
        isGameActive = true;
        title.SetActive(false);
        exitButton.SetActive(false);
        startButton.SetActive(false);

    }

    public void GameOver(){
        gameOverButton.SetActive(true);
        gameOverText.SetActive(true);
        gameOver = true;
        isGameActive = false;
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
