using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Color color;
    public Transform hexMesh;
    public Renderer rend;
    public int x;
    public int y;

    public bool clicked;

    void Start()
    {
        clicked = (Random.value < 0.4);
        hexMesh = this.gameObject.transform.GetChild(0);
        rend = hexMesh.GetComponent<Renderer>();
        SetColor();
    }

    public void SetColor()
    {
        if (clicked)
        {
            color = Color.black;
            rend.material.color = color;
        }
        else
        {
            color = Color.white;
            rend.material.color = color;
        }
    }

    public void ChangeColor()
    {
        clicked = !clicked;
        SetColor();
    }

}

