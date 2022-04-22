using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitReg : MonoBehaviour
{
    [SerializeField] private Collider collider;
    [SerializeField] private float damageAmount = 0.05f;
    public static bool p1AlreadyDamaged = false;
    public static bool p2AlreadyDamaged = false;

    private void OnTriggerEnter(Collider other)
    {
        // player2 hitting player1
        if (StatsManager.CanDamage && !p1AlreadyDamaged && other.gameObject.CompareTag("Player1"))
        {
            if (P1Controller.animState.IsTag("Moving") || P1Controller.animState.IsTag("Crouching") || P1Controller.animState.IsTag("Attack") || P1Controller.animState.IsTag("HeadReact") || P1Controller.animState.IsTag("Jumping"))
            {
                // disable collider to ensure only 1 damage instance done
                collider.enabled = false;

                StatsManager.P1Health -= damageAmount;
                // Debug.Log("player1health = " + StatsManager.P1Health);

                p1AlreadyDamaged = true;
                StartCoroutine(ResetAlreadyDamagedP1());
            }
        }

        // player1 hitting player2
        else if (StatsManager.CanDamage && !p2AlreadyDamaged && other.gameObject.CompareTag("Player2"))
        {
            if (P2Controller.animState.IsTag("Moving") || P2Controller.animState.IsTag("Crouching") || P2Controller.animState.IsTag("Attack") || P2Controller.animState.IsTag("HeadReact") || P2Controller.animState.IsTag("Jumping"))
            {
                // disable collider to ensure only 1 damage instance done
                collider.enabled = false;

                StatsManager.P2Health -= damageAmount;
                Debug.Log("player2health = " + StatsManager.P2Health);

                p2AlreadyDamaged = true;
                StartCoroutine(ResetAlreadyDamagedP2());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Debug.Log("onTriggerExit");
        collider.enabled = true;
    }

    // Works as a invulnerability timer for the player
    IEnumerator ResetAlreadyDamagedP1()
    {
        yield return new WaitForSeconds(.3f);
        p1AlreadyDamaged = false;
        // Debug.Log("p1AlreadyDamaged reset");
    }

    // Works as a invulnerability timer for the player
    IEnumerator ResetAlreadyDamagedP2()
    {
        yield return new WaitForSeconds(.3f);
        p2AlreadyDamaged = false;
        // Debug.Log("p2AlreadyDamaged reset");
    }

}
