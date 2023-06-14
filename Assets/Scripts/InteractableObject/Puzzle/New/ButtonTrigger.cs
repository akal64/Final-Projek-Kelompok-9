
using UnityEngine;

public class ButtonTrigger : ObjectTrigger
{
    public void Start()
    {
        objectType = PuzzleObjectType.Lever;
    }

    private void Update()
    {
        if (isActivated && objectState == PuzzleObjectState.Off)
        {

            Activate();

        }
        else if (!isActivated && objectState == PuzzleObjectState.Active)
        {

            ShutDown();

        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
            isActivated = true;
            Activate();
            objectState = PuzzleObjectState.Active;
    }
    // private void Oncollisions(Collision2D other)
    // {
    //     if (other.gameObject.tag == "Floating Object")
    //     {
    //         isActivated = true;
    //         Activate();
    //         objectState = PuzzleObjectState.Active;

    //     }

    // }

    private void OnCollisionExit2D(Collision2D other)
    {
            isActivated = false;
            ShutDown();
            objectState = PuzzleObjectState.Off;
    }

    private void Activate()
    {
        SetObjectActivationStatus(true);
    }

    private void ShutDown()
    {
        SetObjectActivationStatus(false);
    }
}
