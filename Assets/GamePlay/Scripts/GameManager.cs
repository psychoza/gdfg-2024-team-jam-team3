using UnityEngine;
using UnityEngine.Tilemaps;

namespace GamePlay.Scripts
{
    public class GameManager : PersistentSingleton<GameManager>
    {
        
        [SerializeField] private TilemapRenderer hiddenTilemapRenderer;
        [SerializeField] private TilemapCollider2D hiddenTilemapCollider;
        [SerializeField] private bool showHiddenTilemap;

        public void ToggleSightBeyondSight()
        {
            showHiddenTilemap = !showHiddenTilemap;
            hiddenTilemapRenderer.enabled = showHiddenTilemap;
            hiddenTilemapCollider.enabled = showHiddenTilemap;
        }
            
    }
}