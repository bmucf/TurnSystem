using UnityEngine;
using UnityEditor.Tilemaps;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
    public class CellData
    {
        public bool Passable;
    }

    private CellData[,] m_BoardData;
    
    private Tilemap m_Tilemap;

    public int mapLength;
    public int mapWidth;

    public Tile[] groundTiles;
    public Tile[] wallTiles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Tilemap = GetComponentInChildren<Tilemap>();

        m_BoardData = new CellData[mapLength, mapWidth];

        for (int x = 0; x < mapLength; x++)
        {
            for (int y = 0; y < mapWidth; y++)
            {
                Tile tile;
                m_BoardData[x, y] = new CellData();

                if (x == 0 ||  y == 0 || x == mapLength -1 || y == mapWidth -1)
                {
                    tile = wallTiles[Random.Range(0, wallTiles.Length)];
                    m_BoardData[x, y].Passable = false;
                }
                else
                {
                    tile = groundTiles[Random.Range(0, groundTiles.Length)];
                    m_BoardData[x, y].Passable = true;
                }

                m_Tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
