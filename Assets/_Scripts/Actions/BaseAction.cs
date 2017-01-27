using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class BaseAction : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    
    public Text tTitle, tShort, tFull;
    private string shortDescription = "";
    private int actionID = -1;

    #region Control
    public GraphicsHandler cardStuff;
    public Animator cardAnimator;
    public ParticleSystem cardParticle;
    public bool used = false;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (GameManager.Instance.InspectedCard != null)
            return;

        cardAnimator.SetBool("Dragged", true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (GameManager.Instance.InspectedCard != null)
            return;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (GameManager.Instance.InspectedCard != null)
            return;
        if (!used)
        {
            cardAnimator.SetBool("Dragged", false);
        }
    }

    public int GetActionID ()
    {
        return actionID;
    }

    public void Destroy()
    {
        resetAnimator();
        //gameObject.SetActive(false);
    }
    #endregion

    public void SetAction(ActionData action)
    {
        resetAnimator();
        actionID = action.ID;
        tTitle.text = action.title;

        if (action.skillCheckType == SkillCheckType.ABILITYCHECK)
        {
            shortDescription = ((SkillID)action.skillCheckID).ToString() + " check\n";
        } else if (action.skillCheckType == SkillCheckType.SKILLCHECK)
        {
            shortDescription = ((AbilityID)action.skillCheckID).ToString() + " check\n";
        } else if (action.skillCheckType == SkillCheckType.AUTOFAIL || action.skillCheckType == SkillCheckType.AUTOSUCCESS)
        {
            shortDescription = "No Check\n";
        }

        if (action.challengeType == ChallengeType.DC)
        {
            shortDescription += "DC " + action.challengeTargetID;
        }
        else if (action.challengeType == ChallengeType.NPCSKILL)
        {
            shortDescription += "Vs. " + ((SkillID)action.challengeTargetID).ToString();
        }
        else if (action.challengeType == ChallengeType.NPCDEFENCE)
        {
            shortDescription += "Vs. " + ((DefenceID)action.challengeTargetID).ToString();
        }
        tShort.text = shortDescription;
        tFull.text = action.description;
    }

    public void resetAnimator()
    {
        used = false;
        cardAnimator.SetBool("Use", false);
        cardAnimator.SetBool("Dragged", false);
        cardAnimator.SetBool("Inspected", false);
    }
}
