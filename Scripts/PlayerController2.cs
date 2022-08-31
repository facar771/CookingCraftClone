using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController2 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform joystick;

    public void OnPointerDown(PointerEventData ped)
    {
        ChangeJoy(ped.position);
    }

    public void OnDrag(PointerEventData ped)
    {
        ChangeJoy(ped.position);
    }

    public void OnPointerUp(PointerEventData ped)
    {
        ResetJoy();
    }

    public void ChangeJoy(Vector2 pedPos)
    {
        Vector2 diff = pedPos - (Vector2)GetComponent<RectTransform>().position;
    }

    public void ResetJoy()
    {
        joystick.localPosition = Vector2.zero;
    }
}
