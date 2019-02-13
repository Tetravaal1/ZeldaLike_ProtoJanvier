using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bete : MonoBehaviour {

    public Transform A;
    public Transform B;

    public float travelTime;

    public bool idle = true;

    private bool canCharge = false;
    private bool canReset = false;

    private Animator anim;

	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Idle", idle);
        if (Input.GetKeyDown(KeyCode.I)) {
            if (idle)
            {
                idle = false;
                StartCoroutine(ActionWalk());
            }
            else {
                idle = true;
                transform.position = A.position;
            }
        }
        if (Input.GetKeyDown(KeyCode.O)) {
            if (idle)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                transform.position = A.position;
                anim.SetTrigger("Attack");
            }
        }
	}

    IEnumerator ActionWalk() {
        GetComponent<SpriteRenderer>().flipX = true;
        transform.position = A.position;
        Vector3 origin = transform.position;
        Vector3 end = B.transform.position;
        float fracJourney = 0;
        float currTime = 0;
        while (transform.position.x != end.x&&!idle) {
            transform.position = Vector3.Lerp(origin, end, fracJourney);
            currTime += Time.deltaTime;
            fracJourney = currTime / travelTime;
            yield return new WaitForEndOfFrame();
        }
        if (!idle)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        //transform.position = B.position;
        origin = transform.position;
        end = A.transform.position;
        fracJourney = 0;
        currTime = 0;
        while (transform.position.x != end.x && !idle)
        {
            transform.position = Vector3.Lerp(origin, end, fracJourney);
            currTime += Time.deltaTime;
            fracJourney = currTime / travelTime;
            yield return new WaitForEndOfFrame();
        }
        if (!idle) {
            StartCoroutine(ActionWalk());
        }
    }

    public void beginCharge() {
        StartCoroutine(ActionAttack());
    }

    IEnumerator ActionAttack()
    {
        Vector3 origin = transform.position;
        Vector3 end = B.transform.position;
        float fracJourney = 0;
        float currTime = 0;
        while (transform.position.x != end.x)
        {
            transform.position = Vector3.Lerp(origin, end, fracJourney);
            currTime += Time.deltaTime;
            fracJourney = currTime / travelTime;
            yield return new WaitForEndOfFrame();
        }
        anim.SetTrigger("Attack");
    }
}
