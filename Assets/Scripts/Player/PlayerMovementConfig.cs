using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMovementConfig", menuName = "ScriptableObjects/SpawnPlayerMovementConfig", order = 1)]
public class PlayerMovementConfig : Config<PlayerMovementConfig>
{
    public float HorizontalMaxSpeed;
    public float PositiveHorizontalSpeedModifier;
    public float NegativeHorizontalSpeedModifier;
    public float JumpPower;
    public float PositiveVerticalSpeedModifier;
    public float NegativeVerticalSpeedModifier;
    public float JumpCheckRayLength;
    public float CoyoteTime;

    [Space]
    public float PlayerRadius;
    public float ClamCapsuleHeight;
    public float JumpCapsuleHeight;
    public float ClamCapsuleYOffset;
    public float JumpCapsuleYOffset;
}
