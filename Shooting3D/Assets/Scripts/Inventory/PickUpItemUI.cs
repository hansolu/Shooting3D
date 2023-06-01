using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItemUI : MonoBehaviour
{
    Image img = null;

    public void Init()
    {
        if (img == null)
        {
            img = GetComponent<Image>();
        }
    }

    public void SetImage(Sprite _spr)
    {        
        img.sprite = _spr;
    }
}
