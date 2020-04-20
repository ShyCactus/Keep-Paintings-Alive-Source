using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int damage = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        health Health = hitInfo.GetComponent<health>();
        if (Health != null)
        {
            Health.TakeDamage();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
