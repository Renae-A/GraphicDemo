﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAction : MonoBehaviour {

    public Action action;
    public Image icon;
    public Text nameTag;
    public Text descTag;
    public Button button;

    public void SetAction(Action a)
    {
        action = a;
        if (icon)
            icon.sprite = action.icon;
        if (nameTag)
            nameTag.text = action.name;
        if (descTag)
            descTag.text = action.desc;
    }
}
