using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    private GameObject player;

    private Player playerManager;
    void Start()
    {
      playerManager=player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void RespawnPlayer()
    {
        Invoke("Respawn", 2f);
     
    }

    private void Respawn()
    {
        player.transform.position = playerManager.respawnPoint.position;
        player.SetActive(true);
    }
}

 
