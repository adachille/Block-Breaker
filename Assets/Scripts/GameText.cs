using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameText : MonoBehaviour {

    public float yOffset;
    private Rect textBox;

    void Start()
    {
        textBox = GetComponent<RectTransform>().rect;
        setPositionBottom();
    }

    internal void setPositionBottom()
    {
        Viewport viewport = FindObjectOfType<Viewport>();
        textBox.y = viewport.GetLowerLeft().y - textBox.height + yOffset;
    }

    internal void setPositionTop()
    {
        Viewport viewport = FindObjectOfType<Viewport>();
        textBox.y = viewport.GetUpperRight().y + textBox.height + yOffset;
    }
}
