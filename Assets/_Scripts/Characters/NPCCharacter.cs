using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NPCCharacter : BaseCharacter {

    [SerializeField]
    protected Sprite NPCSprite;

    public Sprite GetNPCSprite
    {
        get { return NPCSprite; }
    }

    protected override void Init()
    {
        //GameManager.Instance.SwitchNPC(this);
    }
}
