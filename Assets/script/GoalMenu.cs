using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalMenu : MonoBehaviour
{

    public playerMove PlayerMove;
    public GameObject GoalMenuUI;

    bool GoalCheck;

    void Update()
    {
        GoalCheck = PlayerMove.Goaled;//PlayerMove클래의 트리거를 이용하여 판단

        if (GoalCheck == true)//골인 했을 때
        {
            GoalMenuUI.SetActive(true);//패널 ON
            Time.timeScale = 0f;//시간 정지
            Cursor.lockState = CursorLockMode.None;//커서를 보이게
        }
    }

    public void Restart()//재시작
    {
        SceneManager.LoadScene("game1");//게임의 씬을 다시 불러온다
    }

    public void Quit()
    {
        Application.Quit();//게임을 종료
    }
}
