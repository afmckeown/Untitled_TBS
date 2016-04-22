using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CutSceneState : PlayerTurnState
{
    private const string ConversationPath = "Conversations/IntroScene";

    ConversationController conversationController;
    ConversationData data;

    protected override void Awake()
    {
        base.Awake();
        conversationController = Owner.GetComponentInChildren<ConversationController>();
        data = Resources.Load<ConversationData>(ConversationPath);
    }

    public override void Exit()
    {
        base.Exit();
        if (data)
            Resources.UnloadAsset(data);
    }

    public override void Enter()
    {
        base.Enter();
        conversationController.Show(data);
    }

    protected override void AddListeners()
    {
        base.AddListeners();        
        this.AddObserver(OnCompleteConversation, Notifications.CONVERSATION_COMPLETED);
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        this.RemoveObserver(OnCompleteConversation, Notifications.CONVERSATION_COMPLETED);
    }

    protected override void OnFire(object sender, object args)
    {
        base.OnFire(sender, args);
        conversationController.Next();
    }

    void OnCompleteConversation(object sender, object args)
    {
        Debug.Log("here2");
        Owner.ChangeState<InitPlayerTurnState>();
    }
}
