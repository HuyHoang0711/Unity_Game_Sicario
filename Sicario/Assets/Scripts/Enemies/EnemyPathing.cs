using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.getPath();
        transform.position = waypoints[waypointIndex].position;
       
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void setWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }
    public void Move()
    {
        if (waypointIndex <= waveConfig.getPath().Count - 1)
        {
            var targetPos = waypoints[waypointIndex].position;
            targetPos = new Vector3(targetPos.x, targetPos.y, 0);
            var movementThisFrame = waveConfig.getMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, movementThisFrame);
            if (transform.position.Equals(targetPos))
                waypointIndex++;
            
        }
        else
        {
            Destroy(gameObject);
            
        }
    }
}
