using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestSystem;

    public class TreasureHunterQuest : Quest
    {

        void Awake()
        {
            questName = "Treasure Hunter";
            slug = "TreasureHunterQuest";
            description = "Hunt some witches";
            itemRewards = new List<string>() { "Ruby Talisman" };
            goal = new CollectionGoal(20, 0, this);
        }

        public override void Complete()
        {
            base.Complete();
        }

    }
