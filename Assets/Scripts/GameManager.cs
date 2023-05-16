using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    public GameObject player;
    private Player playerManager;

	private void Awake()
	{
        if (instance == null)
        {
            instance = this;
        }
	}

	void Start()
    {
        playerManager = player.GetComponent<Player>();
    }

    public void RespawnPlayer()
    {
        Invoke("Respawn", 2f);
    }

    public void Respawn()
    {
        player.transform.position = playerManager.respawnPoint;
        player.SetActive(true);
    }
}

 
