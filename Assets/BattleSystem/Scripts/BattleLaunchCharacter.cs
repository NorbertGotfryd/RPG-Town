﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleLaunchCharacter : MonoBehaviour
{
    [SerializeField]
    private List<BattleSystem.BattleCharacter> players;
    [SerializeField]
    private List<BattleSystem.BattleCharacter> enemies;

    [SerializeField]
    private BattleSystem.BattleLauncher launcher;

    public void PrepareBattle(Character character)
    {
        launcher.PrepareBattle(enemies, players, character.transform.position);
    }
}
