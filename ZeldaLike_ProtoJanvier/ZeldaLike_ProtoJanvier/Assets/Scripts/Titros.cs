using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Titros : MonoBehaviour {

    private Animator anim;

	void Start () {
        anim = GetComponent<Animator>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetBool("Inside", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("Inside", false);
    }
}
