using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class GraphicsHandler : MonoBehaviour, IPointerClickHandler
{
    public BaseAction HostCard;
    public Transform Holder;
    public Image NPC, LeftStage, RightStage;
    public Animator LeftStageAnimator, RightStageAnimator;
    public Animator PlayerAnimator, NPCAnimator;

    private RectTransform _myRect;
    private RectTransform _inspectArea;

    private float _inspectTransitionTime = 1f;
    private float _currentTransitionDuration;


    void Awake()
    {
        _currentTransitionDuration = 1f;

        _myRect = HostCard.GetComponent<RectTransform>();
        _inspectArea = GameObject.Find("InspectArea").GetComponent<RectTransform>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ToggleInspection();
    }

    public void SwitchStage(int id)
    {
        if (LeftStageAnimator.GetBool("OnStage") == false)
        {
            Debug.Log("Switching stage to " + id);
        }
        else
        {
            Debug.LogError("COULD NOT SWITCH STAGE! STAGE IS VISIBLE!");
        }
    }

    public void SwitchNPC(int id)
    {
        if (NPCAnimator.GetBool("OnStage") == false)
        {
            Debug.Log("Switching NPC to " + id);
        }
        else
        {
            Debug.LogError("COULD NOT SWITCH NPC! NPC IS VISIBLE!");
        }
    }

    public void HideStage()
    {
        if (LeftStageAnimator.GetBool("OnStage") == true)
            LeftStageAnimator.Play("FromStage");
        if (RightStageAnimator.GetBool("OnStage") == true)
            RightStageAnimator.Play("FromStage");
    }

    public void ShowStage()
    {
        if (LeftStageAnimator.GetBool("OnStage") == false)
            LeftStageAnimator.Play("ToStage");
        if (RightStageAnimator.GetBool("OnStage") == false)
            RightStageAnimator.Play("ToStage");
    }

    public void HideNPC()
    {
        if (NPCAnimator.GetBool("OnStage") == true)
            NPCAnimator.Play("FromStage");
    }

    public void ShowNPC()
    {
        if (NPCAnimator.GetBool("OnStage") == false)
            NPCAnimator.Play("ToStage");
    }

    public void ToggleInspection()
    {
        if (HostCard.cardAnimator.GetBool("Show") == true)
        {
            _currentTransitionDuration = 0f;
            if (GameManager.Instance.InspectedCard != this)
            {
                GameManager.Instance.InspectCard(this);
                HostCard.transform.SetParent(_inspectArea);
                HostCard.cardAnimator.SetBool("Inspected", true);
            }
            else if (GameManager.Instance.InspectedCard == this)
            {
                GameManager.Instance.ClearInspectedCard();
                HostCard.transform.SetParent(Holder.transform);
                HostCard.cardAnimator.SetBool("Inspected", false);
            }
        }
    }

    void Update()
    {
        if (_currentTransitionDuration != _inspectTransitionTime)
        {
            _myRect.localPosition = Vector2.Lerp(_myRect.localPosition, Vector2.zero, _currentTransitionDuration);
            _myRect.localRotation = Quaternion.Euler(Vector2.Lerp(_myRect.localRotation.eulerAngles, Vector2.zero, _currentTransitionDuration));
        }
        if (_currentTransitionDuration == _inspectTransitionTime)
        {
            _myRect.localPosition = Vector2.zero;
        }

        if (_currentTransitionDuration > _inspectTransitionTime)
        {
            _currentTransitionDuration = _inspectTransitionTime;
        }
        else if (_currentTransitionDuration < _inspectTransitionTime)
        {
            _currentTransitionDuration += Time.deltaTime;
        }
    }
}
