using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSystem : MonoBehaviour
{
    private bool _isDraged = false;
    private DragableObject _dragableObject;
    private void FixedUpdate()
    {
        if (_isDraged)
        {
            if(_dragableObject == null)
            {
                _isDraged = false;
                return;
            }

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            _dragableObject.GetComponent<Rigidbody2D>().position = mousePos2D;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(_isDraged)
            {
                _isDraged = false; 
                return;
            }
                
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if(hit.collider != null)
            {
                if (hit.collider.TryGetComponent<DragableObject>(out DragableObject dragableObject))
                {
                    _dragableObject = dragableObject;
                    _isDraged = true;
                }
            }
            
        }
    }
}
