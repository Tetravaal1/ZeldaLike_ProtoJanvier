using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorIsometrique : MonoBehaviour {

    private float halfHeight;
    private float halfWidth;
    public float hauteurLigneBlanche;

    private float posY;

    private SpriteRenderer sRenderer;

    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        halfHeight = sRenderer.bounds.size.y * 0.5f;
        halfWidth = sRenderer.bounds.size.x * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        posY = (transform.position.y - halfHeight + hauteurLigneBlanche) * 50f;
        sRenderer.sortingOrder = -Mathf.RoundToInt(posY);
    }

    private void OnDrawGizmos()
    {
        Vector3 posLigneBlanche = new Vector3(transform.position.x, transform.position.y - halfHeight + hauteurLigneBlanche, transform.position.z);
        Gizmos.DrawLine(posLigneBlanche + Vector3.left * halfWidth, posLigneBlanche + Vector3.right * halfWidth);
    }

}
