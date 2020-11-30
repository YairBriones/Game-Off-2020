using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool canMoveAndShoot = false;
    public bool isGameActive = true;

    public GameObject winText;
    public GameObject gameOverText;
    public GameObject menuButton;
    void Start()
    {
        
    }
    public void GameOver(){
        isGameActive = false;
        gameOverText.SetActive(true);
        menuButton.SetActive(true);
    }
    public void WinGame(){
        isGameActive = false;
        winText.SetActive(true);
        menuButton.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void RestartGame(){
        SceneManager.LoadScene("Scene1");
    }
}
