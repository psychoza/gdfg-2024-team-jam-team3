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
            if (garvityBubble) {
                garvityBubble.ActiveBubble();
            }
        }
    }
}