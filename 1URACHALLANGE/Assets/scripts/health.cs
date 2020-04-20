using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour
{
    public int Health = 50;
    public int damage = 100;
    public int scene;
    public void TakeDamage()
    {
        Health -= damage;

        if (Health <= 0)
        {
            Destroy(gameObject);
            die();
        }
    }
    public void DoubleHealth() {
        Health = Health + 51;
    }
    public void die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(scene);
        FindObjectOfType<audioManager>().Play("Dead");
        
    }
        
 }    
    
    

