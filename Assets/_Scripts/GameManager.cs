using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null && !_quitting)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    Debug.LogError("Add GameController to the scene!");
                }
                else
                {
                    _instance.Init();
                }
            }
            return _instance;
        }
    }

    private static bool _quitting;
    #endregion

    public enum State : int
    {
        intro = 0,
        choise = 1,
        outro = 2
    }

    public State gameState;
    public DataController data;
    public EncounterGroup currentEncounterGroup;
    public EncounterController encounter;
    public PlayerCharacter player;
    public BaseCharacter NPC;

    public Image NPCImage, LeftStage, RightStage;
    public Text NPCName;
    public Animator LeftStageAnimator, RightStageAnimator;
    public Animator PlayerAnimator, NPCAnimator;

    internal bool Initialized;

    void Awake()
    {
        if (_instance == null)
        {
            Initialized = false;
            _instance = this;
            Init();
        }
        else if (_instance != this)
        {
            Destroy(this);
        }
        gameState = State.intro;
        InitRandomEncounterGroup();
        _quitting = false;
    }

    public void Init()
    {
        if (data == null)
        {
            data = new DataController();
        }

        if (encounter == null)
        {
            encounter = GetComponent<EncounterController>();
        }

        if (player == null)
        {
            player = GetComponent<PlayerCharacter>();
        }

        Initialized = true;
        Debug.Log("GC Init " + Initialized);

    }

    public void InitRandomEncounterGroup()
    {
        gameState = State.intro;
        currentEncounterGroup = data.json.GetEncounterGroup(Random.Range((int)0, data.json.CountEncounterGroups()));
        encounter.InitEncounter(currentEncounterGroup.startEncounter);
    }

    public IEnumerator SwitchStage(Sprite StageImage)
    {
        Debug.Log("Switching Stage to " + StageImage.name);
        LeftStageAnimator.SetBool("OnStage", false);
        RightStageAnimator.SetBool("OnStage", false);
        do
        {
            if (LeftStageAnimator.GetCurrentAnimatorStateInfo(0).IsName("OffStage") &&
                RightStageAnimator.GetCurrentAnimatorStateInfo(0).IsName("OffStage"))
            {
                LeftStage.sprite = StageImage;
                RightStage.sprite = StageImage;
                LeftStageAnimator.SetBool("OnStage", true);
                RightStageAnimator.SetBool("OnStage", true);
            }
            else
            {
                yield return new WaitForEndOfFrame();
            }
        } while (!LeftStageAnimator.GetBool("OnStage") && !RightStageAnimator.GetBool("OnStage"));
        yield return true;
    }

    public IEnumerator SwitchNPC(NPCCharacter NPCScript)
    {
        Debug.Log("Switching NPC to " + NPCScript._characterName);
        NPCAnimator.SetBool("OnStage", false);
        do
        {
            if (NPCAnimator.GetCurrentAnimatorStateInfo(0).IsName("OffStage"))
            {
                NPCImage.sprite = NPCScript.GetNPCSprite;
                NPCName.text = NPCScript._characterName;
                NPCAnimator.SetBool("OnStage", true);
            }
            else
            {
                yield return new WaitForEndOfFrame();
            }
        } while (!NPCAnimator.GetBool("OnStage"));
        yield return true;
    }

    public void HideStage()
    {
        LeftStageAnimator.SetBool("OnStage", false);
        RightStageAnimator.SetBool("OnStage", false);
    }

    public void ShowStage()
    {
        LeftStageAnimator.SetBool("OnStage", true);
        RightStageAnimator.SetBool("OnStage", true);
    }

    public CardGraphicsHandler InspectedCard { get; private set; }

    public void InspectCard(CardGraphicsHandler Card)
    {
        if (InspectedCard != null)
        {
            InspectedCard.ToggleInspection();
        }
        InspectedCard = Card;
    }

    public void ClearInspectedCard ()
    {
        InspectedCard = null;
    }
}
