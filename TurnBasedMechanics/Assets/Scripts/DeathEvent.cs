using UnityEngine;

public class DeathEvent : MonoBehaviour
{
    public delegate void DeathHandler();

    public event DeathHandler Death;

    public delegate void FacingChangedHandler(Directions direction);

    public event FacingChangedHandler FacingChanged;

    public virtual void OnDeath()
    {
        DeathHandler handler = Death;
        if (handler != null) handler();
    }
    
    public virtual void OnFacingChanged(Directions direction)
    {
        FacingChangedHandler handler = FacingChanged;
        if (handler != null) handler(direction);
    }
}