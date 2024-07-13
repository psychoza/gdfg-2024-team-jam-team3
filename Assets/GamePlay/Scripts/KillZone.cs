using System;
using System.Collections;
using UnityEngine;

namespace GamePlay.Scripts
{
    [RequireComponent(typeof(Collider2D))]
    public class KillZone : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;
        
        private void OnValidate()
        {
            _collider = GetComponent<Collider2D>();
            _collider.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
            
            other.attachedRigidbody.AddForce(new Vector2(0f, 100f));
            StartCoroutine(KillPlayer(other.gameObject, 0.5f));
        }

        private static IEnumerator KillPlayer(GameObject player, float time)
        {
            Destroy(player, time);
            yield return new WaitForSeconds(time);
            GameManager.Reload();
        }
    }
}