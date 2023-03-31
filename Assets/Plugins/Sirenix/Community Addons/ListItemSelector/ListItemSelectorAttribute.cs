﻿#if UNITY_EDITOR
using System;

public class ListItemSelectorAttribute : Attribute
{
    public string SetSelectedMethod;

    public ListItemSelectorAttribute(string setSelectedMethod)
    {
        this.SetSelectedMethod = setSelectedMethod;
    }
}
#endif