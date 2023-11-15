using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public KeyCode keyToOpen = KeyCode.E;
    private bool isOpen = false;
    public float openAngle = 90f;
    public float smooth = 2f;


    public float interactionDistance = 2f;

    private Quaternion initialRotation;

    private void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {

        if (Vector3.Distance(transform.position, FirstPersonController.instance.transform.position) <= interactionDistance)
        {

            if (Input.GetKeyDown(keyToOpen))
            {
                if (!isOpen)
                {

                    Quaternion targetRotation = initialRotation * Quaternion.Euler(0, openAngle, 0);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smooth);
                    isOpen = true;
                }
                else
                {

                    transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation, Time.deltaTime * smooth);
                    isOpen = false;
                }
            }
        }
    }
}
