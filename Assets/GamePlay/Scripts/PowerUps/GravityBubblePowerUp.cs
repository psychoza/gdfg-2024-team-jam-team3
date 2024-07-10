using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace GamePlay.Scripts.PowerUps
{
    public class GravityBubblePowerUp : PowerUp
    {
        protected override void AcquirePowerUp(GameObject player)
        {
            GarvityBubble garvityBubble = player.GetComponent<GarvityBubble>();
            Debug.Log("Gravity Bubble PowerUp Acquired");
            if (garvityBubble) {
                garvityBubble.ActiveBubble();
            }
        }
    }
}