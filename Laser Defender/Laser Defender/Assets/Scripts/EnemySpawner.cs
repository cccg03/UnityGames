using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float speed = 5f;
    
    private bool movingRight = true;
    private float xmax;
    private float xmin;

	// Use this for initialization
	void Start () {

        float distance = transform.position.z - Camera.main.transform.position.z;


        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        xmin = leftmost.x;
        xmax = rightmost.x;

        foreach ( Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
	}

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    // Update is called once per frame
    void Update () {

        if (movingRight) {
            transform.position += Vector3.right * speed * Time.deltaTime;
        } else {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        float rightEdge = transform.position.x + (.5f * width);
        float leftEdge = transform.position.x - (.5f * width);

        if (leftEdge < xmin)
        {
            movingRight = true;
        } else if(rightEdge > xmax) {
            movingRight = false;
        }

    }
}
