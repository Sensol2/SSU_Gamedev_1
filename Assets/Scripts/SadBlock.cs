using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadBlock : MonoBehaviour
{

    private BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = transform.parent.GetComponent<BoxCollider2D>();

        //   GetComponentInParent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var player = other.GetComponent<Player>();
            if (player.state == EPlayerState.Sad)
            {

                boxCollider2D.enabled = false;
                //Physics2D.IgnoreCollision(other.GetComponentInParent<BoxCollider2D>(),coll,true);

                Debug.Log("1");

            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var player = other.GetComponent<Player>();
            if (player.state == EPlayerState.Sad)
            {
                boxCollider2D.enabled = false;
            }

            else if (player.state != EPlayerState.Sad)
            {

                boxCollider2D.enabled = true;
            }

        }


    }
}
//    private void OnTriggerExit2D(Collider2D other)
//    {
//        if (other.gameObject.tag == "Player")
//        {
//            var player = other.GetComponent<Player>();
//            if ( !player.isSad)
//            {
//                boxCollider2D.enabled = true;
//            }
//        }
//    }
//}