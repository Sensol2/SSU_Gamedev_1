using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{





    private void OnTriggerEnter2D(Collider2D other)
    {    if(other.gameObject.tag=="Player")
        {
            var playerManager= other.gameObject.GetComponent<Player>();
            playerManager.respawnPoint= this.transform.position;
            Destroy(this.gameObject);
        }
    }
}
