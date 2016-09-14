using UnityEngine;
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

    public DataController data;
    public EncounterGroup currentEncounterGroup;
    public EncounterController encounter;
    public PlayerCharacter player;
    public BaseCharacter NPC;

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
        encounter.InitEncounter(0);
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

    public GraphicsHandler InspectedCard { get; private set; }

    public void InspectCard(GraphicsHandler Card)
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
