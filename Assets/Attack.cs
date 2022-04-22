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
  public LayerMask enemyLayers;
  public float jabRate = 2f;
  float nextJabTime = 0f;
  float nextKickTime = 0f;
    float nextHeavyTime = 0f;
    public float kickRate = 4f;
        public float heavyRate = 7f;
    // Update is called once per frame
    void Update()
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
      transform.Translate(Vector3.up * 700 * Time.deltaTime, Space.World);
    Heavy();
    nextHeavyTime = Time.time + 1f/heavyRate;
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

void Kick()
 {
Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(kickPoint.position, kickRange, enemyLayers);
// attack animation
animator.SetTrigger("Kick");
IEnumerator activeFrame(){
 yield return new WaitForSeconds(0.31f);
// damages the enemy
 foreach(Collider2D enemy in hitEnemies)
 {
   enemy.GetComponent<Enemy>().TakeDamage(20);
 }
}
StartCoroutine(activeFrame());
}
void Heavy()
 {
Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(heavyPoint.position,heavyRange, enemyLayers);
// attack animation
animator.SetTrigger("Heavy");
IEnumerator activeFrame(){
 yield return new WaitForSeconds(0.375f);
// damages the enemy
 foreach(Collider2D enemy in hitEnemies)
 {
   enemy.GetComponent<Enemy>().TakeDamage(40);
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
