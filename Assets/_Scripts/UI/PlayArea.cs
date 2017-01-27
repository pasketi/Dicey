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
            GameManager.Instance.encounter.useAction(card.GetActionID());
            card.used = true;
            card.cardAnimator.SetBool("Use", true);
            card.cardAnimator.Play("UseCard");
            card.cardParticle.Play();
        }
    }
}
