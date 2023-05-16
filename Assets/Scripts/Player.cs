using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{



    [Header("기쁨상태 파라미터")]
    private float defualtmaxSpeed;
    private float defualtjumpPower;
    public float JoymaxSpeed;
    public float JoyjumpPower;

    [Header("놀람상태 파라미터")]
    bool isSurprised = false;

    public float surpJumpPower;
    public float surpSpeed;

    [Header("슬픔상태 파라미터")]


    [Header("열쇠 가지고있는지")]
    public bool isHaveKey = false;

    Rigidbody2D rigid;

    public Vector3 respawnPoint;

    [SerializeField] private AudioSource jumpSoundEffect;

    public GameObject manager;
    private Moving moving;
    public Collider2D coll;



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
                StartCoroutine(WaitAndSet(isJoy));
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
                IsSurprised = true;
            StartCoroutine(WaitAndSet(isSurprised));
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
                IsSad = true;
            StartCoroutine(WaitAndSet(isSad));
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

    bool IsSurprised
    {
        get
        {
            return isSurprised;
        }
        set
        {
            isSurprised = value;
            if (isSurprised)
            {
                
            }
            else
            {

            }
        }
    }


    public bool isSad = false;
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





    void Awake()
    {
        moving = this.GetComponent<Moving>();
        defualtmaxSpeed = moving.speed;

        coll=gameObject.GetComponent<Collider2D>();
        defualtjumpPower = moving.jumpHeight;
        rigid = GetComponent<Rigidbody2D>();
        manager = GameObject.Find("GameManager");
        respawnPoint = this.transform.position;

    }





    public void Die()
    {
        SetDefaultState();
        var Manager = manager.GetComponent<GameManager>();
        Manager.RespawnPlayer();
        gameObject.SetActive(false);


    }

    private void SetDefaultState()
    {
        redball = 0;
        blueball = 0;
        greenball = 0;
    }



    IEnumerator WaitAndSet(bool state)
    {
        if (state == isJoy)
        {
            yield return StartCoroutine(ReduceRedBall());
            Debug.Log("isjoy false!");
            IsJoy = false;
        }
        else if (state == isSurprised)
        {
            yield return StartCoroutine(ReduceGreenBall());
           
            IsSurprised = false;
        }
        else if (state == isSad)
        {
            yield return StartCoroutine(ReduceBlueBall());
            
            IsSad = false;
        }


    }

    IEnumerator ReduceRedBall()
    {

        while (redball > 0.1f)
        {
            redball -= Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator ReduceGreenBall()
    {

        while (greenball > 0.1f)
        {
            greenball -= Time.deltaTime;
            yield return null;
        }
    }
       IEnumerator ReduceBlueBall()
    {

        while (blueball > 0.1f)
        {
           blueball -= Time.deltaTime;
            yield return null;
        }
    }   

public LayerMask layer;


    

 


}
