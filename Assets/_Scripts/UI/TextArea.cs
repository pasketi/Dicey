using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class TextArea : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.encounter.showActions();
    }
}
