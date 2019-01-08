using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HexGrid : MonoBehaviour {
    public int width = 15;
    public int height = 15;

    public GameObject playerPrefab;
    public GameObject player;
    public Cell cellPrefab;


    private int playerStartPosX = 2;
    private int playerStartPosY = 8;

    public Text cellLabelPrefab;
    Canvas gridCanvas;

    HexMesh hexMesh;

    public Cell[,] cells;


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
        player = Instantiate(playerPrefab);
        player.transform.position = cells[playerStartPosX, playerStartPosY].transform.position;
        player.GetComponent<PlayerMovement>().PlayerX = playerStartPosX;
        player.GetComponent<PlayerMovement>().PlayerY = playerStartPosY;
        hexMesh = GetComponentInChildren<HexMesh>();
        //Camera.main.transform.position = new Vector3(width *5, height*15, 40);
        //Camera.main.orthographicSize = height / 15;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit info;
            if (Physics.Raycast(ray, out info, Mathf.Infinity))
            {
                if (info.collider.transform.tag == "Cell")
                {
                    Debug.Log("Mwoan");
                    var cell = info.collider.transform.parent.GetComponent<Cell>();
                    cell.ChangeColor();
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit info;
            if (Physics.Raycast(ray, out info, Mathf.Infinity))
            {

                var cell = info.collider.GetComponent<Cell>();
                var playerMove = player.GetComponent<PlayerMovement>();
                playerMove.CreatePath(cell.x,cell.y);
                playerMove.MovePlayer(new Vector3(cell.transform.position.x, cell.transform.position.y, cell.transform.position.z));

            }
        }

     }

    void CreateCell(int x, int z)
    {
        Vector3 position;
        position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f) *1.05f; 
        position.y = 0f;
        position.z = z * (HexMetrics.outerRadius * 1.5f)* 1.05f;

        cells[x,z] = Instantiate<Cell>(cellPrefab);
        cells[x, z].x = x;
        cells[x, z].y = z;
        cells[x,z].transform.SetParent(transform, false);
        cells[x,z].transform.localPosition = position;

    }



}
