﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class CardGraphicsHandler : MonoBehaviour, IPointerClickHandler
{
    public BaseAction HostCard;
    public Transform Holder;

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
