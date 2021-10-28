using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()//게임 시작시
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//다음 씬을 불러옴
    }

    public void QuitGame()//게임 종료시
    {
        Debug.Log("QUIT");//게임 종료 표시
        Application.Quit();//게임 종료
    }
}
