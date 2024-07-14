using UnityEngine;

namespace GamePlay.Scripts
{
    [RequireComponent(typeof(Collider2D))]
    public class Bookmark : MonoBehaviour
    {
        [SerializeField] private string _nextScene;
        [SerializeField] private Collider2D _collider;
        
        private void OnValidate()
        {
            _collider = GetComponent<Collider2D>();
            _collider.isTrigger = true;
            if(string.IsNullOrEmpty(_nextScene))
                Debug.LogError("Next scene has not been set on the levels bookmark.");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
            GameManager.LoadNextScene(_nextScene);
        }
    }
}