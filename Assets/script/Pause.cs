using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    public TimeManagemer timeManagemer;
    public static bool GameIsPaused = false;
    

    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//ESC입력시
        {
            if (GameIsPaused)
            {
                Resume();//재개
            }
            else
            {
                pause();//정지
            }
        }
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);//패널 OFF
        Time.timeScale = 1f;//시간을 다시 흐르게
        GameIsPaused = false;//정지 유무
        Cursor.lockState = CursorLockMode.Locked;//마우스를 안보이게
        timeManagemer.IsGameOn = true;//timeManager클래스의 함수 정지
    }

    void pause ()//게임 정지
    {
        pauseMenuUI.SetActive(true);//패널 ON
        Time.timeScale = 0f;//시간 정지
        GameIsPaused = true;//정지 유무
        Cursor.lockState = CursorLockMode.None;//마우스를 보이게
        timeManagemer.IsGameOn = false;//timeManager클래스의 함수 정지
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;//시간을 다시 흐르게
        SceneManager.LoadScene("MainMenu");//ScenManager을 이용하여 다른 씬을 불러옴
    }
}
