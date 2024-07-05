using Unity.VisualScripting;
using UnityEngine;

namespace GamePlay.Scripts
{
    [RequireComponent(typeof(Collider2D))]
    public class PowerUp : MonoBehaviour
    {
        [SerializeField] private Collider2D goCollider;
        
        [Header("LeanTween Animation Values")]
        [SerializeField] private float speed = 0.75f;
        [SerializeField] private float overshoot = 0.75f;
        [SerializeField] [InspectorLabel("Y Offset")] private float yOffset = 0.125f;
        
        private void Start()
        {
            LeanTween.moveY(gameObject,transform.position.y + yOffset, speed)
                .setEase(LeanTweenType.easeInBack)
                .setOvershoot(overshoot)
                .setLoopPingPong();
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("triggered");
        }

        private void OnCollisionEnter(Collision other)
        {
            Debug.Log("collided");
            Destroy(gameObject);
        }
    }
}