using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

  public Animator animator;

  public Transform attackPoint;
  public float attackRange = 0.5f;
  public LayerMask enemyLayers;
  public float jabRate = 2f;
  float nextJabTime = 0f;

    // Update is called once per frame
    void Update()
    {

if (Time.time >= nextJabTime) {
  if (Input.GetKeyDown(KeyCode.Z)){

    Jab();
    nextJabTime = Time.time + 1f/jabRate;
  }
}
    }


   void Jab()
    {
Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
// attack animation
  animator.SetTrigger("Jab");
  IEnumerator activeFrame(){
    yield return new WaitForSeconds(0.25f);
// damages the enemy
    foreach(Collider2D enemy in hitEnemies)
    {
      enemy.GetComponent<Enemy>().TakeDamage(15);
    }
  }
  StartCoroutine(activeFrame());
}

void OnDrawGizmosSelected()
{
  if (attackPoint == null)
      return;

  Gizmos.DrawWireSphere(attackPoint.position, attackRange);
}
}
