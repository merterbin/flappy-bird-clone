using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject pauseGameCanvas;
    [SerializeField] private GameObject scoreCanvas;
    [SerializeField] private Image bgImage;
    [SerializeField] private Sprite newBgImage;
    [SerializeField] private Image threeImage;
    [SerializeField] private Sprite twoImage;
    [SerializeField] private Sprite oneImage;
    [SerializeField] private AudioSource moveAudio;
    private Sprite tempImage;
    public static GameManager instance;
    private GameObject playerObj;
    private Score score;   

    private void Awake()
    {
        tempImage = threeImage.sprite;
        if (instance == null)
        {
            instance = this;
        }
        Time.timeScale = 1f;
    }
    private void Update()
    {        
        ChangeBackGround();
    }            
    public void ChangeBackGround()
    {
        playerObj = GameObject.FindWithTag("Player");
        score = playerObj.GetComponent<Score>();
        if (score.score >= 15)
        {
            bgImage.sprite = newBgImage;
        }
    }
    public void GameOver()
    {
        if (!(pauseGameCanvas.activeSelf))
        {
            
            gameOverCanvas.SetActive(true);
            scoreCanvas.SetActive(false);
            Time.timeScale = 0f;
        }        
    }
    public void restartGame()
    {
        gameOverCanvas.SetActive(false);
        Time.timeScale = 1f;
        Application.LoadLevel(Application.loadedLevel);
    }
    public void resumeGame()
    {
        if (!(gameOverCanvas.activeSelf))
        {
            pauseGameCanvas.SetActive(false);
            scoreCanvas.SetActive(true);
            threeImage.gameObject.SetActive(true);
            StartCoroutine(waitOneSec());

        }

    }
    public void LoadLevel()
    {        
        Application.UnloadLevel("MainMenu");
        Application.LoadLevel("GameScene");
    }
    public void MainMenu()
    {
        Application.UnloadLevel("GameScene");
        Application.LoadLevel("MainMenu");
        
    }
    public void PauseGame()
    {
        pauseGameCanvas.SetActive(true);
        scoreCanvas.SetActive(false);
        moveAudio.Stop();
        Time.timeScale = 0f;
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Oyun Kapandý");
    }
    private IEnumerator waitOneSec()
    {
        Debug.Log("Bekleme baþladý...");
        for (int i = 3; i > 0; i--)
        {            
            if (i == 2)
            {
                threeImage.sprite = twoImage;
            }
            else if (i == 1)
            {
                threeImage.sprite = oneImage;
            }            
            yield return new WaitForSecondsRealtime(1);
        }
        moveAudio.Play();

        threeImage.sprite = tempImage;
        threeImage.gameObject.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("Bekleme bitti!");
    }
}
