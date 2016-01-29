using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	#if UNITY_PLAYER
	[SerializeField]
	private int _activeScenes = 0;
	#endif

	[SerializeField]
	public string _activeSceneName;

	private void Awake ()
	{
		if (_activeSceneName == null)
			_activeSceneName = SceneManager.GetActiveScene ().name;
		
		#if UNITY_PLAYER
		// Only in player build

		for (int i = 1; i < _activeScenes; i++)
			SceneManager.LoadScene (i, LoadSceneMode.Additive);

		foreach (Scene _scene in SceneManager.GetAllScenes())
			if (_scene.name == "Dynamic")
			{
				SceneManager.SetActiveScene (_activeScene);

				break;
			}
		#endif
	}
}