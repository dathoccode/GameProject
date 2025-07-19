using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    //
    private RectTransform background;
    private RectTransform handle;
    private Vector2 inputVector;

    public Vector2 Direction => inputVector;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        // Convert the screen point to a local point in the background RectTransform so the handle can move relative to its background
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            background, eventData.position, eventData.pressEventCamera, out pos);

        //Clamp the length of the vector (of the handle) to the radius of the background minus the radius of the handle because we don't want the handle to go outside the background
        pos = Vector2.ClampMagnitude(pos, background.sizeDelta.x / 2 - handle.sizeDelta.x);

        //move the handle to the new position
        handle.anchoredPosition = pos;

        //set the input vector to use later
        inputVector = pos / (background.sizeDelta.x / 2 - handle.sizeDelta.x);
    }

    public void OnPointerDown(PointerEventData eventData) => OnDrag(eventData);

    public void OnPointerUp(PointerEventData eventData)
    {
        // Reset the handle position and input vector when the pointer is released
        handle.anchoredPosition = Vector2.zero;
        inputVector = Vector2.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<RectTransform>();
        handle = transform.Find("JoystickHandle").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
