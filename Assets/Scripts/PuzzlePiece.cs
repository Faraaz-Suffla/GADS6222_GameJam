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

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        foreach (Collider2D collider in hitColliders)
        {
            PuzzleSlot slot = collider.GetComponent<PuzzleSlot>();
            if (slot != null && !slot.IsOccupied())
            {
                MoveToSlot(slot);
                return; // Exit loop after placing the piece in the first valid slot
            }
        }

        transform.position = _originalPosition; // Return to original position if not dropped on a valid slot
    }

    private void MoveToSlot(PuzzleSlot slot)
    {
        _currentSlot.RemovePiece(); // Remove piece from the current slot, if any
        _currentSlot = slot;
        _currentSlot.PlacePiece(this); // Place the piece in the new slot
        transform.position = slot.transform.position; // Snap the piece to the slot
    }

    private Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
