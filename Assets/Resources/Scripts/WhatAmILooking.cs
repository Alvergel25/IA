using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatAmILooking : MonoBehaviour
{
    public List<GameObject> viewList;
    // Start is called before the first frame update
    void Start()
    {
        viewList = new List<GameObject>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        viewList.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        viewList.Remove(other.gameObject);
    }
}
