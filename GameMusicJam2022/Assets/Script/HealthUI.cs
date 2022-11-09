using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{

    PlayerHealth playerHealth;
    public SpriteRenderer sr;
    public Sprite health3;
    public Sprite health2;
    public Sprite health1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (playerHealth.health)
        {
            case 3:
                sr.sprite = health3;
                Debug.Log(3);
                break;
            case 2:
                sr.sprite = health2;
                Debug.Log(2);
                break;
            case 1:
                sr.sprite = health1;
                Debug.Log(1);
                break;
            default:
                Debug.Log("dead");
                break;
        }
    }
}
