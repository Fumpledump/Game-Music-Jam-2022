using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nest : MonoBehaviour
{
    public Animator animator;
    public MainMenu mainMenu;

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.instance;

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Sword")
        {
            audioManager.Play("Nest");
            animator.SetBool("Fall", true);
            mainMenu.LoadLevel("Level 3");
        }
    }
}
