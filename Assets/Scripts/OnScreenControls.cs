using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // Required when using Event data.

public class OnScreenControls : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    public ControlDirection direction;
    public GameObject playerGameObject;
    private PlayerControllerStiff playerControllerScript;

    private void Start()
    {
        playerControllerScript = playerGameObject.GetComponent<PlayerControllerStiff>();
    }

    public void OnPointerDown(PointerEventData eventData)
	{
        switch(direction) {
            case ControlDirection.Up:
                playerControllerScript.externalVerticalAxis = 1f;
                break;
            case ControlDirection.Down:
                playerControllerScript.externalVerticalAxis = -1f;
                break;
            case ControlDirection.Left:
                playerControllerScript.externalHorizontalAxis = -1f;
                break;
            case ControlDirection.Right:
                playerControllerScript.externalHorizontalAxis = 1f;
                break;
            default:
                break;
        }
	}

    public void OnPointerUp(PointerEventData eventData)
    {
        switch (direction)
        {
            case ControlDirection.Up:
            case ControlDirection.Down:
                playerControllerScript.externalVerticalAxis = 0f;
                break;
            case ControlDirection.Left:
            case ControlDirection.Right:
                playerControllerScript.externalHorizontalAxis = 0f;
                break;
            default:
                break;

        }
    }
}

public enum ControlDirection {
    Up,
    Down,
    Left,
    Right,
}
