using System;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

namespace GamePlay.Scripts.PowerUps
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Animator))]
    public abstract class PowerUp : MonoBehaviour
    {
        [SerializeField] private Collider2D goCollider;

        [Header("Animation Controller Values")] 
        [SerializeField] private int powerUpKey = 0;

        [SerializeField] private Animator animator;

        [Header("LeanTween Idle Animation Values")] 
        [SerializeField] private float speed = 0.75f;
        [SerializeField] private float overshoot = 0.75f;
        [SerializeField] [InspectorLabel("Y Offset")] private float yOffset = 0.125f;

        [Header("LeanTween Pickup Animation Values")] 
        [SerializeField] private float delay = 0.25f;

        [SerializeField] [InspectorLabel("Y Offset")] private float yPickupOffset = 0.25f;

        private LTDescr idleTween;

        private void OnValidate()
        {
            animator = gameObject.GetComponent<Animator>();
        }

        /// <summary>
        /// Used OnEnable instead of Start, because when the game is reloaded after a 
        /// compilation, idleTween value turns to null.
        /// </summary>
        private void OnEnable()
        {
            animator.SetInteger("PowerUpKey", powerUpKey);
            idleTween = LeanTween.moveY(gameObject, transform.position.y + yOffset, speed)
                .setEase(LeanTweenType.easeInBack)
                .setOvershoot(overshoot)
                .setLoopPingPong();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
                return;

            goCollider.enabled = false;

            // play sound?

            // fire off particles?

            LeanTween.cancel(idleTween.id);

            LeanTween.moveY(gameObject, transform.position.y + yPickupOffset, delay)
                .setEase(LeanTweenType.easeOutExpo);
            LeanTween.delayedCall(gameObject, delay, () => gameObject.SetActive(false));
            AcquirePowerUp(other.gameObject);
        }

        protected virtual void AcquirePowerUp(GameObject player)
        {
        }
    }
}