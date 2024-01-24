using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool _dragging = true;

    private Vector2 _offset;

    public static bool mouseButtonReleased;

    public GameObject pointer;

    private void Awake()
    {
        pointer.SetActive(false);
    }

    private void OnMouseDown()
    {
        _offset = GetMousePos() - (Vector2)transform.position;
    }

    private void OnMouseDrag()
    {
        if (!_dragging) return;

        var mousePosition = GetMousePos();

        transform.position = mousePosition - _offset;

        pointer.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    private void OnMouseUp()
    {
        mouseButtonReleased = true;
        pointer.SetActive(false);
    }

    private Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}