using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class PlaterController : MonoBehaviour {

    private Rigidbody2D rb2d;
    private Animator anim;

    private float h;
    private float v;

    [SerializeField]
    private float speed;

    private Vector3 flippo = new Vector3(-1, 1, 1);

    //(Attention complexe !) Si t'as vraiment besoin que je t'explique ça je peux mais c'est complexe. Je l'ai mis comme ça pour que tu comprennes mieux le reste du code.
    public enum Direction { Haut, Droite, Bas, Gauche };
    [HideInInspector]
    public Direction currentDirection = Direction.Bas;

    void Start () {
        //Je fais ça pour pouvoir accéder à l'animator et la physique du joueur
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        //Je mets les commandes du joueur dans une varibale
        //Si le joueur fait la flèche de droite, h sera égal à 1. Inversement si le joueur fait la flèche de gauche, h sera égal à -1. Et si il ne fait rien h sera égal à 0.
        //Le v est pareil que pour le h mais avec les flèches haut et bas. Haut = 1, Bas = -1, Rien = 0.
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        //Ici je teste pour savoir si le joueur bouge
        if (v != 0 || h != 0)
        {
            //Dit à l'animator que le personnage bouge
            anim.SetBool("isMoving", true);
            //Ensuite je regarde dans quel direction il veut aller
            //Et j'assigne dans une variable cette direction
            
            if (v > 0)
            {
                currentDirection = Direction.Haut;
            }
            else if (v < 0)
            {
                currentDirection = Direction.Bas;
            }
            else if (h > 0)
            {
                currentDirection = Direction.Droite;
            }
            else
            {
                currentDirection = Direction.Gauche;
            }
        }
        else {
            //dit à l'animator que le personnage est immobile.
            anim.SetBool("isMoving", false);
        }


        //Bouge dans la direction voulue et ajoute un facteur reglable de vitesse.
        rb2d.velocity = new Vector2(h, v) * speed;

        //Ensuite je vais aller changer le parametre Direction, dans l'animator.
        //Et suivant la direction, il va jouer tel ou tel animation.
        anim.SetInteger("Direction", (int)currentDirection);
    }
}
