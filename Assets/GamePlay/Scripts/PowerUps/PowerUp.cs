using Unity.VisualScripting;
using UnityEngine;

namespace GamePlay.Scripts.PowerUps
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class PowerUp : MonoBehaviour
    {
        [SerializeField] private Collider2D goCollider;
        
        [Header("LeanTween Idle Animation Values")]
        [SerializeField] private float speed = 0.75f;
        [SerializeField] private float overshoot = 0.75f;
        [SerializeField] [InspectorLabel("Y Offset")] private float yOffset = 0.125f;

        [Header("LeanTween Pickup Animation Values")]
        [SerializeField] private float delay = 0.25f;
        [SerializeField] [InspectorLabel("Y Offset")] private float yPickupOffset = 0.25f;
        
        private LTDescr idleTween;
        private void Start()
        {
            idleTween = LeanTween.moveY(gameObject,transform.position.y + yOffset, speed)
                .setEase(LeanTweenType.easeInBack)
                .setOvershoot(overshoot)
                .setLoopPingPong();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;

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