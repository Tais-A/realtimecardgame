﻿using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Core;
using UnityEngine;

namespace Gameplay.Behaviours
{
    [RequireComponent(typeof(ColliderBehaviour))]
    public class TeamBehaviour : MonoBehaviour
    {
        [SerializeField] Team team;

        ColliderBehaviour _collider;

        public event Action<Team> OnUpdateTeam;

        public Team Team
        {
            get => team;
            set
            {
                if (team == value)
                {
                    return;
                }
                team = value;
                gameObject.tag = Team.GetTag();
                OnUpdateTeam?.Invoke(team);
            }
        }

        Team GetOppositeTeam() => team.Opposite();

        public IEnumerable<GameObject> GetCollidingEnemies()
        {
            if (Team == Team.None)
            {
                return Enumerable.Empty<GameObject>();
            }
            var oppositeTeam = GetOppositeTeam();
            return _collider.CollidingObjects.Where(c => c.CompareTag(oppositeTeam.GetTag()));
        }

        void Awake()
        {
            _collider = GetComponent<ColliderBehaviour>();
        }
    }
}
