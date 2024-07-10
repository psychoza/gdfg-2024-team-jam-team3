using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GarvityBubble : MonoBehaviour
{
    [SerializeField] private GameObject bubblePrefab;
    [SerializeField] private float bubbleRadius = 5f;
    [SerializeField] private LayerMask affectedLayers;
    [SerializeField] private float bubbleDuration = 10f;

    private GameObject activeBubble;
    private bool isBubbleActive = false;
    private HashSet<Rigidbody2D> affectedObjects = new HashSet<Rigidbody2D>();

    public void ActiveBubble() {
        if (!isBubbleActive) {
            activeBubble = Instantiate(bubblePrefab, transform.position, Quaternion.identity, transform);
            activeBubble.transform.localScale = new Vector3(bubbleRadius, bubbleRadius, 1);
            
            CircleCollider2D triggerCollider = activeBubble.AddComponent<CircleCollider2D>();
            triggerCollider.isTrigger = true;   
            triggerCollider.radius = bubbleRadius * 0.1f;
            
            isBubbleActive = true;
            StartCoroutine(DeactivateBubbleAfterDuration());
        } 
    }

    private IEnumerator DeactivateBubbleAfterDuration() {
        yield return new WaitForSeconds(bubbleDuration);
        DeactiveBubble();
    }

    private void DeactiveBubble() {
        if (isBubbleActive) {
            foreach (var rb in affectedObjects) {
                ReverseGravity(rb, false);
            }
            affectedObjects.Clear();
            Destroy(activeBubble);
            isBubbleActive = false;
        }
    }

    private void ReverseGravity(Rigidbody2D rb, bool reverse) {
        if(rb != null) {
            rb.gravityScale = reverse ? -0.2f : 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (((1 << other.gameObject.layer) & affectedLayers) != 0) {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null && !affectedObjects.Contains(rb)) {
                ReverseGravity(rb, true);
                affectedObjects.Add(rb);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (((1 << other.gameObject.layer) & affectedLayers) != 0) {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null && affectedObjects.Contains(rb)) {
                ReverseGravity(rb, false);
                affectedObjects.Remove(rb);
            }
        }
    }
}
