using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Rigidbody2D npc;
    private static int columns = 5;
    private static int rows = 4;
    public Vector2 startPosition = new Vector2(-2.0f, 8.0f);
    public int gridSize = 1;
    private Rigidbody2D[,] enemyList = new Rigidbody2D[columns,rows];

    private void Awake()
    {
        for(int i=0; i < columns; i++)
        {
            for(int j=0; j < rows; j++)
            {
                Rigidbody2D enemy = Instantiate(npc, new Vector3(startPosition.x+(i*gridSize), startPosition.y - (j * gridSize)), transform.rotation, transform) as Rigidbody2D;
                enemyList[i,j] = enemy;

            }
        }
    }
}
