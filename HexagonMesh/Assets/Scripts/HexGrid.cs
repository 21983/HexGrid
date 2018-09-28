using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HexGrid : MonoBehaviour {
    public int width = 6;
    public int height = 6;

    public Cell cellPrefab;

    public Text cellLabelPrefab;
    Canvas gridCanvas;

    HexMesh hexMesh;

    Cell[,] cells;



    void Awake()
    {
        gridCanvas = GetComponentInChildren<Canvas>();

        gridCanvas = GetComponentInChildren<Canvas>();

        cells = new Cell[height , width];

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                CreateCell(i, j);
            }
        }
        hexMesh = GetComponentInChildren<HexMesh>();
        Camera.main.transform.position = new Vector3(width *5, height*15, 40);
        Camera.main.orthographicSize = height / 15;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit info;
            if (Physics.Raycast(ray, out info, Mathf.Infinity))
            {
                Debug.Log("Mwoan");
                var cell = info.collider.transform.parent.GetComponent<Cell>();
                cell.ChangeColor();
            }
        }
    }


    void CreateCell(int x, int z)
    {
        Vector3 position;
        position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f); 
        position.y = 0f;
        position.z = z * (HexMetrics.outerRadius * 1.5f);

        Cell cell = cells[x,z] = Instantiate<Cell>(cellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;

        Text label = Instantiate<Text>(cellLabelPrefab);
        label.rectTransform.SetParent(gridCanvas.transform, false);
        label.rectTransform.anchoredPosition =
            new Vector2(position.x, position.z);
        label.text = x.ToString() + "\n" + z.ToString();
    }



}
