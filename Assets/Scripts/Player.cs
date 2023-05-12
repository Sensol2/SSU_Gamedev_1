using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("기본이동")]
   public float maxSpeed;
    public float jumpPower;
    Rigidbody2D rigid;

    public Vector3 respawnPoint;

    [SerializeField] private AudioSource jumpSoundEffect;

    public GameObject manager;



[Header("상태변화")]
[SerializeField]
   private float redball = 0;
    public float Red 
    { get 
        { 
            return redball; 
        } 
      set 
        { 
            redball = value;
            if (redball >= 5)
                isJoy = true;//기쁨상태
            //기쁨상태가 되면 점점 줄어드는 메서드
            //기쁨상태가 0
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
                isSurprised= true;//놀란상태
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
    bool isSad = false;
    bool isSurprised = false;



    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        manager=GameObject.Find("GameManager");
        respawnPoint=this.transform.position;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        if (rigid.velocity.x > maxSpeed) //���� �̵�
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed * (-1)) // ���� �̵�
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space)) // ����
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumpSoundEffect.Play();
        }

    }




    public void Die()
    {
      var Manager= manager.GetComponent<GameManager>();
      Manager.RespawnPlayer();
        gameObject.SetActive(false);
        

    }





}
