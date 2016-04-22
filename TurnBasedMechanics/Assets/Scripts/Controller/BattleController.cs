using System;
using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using Tiled2Unity;


public class BattleController : StateMachine
{
    [SerializeField]
    public Player Player { get; private set; }

    public Player Enemy { get; private set; }

    public Player Neutral { get; private set; }

    public Board Board { get; private set; }

    public bool SkipConversation { get; private set; }

    public static BattleController Instance { get; private set; }

    public Behavior_Tree.BehaviorTree ZombieBT { get; private set; }

    //public AbilityMenuPanelController AbilityMenuPanelController
    //{
    //    get;
    //    private set;
    //}

    //public MyGui GuiController { get; private set; }
    
    [HideInInspector]
    public Point Selected { get; set; }

    [HideInInspector]
    public Pawn CurrentPawn { get; set; }

    new void Awake()
    {
        base.Awake();
        Instance = this;
    }
  
    void Start ()
    {
        ChangeState<InitBattleState>();
	}
}
