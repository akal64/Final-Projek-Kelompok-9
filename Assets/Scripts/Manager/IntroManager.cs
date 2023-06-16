using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [SerializeField] private SceneTransition transition;

    public void PlayMain () {
		transition.LoadScene("Main");
	}
    
}
