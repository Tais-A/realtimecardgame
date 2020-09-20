﻿using Gameplay.Core;
using UnityEngine;

namespace Gameplay.Behaviours
{
    public class Behaviour : MonoBehaviour
    {
        public Entity Entity { get; private set; }

        protected virtual void Awake() => Initialize();

        void Initialize()
        {
            if (Entity == null)
            {
                Entity = GetComponent<Entity>();
            }
        }
    }
}
