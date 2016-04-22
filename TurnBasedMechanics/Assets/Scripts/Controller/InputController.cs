using UnityEngine;
using System;
using FullInspector;

public class InputController : BaseBehavior
{
    private readonly string[] _buttons = { "Fire1", "Fire2", "Fire3" };
    private const string MouseAxisX = "Mouse X";
    private const string MouseAxisY = "Mouse Y";

    private const float floatTolerance = 0.00001f;

    Repeater _hor = new Repeater("Horizontal");
    Repeater _ver = new Repeater("Vertical");

    // Update is called once per frame
    void Update ()
    {

        // WASD, Arrows
        int x = _hor.Update();
        int y = _ver.Update();
        if (x != 0 || y != 0)
        {
            this.PostNotification(Notifications.MOVE, new Point(x, y));
        }

        // Mouse Movement
        bool mouseIsMovingHorizontally = Math.Abs(Input.GetAxis(MouseAxisX)) > floatTolerance;
        bool mouseIsMovingVertically = Math.Abs(Input.GetAxis(MouseAxisX)) > floatTolerance;
        if (mouseIsMovingHorizontally || mouseIsMovingVertically)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            this.PostNotification(Notifications.MOUSE_MOVED, mousePosition);
        }

        // Mouse Clicks
        for (int i = 0; i < 3; ++i)
        {
            if (Input.GetButtonDown(_buttons[i]))
            {
                if(Input.touchCount > 0)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                        this.PostNotification(Notifications.MOUSE_MOVED, mousePosition);
                        Debug.Log(mousePosition);
                    }
                }

                this.PostNotification(Notifications.FIRE, i);
            }
        }
    }
}

internal class Repeater
{
    private const float Threshold = 0.5f;
    private const float Rate = 0.25f;
    public float Next { get; private set; }
    public bool Hold { get; private set; }
    public string Axis { get; private set; }

    public Repeater(string axisName)
    {
        Axis = axisName;
    }

    // Manual Update, not called by Unity
    public int Update()
    {
        int retValue = 0;
        int value = Mathf.RoundToInt(Input.GetAxisRaw(Axis));

        if (value != 0)
        {
            if (Time.time > Next)
            {
                retValue = value;
                Next = Time.time + (Hold ? Rate : Threshold);
                Hold = true;
            }
        }
        else
        {
            Hold = false;
            Next = 0;
        }

        return retValue;
    }
}
