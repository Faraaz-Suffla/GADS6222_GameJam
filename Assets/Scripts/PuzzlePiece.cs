using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _pickUpClip, _dropClip;

    private bool _dragging;

    private Vector2 _offset, _originalPosition;

    private void Awake()
    {
        _originalPosition = transform.position;

}

private void Update()
    {
        if (_dragging)
        {
            var mousePosition = GetMousePos();
            transform.position = mousePosition - _offset;

            _offset = GetMousePos() - (Vector2)transform.position;
        }
    }

     void OnMouseDown()
    {
        _dragging = true;
        _source.PlayOneShot(_pickUpClip);
    }

    void OnMouseUp()
    {
        transform.position = _originalPosition;
        _dragging = false;
        _source.PlayOneShot(_dropClip);
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
