using System.Collections.Generic;
using UnityEngine;

public class SpawnerInArea : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] prefabs;
    [SerializeField]
    protected int countNecessarySpawns = 1;
    [SerializeField]
    protected int width = 4;
    [SerializeField]
    protected int height = 4;
    [SerializeField]
    protected LayerMask maskObstacle;
    [SerializeField]
    protected Vector3 spawnOffset = new Vector3(0.5f, 0, 0.5f);


    [SerializeField]
    protected Color gizmoColor = Color.green;


    private RectInt rectSpawn;
    private List<Vector3> positionsInRect;


    private void Awake()
    {
        rectSpawn = GetSpawnAreaRect();
        positionsInRect = new List<Vector3>(width * height);
        foreach (Vector2Int pos2D in rectSpawn.allPositionsWithin)
        {
            Vector3 pos = new Vector3(pos2D.x, transform.position.y, pos2D.y) + spawnOffset;
            Vector3 sizeCell = new Vector3(0.49f, 0, 0.49f);
            if (!Physics.CheckBox(pos, sizeCell, Quaternion.identity, maskObstacle))
            {
                positionsInRect.Add(pos);
            }
        }
    }
    private void Start()
    {
        SpawnObjects();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;

        int x = Mathf.FloorToInt(transform.position.x);
        int z = Mathf.FloorToInt(transform.position.z);
        Vector3 pos = new Vector3(x, 0, z);
        Vector3 size = new Vector3(width, 0, height);

        Gizmos.DrawWireCube(pos, size);
    }


    private void SpawnObjects()
    {
        for (int i = 0; i < countNecessarySpawns; i++)
        {
            Spawn();
        }
    }
    private void Spawn()
    {
        GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];
        if (positionsInRect.Count > 0)
        {
            int randomPosIndex = Random.Range(0, positionsInRect.Count);
            Vector3 pos = positionsInRect[randomPosIndex];
            positionsInRect.RemoveAt(randomPosIndex);

            Instantiate(prefab, pos, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Not enough free positions for all necessary spawns");
        }

    }
    private RectInt GetSpawnAreaRect()
    {
        int x = Mathf.FloorToInt(transform.position.x) - width / 2;
        int z = Mathf.FloorToInt(transform.position.z) - height / 2;
        return new RectInt(x, z, width, height);
    }
}
