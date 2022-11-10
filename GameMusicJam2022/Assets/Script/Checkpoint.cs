using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public float posX;
    public float posY;
    public float posZ;
    // Start is called before the first frame update
    void Start()
    {
        //Gets the positions of this checkpoint
        posX = this.transform.position.x;
        posY = this.transform.position.y;
        posZ = this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //If player reaches checkpoint
    private void OnTriggerEnter2D(Collider2D col)
    {
        //Collides with player
        if(col.gameObject.tag == "Player")
        {
            //Saves x,y,and z position
            PlayerPrefs.SetFloat("posX", posX);
            PlayerPrefs.SetFloat("posY", posY);
            PlayerPrefs.SetFloat("posZ", posZ);
        }
        
    }
}
