using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //キャラクターにカメラを追従
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -1);
    }
}
