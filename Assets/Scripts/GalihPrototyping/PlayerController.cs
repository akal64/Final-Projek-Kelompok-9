using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stat")]
    [SerializeField] private float moveSpeed = 10f;

    [Header("Modules")]
    [SerializeField] private GameObject modulesHolder;
    [SerializeField] private List<GameObject> modulesList = new List<GameObject>();

    [SerializeField] private GameObject activeModuleGameObject;

    [SerializeField] private int previousModuleIndex = 0;
    [SerializeField] private int activeModuleIndex = 0;
    [SerializeField] private int nextModuleIndex = 0;


    [Header("Player Component")]
    [SerializeField] private Rigidbody2D playerRigidbody2D;
	[SerializeField] private GameObject player;

    private Vector2 movementDirection;

    private void Start()
    {
        foreach (Transform child in modulesHolder.transform)
        {
            modulesList.Add(child.gameObject);
        }

        PreviousModuleCalc();
        NextModuleCalc();

    }

    private void Update()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movementDirection = new Vector2(moveX, moveY).normalized;

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SelectModule(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectModule(1);
        }

        // if (Input.GetKeyDown(KeyCode.Alpha2))
        // {
        //     SelectModule(2);
        // }

        // if (Input.GetKeyDown(KeyCode.Alpha3))
        // {
        //     SelectModule(3);
        // }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SelectModule(previousModuleIndex);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            SelectModule(nextModuleIndex);
        }

    }

    private void FixedUpdate()
    {
        playerRigidbody2D.velocity = movementDirection * moveSpeed;
        if (movementDirection.x > 0)
        {
            player.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (movementDirection.x < 0)
        {
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void SelectModule(int index)
    {
        activeModuleIndex = index;
        activeModuleGameObject = modulesList[activeModuleIndex];

        if (activeModuleGameObject != null)
        {

            foreach (GameObject module in modulesList)
            {
                module.SetActive(false);
            }

            activeModuleGameObject.SetActive(true);
        }

        NextModuleCalc();
        PreviousModuleCalc();

    }

    private void NextModuleCalc()
    {

        nextModuleIndex = activeModuleIndex + 1;

        if (nextModuleIndex > modulesList.Count - 1)
        {
            nextModuleIndex = 0;
        }
    }

    private void PreviousModuleCalc()
    {

        previousModuleIndex = activeModuleIndex - 1;

        if (previousModuleIndex < 0)
        {
            previousModuleIndex = modulesList.Count - 1;
        }

    }
}
