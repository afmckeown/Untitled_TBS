using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;

public class WASDCameraExtension : BasePC2D
{
    public float ViewDistance = 2f;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            ProCamera2D.ApplyInfluence(new Vector2(0, ViewDistance));
        }
        if (Input.GetKey(KeyCode.A))
        {
            ProCamera2D.ApplyInfluence(new Vector2(-ViewDistance, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
             ProCamera2D.ApplyInfluence(new Vector2(0, -ViewDistance));
        }
        if (Input.GetKey(KeyCode.D))
        {
            ProCamera2D.ApplyInfluence(new Vector2(ViewDistance, 0));
           
        }
    }
}


