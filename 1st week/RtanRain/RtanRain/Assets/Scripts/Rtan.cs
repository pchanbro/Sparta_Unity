using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rtan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("�ȳ�");
    }

    // Update is called once per frame -> 
    void Update()
    {
        transform.position += Vector3.right;
    }
}
