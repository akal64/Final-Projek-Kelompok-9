using UnityEngine;

public class FloatingObject : MonoBehaviour, Interactable {
    [SerializeField] private string objectName;

    public string InteractionPrompt => objectName;

    public string InteractionObject => throw new System.NotImplementedException();

    public bool Interact(Interactor interactor) {
        Debug.Log("You interact the object");
        return true;
    }
}
