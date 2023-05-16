using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
	static public SceneChange instance;
	public SceneTransition sceneTransition;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}


	public void MoveToIngame()
	{
		StartCoroutine(LoadSceneCoroutine("Ingame"));
	}

	public void MoveToEnding()
	{
		StartCoroutine(LoadSceneCoroutine("Ending"));
	}

	private IEnumerator LoadSceneCoroutine(string sceneName)
	{
		// Fade out
		sceneTransition.FadeOut();

		// Wait for the fade out to complete
		yield return new WaitForSeconds(sceneTransition.transitionTime);

		// Load the new scene
		SceneManager.LoadScene(sceneName);

		// Fade in
		sceneTransition.FadeIn();
	}
}
