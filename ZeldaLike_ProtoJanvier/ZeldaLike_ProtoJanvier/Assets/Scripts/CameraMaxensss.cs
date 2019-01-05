using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMaxensss : MonoBehaviour {

    public GameObject player;

    [Header("Gauche - Droite")]
    public float xMinimum;
    public float xMaximum;

    [Header("Bas - Haut")]
    public float yMinimum;
    public float yMaximum;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, xMinimum, xMaximum), Mathf.Clamp(player.transform.position.y, yMinimum, yMaximum), -10f);
    }
}
