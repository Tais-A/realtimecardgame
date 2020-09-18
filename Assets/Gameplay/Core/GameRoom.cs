﻿using Gameplay.Behaviours.UI;
using Gameplay.Core.Actions;
using Gameplay.Core.Cards;
using UnityEngine;

namespace Gameplay.Core
{
    public class GameRoom : MonoBehaviour
    {
        [SerializeField] Arena arena;
        [SerializeField] MatchReferee matchReferee;
        [SerializeField] CardPrefabMap cardPrefabMap;
        [SerializeField] GameplayHUD gameplayHUD;

        void Start()
        {
            var gameObjectFactory = new GameObjectFactory(cardPrefabMap);
            var deployer = new Deployer(gameObjectFactory, arena, gameplayHUD);
            var gameActionFactory = new GameActionFactory(deployer);
            matchReferee.Setup(gameActionFactory);
        }
    }
}
