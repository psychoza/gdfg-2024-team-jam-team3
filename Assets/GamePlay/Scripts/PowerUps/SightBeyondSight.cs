using UnityEngine;

namespace GamePlay.Scripts.PowerUps
{
    public class SightBeyondSight : PowerUp
    {
        protected override void AcquirePowerUp(GameObject player)
        {
            Debug.Log($"{player.name} acquired Sight Beyond Sight.");
        }
    }
}