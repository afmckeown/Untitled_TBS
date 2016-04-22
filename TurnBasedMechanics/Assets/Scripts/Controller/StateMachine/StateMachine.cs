// TheLiquidFire.wordpress.com

using FullInspector;
using UnityEngine;


public abstract class StateMachine : BaseBehavior
{
    protected State _currentState;

    public virtual State CurrentState
    {
        get { return _currentState; }
        set { Transition(value); }}
    
    public virtual T GetState<T>() where T : State
    {
        T target = GetComponent<T>();
        if (target == null)
            target = gameObject.AddComponent<T>();
        return target;
    }

    public virtual void ChangeState<T>() where T : State
    {
        CurrentState = GetState<T>();
    }

    protected virtual void Transition(State value)
    {
        if (_currentState == value)
            return;

        if (_currentState != null)
            _currentState.Exit();

        _currentState = value;

        if (_currentState != null)
            _currentState.Enter();
    }

    void Update()
    {
        _currentState.UpdateState();
    }
}