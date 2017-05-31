using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

    public float width = 3.71f;
    public float height = 3.71f;

    public Color color = Color.white;

    public Transform tilePrefab;

    public TileSet tileSet;

    public bool draggable;

    void OnDrawGizmos()
    {
        Vector3 pos = Camera.current.transform.position;
        Gizmos.color = color;

        for (float y = pos.y - 800.0f; y < pos.y + 800.0f; y += height)
        {
            Gizmos.DrawLine(new Vector3(-500000.0f, Mathf.Floor(y / height) * height, 0.0f), 
                            new Vector3(500000.0f, Mathf.Floor(y / height) * height, 0.0f));
        }

        for (float x = pos.x - 1200.0f; x < pos.x + 1200.0f; x += width)
        {
            Gizmos.DrawLine(new Vector3(Mathf.Floor(x / width) * width, -500000.0f, 0.0f),
                            new Vector3(Mathf.Floor(x / width) * width, 500000.0f, 0.0f));
        }
    }
}
