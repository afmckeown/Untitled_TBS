//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//public abstract class BaseAbilityMenuState : PlayerTurnState
//{
//    protected string menuTitle;
//    protected List<string> menuOptions;

//    public override void Enter()
//    {
//        base.Enter();
        
//        LoadMenu();
//    }

//    public override void Exit()
//    {
//        base.Exit();
//        //AbilityMenuPanelController.Hide();
//    }

//    protected override void OnFire(object sender, object args)
//    {
//        if ((int)args == 0)
//            Confirm();
//        else
//            Cancel();
//    }

//    protected override void OnMove(object sender, object args)
//    {
//        var point = args as Point;
//        if (point.X > 0 || point.Y < 0)
//            AbilityMenuPanelController.Next();
//        else
//            AbilityMenuPanelController.Previous();
//    }

//    protected abstract void LoadMenu();
//    protected abstract void Confirm();
//    protected abstract void Cancel();
//}