//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//public class CommandSelectionState : BaseAbilityMenuState
//{
//    protected override void LoadMenu()
//    {
//        if (menuOptions == null)
//        {
//            menuTitle = "Commands";
//            menuOptions = new List<string>(3);
//            menuOptions.Add("Move");
//            menuOptions.Add("Action");
//            menuOptions.Add("Wait");
//        }

//        AbilityMenuPanelController.Show(menuTitle, menuOptions);
//        AbilityMenuPanelController.SetLocked(0, false); //turn.hasUnitMoved);
//        AbilityMenuPanelController.SetLocked(1, false);//turn.hasUnitActed);
//    }

//    protected override void Confirm()
//    {
//        switch (AbilityMenuPanelController.selection)
//        {
//            case 0: // Move
//                Owner.ChangeState<MovePawnState>();
//                break;
//            case 1: // Action
//                Owner.ChangeState<CategorySelectionState>();
//                break;
//            case 2: // Wait
//                Owner.ChangeState<SelectPawnState>();
//                break;
//        }
//    }

//    protected override void Cancel()
//    {
//        ////if (turn.hasUnitMoved && !turn.lockMove)
//        //if (CurrentPawn.HasEnoughAPToMove)
//        //{
//        //    turn.UndoMove();
//        //    abilityMenuPanelController.SetLocked(0, false);
//        //    SelectTile(turn.actor.tile.pos);
//        //}
//        //else
//        //{
//        //    owner.ChangeState<ExploreState>();
//        //}
//    }

//}