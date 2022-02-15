using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public CollectablePickups[] collectablePickupsArray;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(collectablePickupsArray[0], transform.position, transform.rotation);
    }
}
