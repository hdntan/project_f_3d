using System;
using UnityEngine;

public class PlayerStatsManager : CharacterStatusManager
{
    [SerializeField] PlayerManager player;
    protected override void Awake()
    {
        base.Awake();
        this.player = GetComponent<PlayerManager>();
    }

    protected override void Start()
    {
        base.Start();
       this.CaculateHealthBasedOnVitalityLevel(this.vitality);
       this.CaculateStaminaBasedOnEnduranceLevel(this.endurance);
    }
}
