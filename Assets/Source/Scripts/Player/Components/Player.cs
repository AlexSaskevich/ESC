using UnityEngine;

namespace Source.Scripts.Player.Components
{
    public struct Player
    {
        public Animator Animator;
        public CharacterController CharacterController;
        public Transform Transform;
        public float MoveSpeed;
    }
}