using UnityEngine;

public class LeverInteract : MonoBehaviour, Interactable {
    [SerializeField] private string objectName;

    public string InteractionPrompt => objectName;

    public string InteractionObject => throw new System.NotImplementedException();

    public bool Interact(Interactor interactor) {
        Debug.Log("Lever!");
        return true;
    }
}
