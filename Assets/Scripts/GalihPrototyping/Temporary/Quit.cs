using UnityEditor;
using UnityEngine;

public class Quit : MonoBehaviour
{
	public void QuitGame () {
		#if UNITY_EDITOR
			EditorApplication.ExitPlaymode();
		#else
			Application.Quit();
		#endif
	}
}
