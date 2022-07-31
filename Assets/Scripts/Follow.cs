using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform following;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = following.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (following != null)
        {
            transform.position = following.position - offset;
        }
    }
}
