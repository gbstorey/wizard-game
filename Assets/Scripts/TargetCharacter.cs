using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class TargetCharacter : MonoBehaviour
{
    public float speed = 0.001f;
    public float detectionRadiius = 4f;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        if (distance < detectionRadiius)
        {
            transform.SetPositionAndRotation(
            Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime),
            Quaternion.Euler(Vector3.forward * angle)
        );
        }
    }
}
