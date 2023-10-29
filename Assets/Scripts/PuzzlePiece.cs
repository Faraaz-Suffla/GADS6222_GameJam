using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _pickUpClip, _dropClip;

    private bool _dragging;
    private Vector2 _offset, _originalPosition;
    private PuzzleSlot _currentSlot;

    public void Init(PuzzleSlot slot)
    {
        _renderer.sprite = slot.Renderer.sprite;
        _currentSlot = slot;
    }

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
        _dragging = false;
        _source.PlayOneShot(_dropClip);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PuzzleSlot slot = other.GetComponent<PuzzleSlot>();
        if (slot != null && !slot.IsOccupied())
        {
            MoveToSlot(slot);
        }
    }

    private void MoveToSlot(PuzzleSlot slot)
    {
        _currentSlot.RemovePiece();
        _currentSlot = slot;
        _currentSlot.PlacePiece(this);
        transform.position = slot.transform.position;
    }

    private Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
