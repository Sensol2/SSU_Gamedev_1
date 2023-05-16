using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EEmotionState { Joy, Surprised, Sad };

public class EmotionGem : MonoBehaviour
{
    public EEmotionState state;
    
    private CircleCollider2D col;
    private SpriteRenderer ren;
    public float reproduceTime = 3.0f;



    private void Start() {
     col=   gameObject.GetComponent<CircleCollider2D>();
     ren= gameObject.GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            var player = coll.gameObject.GetComponent<Player>();

            Debug.Log("playeffect in emotion gem");
            VFXManager.instance.PlayEffect(this.transform.position, this.state);
            if (this.state == EEmotionState.Joy)
            {
                player.Red++;
            }
            else if (this.state == EEmotionState.Surprised)
            {
                player.Green++;
            }
            else if (this.state == EEmotionState.Sad)
            {
                player.Blue++;
            }
        }
        Debug.Log(this.state.ToString() + " ������ " + coll.gameObject.name + "�� �浹");
       
       col.enabled=false;
       ren.enabled=false;
        StartCoroutine(ReactivateAfterDelay());
    }
    private IEnumerator ReactivateAfterDelay()
    {
    yield return new WaitForSeconds(reproduceTime);

      col.enabled=true;
       ren.enabled=true;
    }

    
}

