using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    float chaseSpeed = 10f;
    [SerializeField]
    float chaseTirggerDistance = 5.0f;
    [SerializeField]
    bool returnHome = true;
    Vector3 home;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        home = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if the player gets to close
        Vector3 playerPosition = player.transform.position;
        Vector3 chaseDir = playerPosition - transform.position;
        Vector3 homeDir = home - transform.position;
        if ( chaseDir.magnitude < chaseTirggerDistance)
        {
            //chase the player
            //chase direction = player postion - my current position
            //move in the direction of the player
            chaseDir.Normalize();
            GetComponent<Rigidbody2D>().velocity = chaseDir * chaseSpeed;
        }
        else if (returnHome && homeDir.magnitude > 0.2f)
        {
            //return home
            homeDir.Normalize();
            GetComponent<Rigidbody2D>().velocity = homeDir * chaseSpeed;
        }
        else
        {
            //if the player is not cloes & we're not try to return home, stop moving
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}
