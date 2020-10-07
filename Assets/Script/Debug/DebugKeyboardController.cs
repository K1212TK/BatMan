using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugKeyboardController : MonoBehaviour
{
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerController.ChangeStateLeftRun();
        }
        else if (Input.GetKey(KeyCode.RightArrow)) {

            playerController.ChangeStateRightRun();

        } else if (Input.GetKey(KeyCode.Space)) {

            playerController.ChangeStateJump();
        }
        else {

            playerController.ChangeStateStand();

        }

        // 攻撃
        if (Input.GetKey(KeyCode.X))
        {
            playerController.ChangeStateAttack();
        }
    }
}
