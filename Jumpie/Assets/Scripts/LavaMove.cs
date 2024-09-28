using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMove : MonoBehaviour
{

    public float lavaMoveSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, transform.position.y + lavaMoveSpeed * Time.deltaTime, 0);
    }
}
