using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public int PlayerX;
    public int PlayerY;



    Transform[] path;
    public Transform cell;
    private HexGrid hexGrid;
    void Start()
    {
    }
    void Update()
    {
       
    }
    public void CreatePath(int x, int y)
    {
        
    }
    public void MovePlayer(Vector3 target)
    {
        
        gameObject.transform.position = target;
    }
    private float CalcDistance(int currentX, int currentY, int x, int y)
    {
        //float distanceX = Mathf.Abs(hexGrid.cells[currentX, currentY].transform.position.x - hexGrid.cells[x, y].transform.position.x);
        //float distanceY = Mathf.Abs(hexGrid.cells[currentX, currentY].transform.position.y - hexGrid.cells[x, y].transform.position.y);
        int distanceX = Mathf.Abs(currentX - x);
        int distanceY = Mathf.Abs(currentY - y);
        float distance = distanceX + distanceY;


        return distance;
    }
    private void GetShortestDistance(int currentX, int CurrentY, int targetX, int targetY)
    {
        float[] distances = new float[5];
        distances[0] = CalcDistance(currentX, CurrentY, targetX + 1, targetY);
        distances[1] = CalcDistance(currentX, CurrentY, targetX - 1, targetY);
        distances[2] = CalcDistance(currentX, CurrentY, targetX, targetY + 1);
        distances[3] = CalcDistance(currentX, CurrentY, targetX - 1, targetY + 1);
        distances[4] = CalcDistance(currentX, CurrentY, targetX - 1, targetY - 1);
        distances[5] = CalcDistance(currentX, CurrentY, targetX, targetY - 1);
        float currentHex = distances[0];

        for (int i = 0; i<distances.Length; i++)
        {
            if(currentHex < distances[i])
            {
                currentHex = distances[i];
            }
        }





        
    }
}
