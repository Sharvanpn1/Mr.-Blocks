using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public GameObject Player;

    public float speed;

    public float MinDistance;

    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, Player.transform.position);
        if (distance < MinDistance)
        {
            //transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, speed * Time.deltaTime);
            //transform.position.y = Vector2.MoveTowards(this.transform.position.y, Player.transform.position.y, speed * Time.deltaTime);
        }
        //transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, speed * Time.deltaTime);
    }
}
