using UnityEngine;

public interface Interactable
{
    public string InteractionObject { get; }

    public bool Interact(Interactor interactor);
}
