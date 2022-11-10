using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public PlayerHealth playerHealth;
    public GameObject player;
    public Checkpoint checkpoint;
    //public Checkpoint healthCheck;
    private float x;
    private float y;
    private float z;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(playerHealth.health);
        //Debug.Log(x);
        //Debug.Log(y);
        //Debug.Log(z);
    }

    // Update is called once per frame
    void Update()
    {
        //When player dies
        if (playerHealth.dead == true)
        {
            //Sets x,y,z to what was previously saved
            x = PlayerPrefs.GetFloat("posX");
            y = PlayerPrefs.GetFloat("posy");
            z = PlayerPrefs.GetFloat("posz");
            
            player.transform.position = new Vector3(x, y, z);



        }
    }
}
