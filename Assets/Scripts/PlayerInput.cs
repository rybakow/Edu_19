using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerController playerController;
    
    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    
    void Update()
    {
        float horizontal = Input.GetAxisRaw(GlobalVars.HORIZONTAL);
        bool jumpPressed = Input.GetButtonDown(GlobalVars.JUMP);
        bool primaryAttackPressed = Input.GetButtonDown(GlobalVars.PRIMARY_ATTACK);
        
        playerController.Run(horizontal);
        playerController.Jump(jumpPressed);
        //playerController.PrimaryAttack(primaryAttackPressed);
    }
}
