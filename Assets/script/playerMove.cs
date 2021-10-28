using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMove : MonoBehaviour
{

    public TimeManagemer timeManagemer;

    public CharacterController controller;
    public Transform Pcamera;
    Animator anim;

    float speed = 10.0f;//걷는 속도
    float maxspeed = 15.0f;
    float minspeed = 10.0f;
    float gravity = -9.81f;//중력 크기
    float jumpHeight = 1.0f;//점프 높이
    float heightFactor = 2.5f;
    float x;
    float z;

    Vector3 velocitiy;//속도
    public Transform Groundcheck;//땅에 서있는지 판단하지위해
    public float GroundDistance = 0.4f;//땅과의 거리
    public LayerMask groundMask;//땅이라고 판단해주기위해
    RaycastHit rayhit;//히트 판정

    public bool airwalk = false;//중력 적용 유무
    public bool Goaled = false;
    bool isGrounded;//땅에 서있는지 판단
    bool climbing = false; //벽타기

    int count = 0;//벽타는 횟수
    void Start()
    {
        anim = GetComponent < Animator>();//애니매이션
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(Groundcheck.position, GroundDistance, groundMask);//바닥 체크

        if(isGrounded && velocitiy.y < 0)//바닥에 있을때
        {
            velocitiy.y = -2f;//중력을 고정
            climbing = false;//벽타기 off
            count = 0;//벽탄 횟수 초기화
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;//Horizontal 값과 vertical값 가져오기

        //달리기
        if(Input.GetKey(KeyCode.LeftShift))//왼쪽 쉬프트 키
        {
            if (speed <= maxspeed)//최고 속도가 아닐 때
            {                    
                speed += 0.5f;//가속

                if (speed > maxspeed) //최고 속도에 도달했을 때
                {
                    speed = 15.0f;  //속도를 초과할 경우 15.0으로 설정
                }
            }

            
        }
        else if(speed>=minspeed)//쉬프트키를 입력하기 않고 최저 속도보다 높을 때
        {
            speed -= 0.05f;//감속
            if(speed<minspeed)      //6.0이하로 내려갈 경우 10.0으로 재설정
            {
                speed = 10.0f;
            }
        }

        velocitiy.y += gravity * Time.deltaTime;//중력

        

        if(Input.GetButtonDown("Jump") && isGrounded)//jump키 입력과 동시에 땅에있을 때
        {
            velocitiy.y = Mathf.Sqrt(jumpHeight * -2f * gravity);// 위로 점프
        }

        if (airwalk == false)//중력 적용
        {
            controller.Move(move * speed * Time.deltaTime);     //속도+이동
            controller.Move(velocitiy * Time.deltaTime);//중력적용
        }
        else if(airwalk == true)        //중력 해제
        {
            velocitiy.y = -2f;          //내려가는 힘을 초기화
            if (Input.GetButtonDown("Jump"))
            {
                airwalk = false;
                velocitiy.y = Mathf.Sqrt(jumpHeight * -5f * gravity);//점프 높이 설정
                controller.Move(move*velocitiy.y*speed*Time.deltaTime);//벽 점프
            }
        }

        //Animation
        if (x>0 || z>0)//오른쪽 또는 앞으로 움직일때
        {
            anim.SetBool("iswalking", true);//on
        }
        else if (x<0||z<0)//왼쪽 또는 뒤로 움직일때
        {
            anim.SetBool("iswalking", true);//on
        }
        else
        {
            anim.SetBool("iswalking", false);//off
        }

        if (Input.GetKey(KeyCode.LeftShift))//달릴때
        {
            anim.SetBool("isrunning", true);//on
        }
        else
        {
            anim.SetBool("isrunning", false);//off
        }

        if (velocitiy.y>-2f && !isGrounded)//점프했을때
        {
            anim.SetBool("isjumping", true);//on
        }
        else
        {
            anim.SetBool("isjumping", false);//off
        }

        //Scene
        if (Input.GetKeyDown(KeyCode.Escape))
        {

        }
    }

    void FixedUpdate()
    {
        Ray rayR = new Ray(transform.position+Vector3.up, transform.right);//오른쪽 히트
        Ray rayL = new Ray(transform.position + Vector3.up, -transform.right);//왼쪽 히트
        Ray rayF = new Ray(transform.position + Vector3.up, transform.forward);//전방 히트
        Debug.DrawRay(rayR.origin, rayR.direction, Color.red);
        Debug.DrawRay(rayL.origin, rayL.direction, Color.red);
        Debug.DrawRay(rayF.origin, rayF.direction, Color.red);

        Vector3 Gofront = transform.forward * 1.5f;
        Vector3 Goup=velocitiy;

        if((Physics.Raycast(rayR, out rayhit,0.7f)&& !isGrounded))//모두 땅에 없고 왼쪽 혹은 오른쪽
        {
            if (rayhit.transform.tag == "wall")//wall에 맞았을 때
            {
                airwalk = true;         //중력 해제
                controller.Move((Gofront+transform.right) * speed * Time.deltaTime);//앞으로 계속이동
                
            }
            else
            {
                    airwalk = false;        //중력 적용
            }

        }else if ((Physics.Raycast(rayL, out rayhit, 0.7f) && !isGrounded))
        {
            if (rayhit.transform.tag == "wall")         //wall에 맞았을 때
            {
                airwalk = true;         //중력 해제
                controller.Move((Gofront + -transform.right) * speed * Time.deltaTime); // 앞으로 계속이동
                
            }
            else
            {
                airwalk = false;        //중력 적용
            }
        }
        else if ((Physics.Raycast(rayF, out rayhit, 1.0f) && !isGrounded))         //전방 히트 그리고 땅에 없을때
        {
            climbing = true;//벽타기 on
            if (rayhit.transform.tag == "wall")     //wall에 맞았을 때
            {
                if (climbing == true)//벽타기가 on일때 
                {
                    airwalk = true;//on
                    if (Input.GetButton("Jump")&&count<30)//벽을 탄 횟수가 30미만일때 
                    {
                        controller.transform.position += (Vector3.up / heightFactor);     //벽 타기
                        count++;//횟수 추가
                        
                    }else if (count >= 30)//벽탄 횟수가 30이상 일때
                    {
                        climbing = false;//벽타기 off
                        airwalk = false;//중력 on
                    }
                }
            }
        }
        else
        {
            airwalk = false;//중력 적용
        }
    }

    void OnTriggerEnter(Collider other)//Goal 지점에 도착
    {
        if (other.tag == "Goal")
        {
            timeManagemer.DoSlowmotin();//슬로우 모션
            timeManagemer.IsGameOn = false;//게임진행 유무
            Goaled = true;//도착유무
        }else if (other.tag == "Dead")//죽을 때
        {
            SceneManager.LoadScene("game1");//재시작
        }
        else if(other.tag == "Slow")//슬로우 모션
        {
            timeManagemer.DoSlowmotin();//timeManagemer에서 슬로우 모션을 사용
        }
    }

}
