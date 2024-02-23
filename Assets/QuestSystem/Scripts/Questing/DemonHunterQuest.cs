﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestSystem;

    public class DemonHunterQuest : Quest
    {

        void Awake()
        {
            questName = "Demon Hunter";
            slug = "DemonHunterQuest";
            description = "slay some demons.";
            itemRewards = new List<string>() { "Diamond Ore"};
            goal = new KillGoal(1, 0, this);
        }

        public override void Complete()
        {
            base.Complete();
        }

    }
