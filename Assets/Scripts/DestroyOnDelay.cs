using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDelay : MonoBehaviour
{
    public float Delay = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Delay -= Time.deltaTime;
        if(Delay <= 0)
        {
            Destroy(gameObject);
        }
    }
}
