using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler {

    [SerializeField] private Animator buttonAnimation;

    [SerializeField] private SFXSoundController soundController;

    private bool isPointerDown = false;
    private void Awake() {
        buttonAnimation = GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (!isPointerDown && buttonAnimation != null) {
            buttonAnimation.SetTrigger("onHover");
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (!isPointerDown && buttonAnimation != null) {
            buttonAnimation.SetTrigger("onLeave");
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        isPointerDown = true;
        if (buttonAnimation != null)
            buttonAnimation.SetTrigger("onClicked");
        soundController.ClickSound();
    }

    public void OnPointerUp(PointerEventData eventData) {
        isPointerDown = false;
    }

}
