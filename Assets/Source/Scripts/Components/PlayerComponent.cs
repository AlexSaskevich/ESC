﻿using UnityEngine;

namespace Source.Scripts.Components
{
    public struct PlayerComponent
    {
        public Animator Animator;
        public CharacterController CharacterController;
        public Transform Transform;
        public float MoveSpeed;
    }
}