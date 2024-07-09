using UnityEngine;

namespace GamePlay.Scripts.PowerUps
{
    public class SightBeyondSight : PowerUp
    {
        protected override void AcquirePowerUp(GameObject player)
        {
            GameManager.Instance.ToggleSightBeyondSight();
        }
    }
}