using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class PlayArea : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (GameManager.Instance.InspectedCard != null)
            return;

        BaseAction card = eventData.pointerDrag.GetComponent<BaseAction>();

        if (card != null)
        {
            card.used = true;
            card.cardAnimator.SetTrigger("Use");
            card.cardParticle.Play();
            Debug.Log("Card used");
        }
    }
}
