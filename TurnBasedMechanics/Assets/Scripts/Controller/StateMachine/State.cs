// TheLiquidFire.wordpress.com

using FullInspector;
using UnityEngine;

public abstract class State : BaseBehavior
{
    public virtual void Enter()
    {
        AddListeners();
    }

    public virtual void Exit()
    {
        RemoveListeners();
    }

    public virtual void UpdateState() {}

    protected abstract void AddListeners();


    protected abstract void RemoveListeners();
}