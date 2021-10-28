using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManagemer : MonoBehaviour
{
    // Start is called before the first frame update
    public float slowdownFactor = 0.05f;//시간의 속도
    public float slowdownLength = 5f;//느리게 할 시간

    public bool IsGameOn=true;
    // Update is called once per frame
    void Update()
    {

        if (IsGameOn == true)
        {
            Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;//시간의 흐름을 되돌리기
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);//시간의 흐름을 0초에서 1초까지 제한하기
        }
    }

    public void DoSlowmotin()
    {
        Time.timeScale = slowdownFactor;//시간의 흐름을 느리게하기
        //Time.fixedDeltaTime = Time.timeScale * 0.02f;//프레임을 일정하게
    }
}
