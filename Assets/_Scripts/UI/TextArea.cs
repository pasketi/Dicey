using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class TextArea : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameManager.Instance.gameState == GameManager.State.outro)
            GameManager.Instance.InitRandomEncounterGroup();
        else
            GameManager.Instance.encounter.showActions();
    }
}
