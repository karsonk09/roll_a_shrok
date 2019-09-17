using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShroks : MonoBehaviour
{
    public int maxShroks;
    public int maxFarcubes;
    public Transform maxPosX;
    public Transform minPosX;
    public Transform maxPosY;
    public Transform minPosY;
    public Transform maxPosZ;
    public Transform minPosZ;

    public GameObject shroksToDuplicate;
    public GameObject farcubesToDuplicate;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxShroks; i++)
        {
            Vector3 placementPosition = new Vector3(Random.Range(minPosX.position.x, maxPosX.position.x), Random.Range(minPosY.position.y, maxPosY.position.y), Random.Range(minPosZ.position.z, maxPosZ.position.z));
            Instantiate(shroksToDuplicate, placementPosition, Quaternion.identity);
        }
        for (int i = 0; i < maxFarcubes; i++)
        {
            Vector3 placementPosition = new Vector3(Random.Range(minPosX.position.x, maxPosX.position.x), Random.Range(minPosY.position.y, maxPosY.position.y), Random.Range(minPosZ.position.z, maxPosZ.position.z));
            Instantiate(farcubesToDuplicate, placementPosition, Quaternion.identity);
        }
    }
}
