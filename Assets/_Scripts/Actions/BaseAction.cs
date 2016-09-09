using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class BaseAction : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Text tTitle, tShort, tFull;
    private string shortDescription = "";

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
        Debug.Log(gameObject.name + " ended Drag");
        if (!used)
            cardAnimator.SetBool("Dragged", false);
    }

    public void Destroy()
    {
        //gameObject.SetActive(false);
    }
    #endregion

    public void SetActionTexts(ActionData action)
    {
        tTitle.text = action.title;

        Debug.Log(action.skillCheckType.ToString());

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

        Debug.Log(action.challengeType.ToString());

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
}
