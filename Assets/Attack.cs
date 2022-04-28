using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Attack : MonoBehaviour
{

  public Animator animator;

  public Transform attackPoint;
    public Transform kickPoint;
        public Transform heavyPoint;
  public float attackRange = 0.5f;
    public float kickRange = 0.5f;
      public float heavyRange = 0.5f;
  public LayerMask player2Layers;
  public float jabRate = 5f;
  float nextJabTime = 0f;
  float nextKickTime = 0f;
    float nextHeavyTime = 0f;
    public float kickRate = 2f;
        public float heavyRate = 1.2f;
    // Update is called once per frame
    void Update()
    {
      if (Input.GetButtonDown("Crouch"))
      {

      } else
      {
        if (Time.time >= nextJabTime) {
          if (Input.GetKeyDown(KeyCode.Z)){

            Jab();
            nextJabTime = Time.time + 1f/jabRate;
          }
        }

        if (Time.time >= nextKickTime) {
          if (Input.GetKeyDown(KeyCode.X)){

            Kick();
            nextKickTime = Time.time + 1f/kickRate;
          }
        }
        if (Time.time >= nextHeavyTime) {
          if (Input.GetKeyDown(KeyCode.C)){
            Heavy();
            nextHeavyTime = Time.time + 1f/heavyRate;
          }
        }
      }

    }


   void Jab()
    {
Collider2D [] hitPlayer2 = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, player2Layers);
// attack animation
  animator.SetTrigger("Jab");
  IEnumerator activeFrame(){
    yield return new WaitForSeconds(0.25f);
// damages the player2
    foreach(Collider2D player2 in hitPlayer2)
    {
      player2.GetComponent<player2>().TakeDamage(15);
    }
  }
  StartCoroutine(activeFrame());
}

void Kick()
 {
Collider2D [] hitPlayer2 = Physics2D.OverlapCircleAll(kickPoint.position, kickRange, player2Layers);
// attack animation
animator.SetTrigger("Kick");
IEnumerator activeFrame(){
 yield return new WaitForSeconds(0.31f);
// damages the player2
 foreach(Collider2D player2 in hitPlayer2)
 {
   player2.GetComponent<player2>().TakeDamage(20);
 }
}
StartCoroutine(activeFrame());
}
void Heavy()
 {
Collider2D [] hitPlayer2 = Physics2D.OverlapCircleAll(heavyPoint.position,heavyRange, player2Layers);
// attack animation
animator.SetTrigger("Heavy");
IEnumerator activeFrame(){
 yield return new WaitForSeconds(0.4f);
// damages the player2
 foreach(Collider2D player2 in hitPlayer2)
 {
   player2.GetComponent<player2>().TakeDamage(40);
 }
}
StartCoroutine(activeFrame());
}

void OnDrawGizmosSelected()
{
  if (attackPoint == null)
      return;

      if (kickPoint == null)
          return;
      if (heavyPoint == null)
            return;
  Gizmos.DrawWireSphere(kickPoint.position, kickRange);
  Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    Gizmos.DrawWireSphere(heavyPoint.position, heavyRange);
}
}
