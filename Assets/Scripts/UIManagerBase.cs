using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerBase : MonoBehaviour {

	public void OnGoBack()
	{
		SceneManager.LoadScene("Main");
	}

	public void OnLoadScene(string sceneName)
	{
		if (sceneName == "")
		{
			// Load the first scene.
			SceneManager.LoadScene(1);
		}
		
		SceneManager.LoadScene(sceneName);
	}
}
