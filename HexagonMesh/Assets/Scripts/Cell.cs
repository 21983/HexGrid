using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Color color;

    public Transform hexMesh;
    Renderer rend;

    private bool clicked = true;

    void Start()
    {
        hexMesh = this.gameObject.transform.GetChild(0);
        rend = hexMesh.GetComponent<Renderer>();
        color = Random.ColorHSV();
        rend.material.color = color;
    }
    public void ChangeColor()
    {
        if (!clicked)
        {
            clicked = true;
            color = Random.ColorHSV();
        }
        else
        {
            clicked = false;
            color = Color.white;
        }

            rend.material.color = color;
    }

}

