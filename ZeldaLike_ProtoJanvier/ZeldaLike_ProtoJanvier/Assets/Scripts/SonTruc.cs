using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonTruc : MonoBehaviour {

    private AudioSource audioS;
    public Transform Player;
    public float distance;

	void Start () {
        audioS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        distance = (Player.position - transform.position).magnitude;
        audioS.volume = 0.1f / (distance*2);
	}
}
