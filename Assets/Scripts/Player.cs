using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EPlayerState { IDLE, Joy, Surprised, Sad };

public class Player : MonoBehaviour
{
    public Sprite[] sprites;
    SpriteRenderer spriteRenderer;
    public EPlayerState state;

    [Header("기쁨상태 파라미터")]
    public float JoymaxSpeed;
    public float JoyjumpPower;

    [Header("놀람상태 파라미터")]
    public float surpJumpPower;
    public float surpSpeed;

    [Header("슬픔상태 파라미터")]


    [Header("열쇠 가지고있는지")]
    public bool isHaveKey = false;

    public Vector3 respawnPoint;

    private Moving moving;

    [Header("상태변화")]
    [SerializeField]
    public float redball = 0;
    public float greenball = 0;
    public float blueball = 0;

    float delta = 0.0f;

    void Awake()
    {
        moving = GetComponent<Moving>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        respawnPoint = this.transform.position;
        InvokeCoroutine();
    }

    public void InvokeCoroutine()
    {
        StartCoroutine(ReduceBallBySec(0.3f));
    }

	private void Update()
    {
        if (redball >= 5)
            this.state = EPlayerState.Joy;

        else if (greenball >= 5)
            this.state = EPlayerState.Surprised;

        else if (blueball >= 5)
            this.state = EPlayerState.Sad;

        if (redball < 1.0f && greenball < 1.0f && blueball < 0.1f)
            this.state = EPlayerState.IDLE;

        if (state == EPlayerState.IDLE)
        {
            spriteRenderer.sprite = sprites[(int)EPlayerState.IDLE];
        }

        if (state == EPlayerState.Joy)
        {
            spriteRenderer.sprite = sprites[(int)EPlayerState.Joy];
            moving.dashInputHandler += moving.HandleDashInput;
        }
        else
        {
            moving.dashInputHandler -= moving.HandleDashInput;
        }

        if (state == EPlayerState.Surprised)
        {
            spriteRenderer.sprite = sprites[(int)EPlayerState.Surprised];
            moving.ChangeJumpScale(20.0f);
        }
        else
        {
            moving.RestoreJumpScale();
        }


        if (state == EPlayerState.Sad)
        {
            spriteRenderer.sprite = sprites[(int)EPlayerState.Sad];
        }

    }

    public void Die()
    {
        SetDefaultState();
        GameManager.instance.RespawnPlayer();
        gameObject.SetActive(false);
    }

    private void SetDefaultState()
    {
        redball = 0;
        blueball = 0;
        greenball = 0;
    }

    IEnumerator ReduceBallBySec(float sec) // 모든 공 개수 감소
	{
        if (redball > 0)
            redball -= sec;
        if (greenball > 0)
            greenball -= sec;
        if (blueball > 0)
            blueball -= sec;
        yield return new WaitForSeconds(sec);
        StartCoroutine(ReduceBallBySec(sec));
	}
}
