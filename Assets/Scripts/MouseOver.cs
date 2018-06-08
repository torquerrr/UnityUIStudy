using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOver : MonoBehaviour, IPointerEnterHandler {

    // for UI elements
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log($"Name of the object is {this.gameObject.name}");
    }

    // for Colliders
    private void OnMouseEnter()
    {
        Debug.Log($"Name of the OObject is {this.gameObject.name}");
    }
}
