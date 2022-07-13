using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Rigidbody2D npc;
    private const int columns = 5;
    private const int rows = 4;
    [SerializeField] private Vector2 startPosition = new Vector2(-3.0f, 4.0f);
    [SerializeField] private float gridSize = 1.5f;
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
