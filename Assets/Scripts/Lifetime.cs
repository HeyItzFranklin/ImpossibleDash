﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{

    public float lifetime; 
    // Start is called before the first frame update
    void Start()
    {
        lifetime = .9f;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
