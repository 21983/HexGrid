using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Color color;
    public Transform hexMesh;
    Renderer rend;

    private bool clicked;

    void Start()
    {
        clicked = (Random.value < 0.5);
        hexMesh = this.gameObject.transform.GetChild(0);
        rend = hexMesh.GetComponent<Renderer>();
        SetColor();
        rend.material.color = color;
    }

    public void SetColor()
    {
        if (!clicked)
        {
            color = Color.black;
        }
        else
        {
            color = Color.white;
        }
    }

    public void ChangeColor()
    {
        clicked = !clicked;
        SetColor();
        rend.material.color = color;
    }

}

