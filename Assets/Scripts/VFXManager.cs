using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    static public VFXManager instance;
    public GameObject[] gemEffect;

	void Awake()
	{
        if (instance == null)
        {
            instance = this;
        }
	}

    //enum EEmotionState { Joy, Surprised, Sad };
    public void PlayEffect(Vector3 position, EEmotionState state)
    {
        Debug.Log("PlayEffect");
        Instantiate(gemEffect[(int)state], position, Quaternion.identity);   
    }
}
