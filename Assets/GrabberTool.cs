using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabberTool : MonoBehaviour
{
    [SerializeField] Animator grabtool;
    private float setExtended = 1;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            if (setExtended == 1){
                grabtool.SetFloat ("extended", 1);
                setExtended = -1;
            } else {
                grabtool.SetFloat ("extended", -1);
                setExtended = 1;    
            }

        }
        
    }
}
