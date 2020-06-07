using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamdomGenerator : MonoBehaviour
{
    private float gap = 6f;
    private float zPos = 5f;
    private int bufferZ = 5;
    private int levelGap = 200;

    //public GameObject go;

    public Transform obstacle2;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < bufferZ; i++) {
            createNextObstacle();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        float z = getZ();

        if ( z + (bufferZ*gap) >= zPos)
        {
            createNextObstacle();
        }
    }

    private void createNextObstacle()
    {
        zPos = zPos + gap;
        placeRandomObstacle(zPos);
        
    }

    private float getZ()
    {
        return this.GetComponent<Transform>().position.z;
    }

    private void placeRandomObstacle(float z)
    {
        int maxLevel = 4;
        bool[,] matrix = new bool[3,3];
        int level = Mathf.Min(maxLevel, (int)(z / levelGap) + 1);
        for(int i = 0; i < level; i++)
        {
            bool continueGen = true;
            while(continueGen)
            {
                int x = Random.Range(-1, 2);
                int y = Random.Range(1, 4);
                if(!matrix[x+1, y-1])
                {
                    Instantiate(obstacle2, new Vector3(x, y, z+50), Quaternion.identity);
                    //Debug.Log("level" + level);
                    //go.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0F, 1F), Random.Range(0F, 1F), Random.Range(0F, 1F), Random.Range(0F, 1F));
                    matrix[x+1, y-1] = true;
                    continueGen = false;
                }
            }
        }
    }
}
