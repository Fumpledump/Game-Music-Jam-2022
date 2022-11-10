using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public PlayerHealth playerHealth;
    public Checkpoint healthCheck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerHealth.health);

        if (playerHealth.dead == true)
        {
            //this.gameObject = PlayerPrefs.GetFloat("posX");
            //this.gameObject = PlayerPrefs.GetFloat("posX");
            //this.gameObject = PlayerPrefs.GetFloat("posX");
            

        }
    }
}
