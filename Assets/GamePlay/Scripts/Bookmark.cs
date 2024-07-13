using UnityEngine;

namespace GamePlay.Scripts
{
    [RequireComponent(typeof(Collider2D))]
    public class Bookmark : MonoBehaviour
    {
        [SerializeField] private int _nextSceneIndex = -1;
        [SerializeField] private Collider2D _collider;
        
        private void OnValidate()
        {
            _collider = GetComponent<Collider2D>();
            _collider.isTrigger = true;
            if(_nextSceneIndex < 0)
                Debug.LogError("Next scene has not been set. ");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
            
            GameManager.LoadNextScene(_nextSceneIndex);
        }
    }
}