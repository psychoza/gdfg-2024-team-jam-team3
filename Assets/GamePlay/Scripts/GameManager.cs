using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

namespace GamePlay.Scripts
{
    public class GameManager : PersistentSingleton<GameManager>
    {
        
        [SerializeField] private TilemapRenderer hiddenTilemapRenderer;
        [SerializeField] private TilemapCollider2D hiddenTilemapCollider;
        [SerializeField] private bool showHiddenTilemap;

        public void Start()
        {
            SetHiddenElements();
        }

        public void ToggleSightBeyondSight()
        {
            showHiddenTilemap = !showHiddenTilemap;
            SetHiddenElements();
        }

        private void SetHiddenElements()
        {
            hiddenTilemapRenderer.enabled = showHiddenTilemap;
            hiddenTilemapCollider.enabled = showHiddenTilemap;
        }

        public static void Reload()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        public static void LoadNextScene(int sceneIndex)
        {
            // TODO: make it load next scene until game is won
            var scene = SceneManager.GetSceneAt(sceneIndex);
            // Could be null if wired wrong.
            SceneManager.LoadScene(scene.name);
        }
    }
}