using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [SerializeField] SceneTransition transition;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)){
            transition.LoadScene("Main");
        }
    }
}
