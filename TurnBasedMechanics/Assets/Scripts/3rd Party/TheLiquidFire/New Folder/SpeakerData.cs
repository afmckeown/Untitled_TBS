// TheLiquidFire.wordpress.com

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable] // TODO: see if needed
public class SpeakerData
{
    // pages of text that any one character will speak
    public List<string> messages;

    // reference to a sprite will be used to show who is speaking
    public Sprite speaker;

    // used to determine which corner of the screen the panel will display in
    public TextAnchor anchor;
}
