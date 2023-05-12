using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("기본이동")]
    public float maxSpeed;
    public float jumpPower;

    [Header("기쁨상태 파라미터")]
    private float defualtmaxSpeed;
    private float defualtjumpPower;
    public float JoymaxSpeed;
    public float JoyjumpPower;

    Rigidbody2D rigid;

    public Vector3 respawnPoint;

    [SerializeField] private AudioSource jumpSoundEffect;

    public GameObject manager;
    private Moving moving;


    [Header("상태변화")]
    [SerializeField]
    private float redball = 0;
    public float Red
    {
        get
        {
            return redball;
        }
        set
        {
            redball = value;
            if (redball >= 5)
            {
                IsJoy = true;
                StartCoroutine(WaitAndSetIsJoy());
            }

        }
    }



    [SerializeField]
    private float greenball = 0;
    public float Green
    {
        get
        {
            return redball;
        }
        set
        {
            greenball = value;
            if (greenball >= 5)
                isSurprised = true;//놀란상태
            //기쁨상태가 되면 점점 줄어드는 메서드
            //기쁨상태가 0
        }
    }



    [SerializeField]
    private float blueball = 0;
    public float Blue
    {
        get
        {
            return blueball;
        }
        set
        {
            blueball = value;
            if (blueball >= 5)
                isSad = true;//슬픔상태
            //기쁨상태가 되면 점점 줄어드는 메서드
            //기쁨상태가 0
        }
    }


    bool isJoy = false;
    bool IsJoy
    {
        get
        {
            return isJoy;
        }
        set
        {
            isJoy = value;
            if (isJoy)
            {
               
                moving.dashInputHandler += moving.HandleDashInput;
            }
            else
            {
                moving.dashInputHandler -= moving.HandleDashInput;
            }
        }
    }

    bool isSad = false;
    bool IsSad
    {
        get
        {
            return isSad;
        }
        set
        {
            isSad = value;
            if (isSad)
            {

            }
            else
            {

            }
        }
    }
    bool isSurprised = false;



    void Awake()
    {
        defualtmaxSpeed = maxSpeed;
        defualtjumpPower = jumpPower;
        rigid = GetComponent<Rigidbody2D>();
        manager = GameObject.Find("GameManager");
        respawnPoint = this.transform.position;
        moving = this.GetComponent<Moving>();
    }



    private void SetDefaultState()
    {
        redball = 0;
        blueball = 0;
        greenball = 0;
    }

    public void Die()
    {
        SetDefaultState();
        var Manager = manager.GetComponent<GameManager>();
        Manager.RespawnPlayer();
        gameObject.SetActive(false);


    }





IEnumerator WaitAndSetIsJoy()
{
   yield return StartCoroutine(ReduceRedBall());
   Debug.Log("isjoy false!");
  IsJoy =false;
}

IEnumerator ReduceRedBall()
{

    while(redball >0.1f)
    {
        redball -= Time.deltaTime;
        yield return null;
    }
}
}
