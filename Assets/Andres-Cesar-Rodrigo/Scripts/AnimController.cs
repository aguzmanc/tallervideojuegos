using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    public Animator dongus;


    public void TriggerHurt(float hurtTime)
    {
        StartCoroutine(HurtBlinker(hurtTime));
    }

    IEnumerator HurtBlinker(float hurtTime)
    {
        //ignorar colisiones con enemigos
        int enemyLayer = LayerMask.NameToLayer("Dongus");
        int playerLayer = LayerMask.NameToLayer("Player");

        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer);

        //Anim de parpadeo
        

        //esperar invencibilidad
        yield return new WaitForSeconds(hurtTime);

        //dejar de parpadear y reactivar colisiones
        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer, false);


    }
}
