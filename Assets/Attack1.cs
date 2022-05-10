using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Attack1 : MonoBehaviour
{

  public Animator animator;

  public Transform attackPoint;
    public Transform mediumPoint;
        public Transform heavyPoint;
              public Transform crLightPoint;
              public LayerMask player1Layers;
              //ranges for each attack
  public float attackRange = 0.5f;
    public float mediumRange = 0.5f;
      public float heavyRange = 0.5f;
            public float crLightRange = 0.5f;
            //rates for each attack
  public float jabRate = 5f;
    public float crLightRate = 5f;
    public float mediumRate = 2f;
    public float heavyRate = 1.2f;
    //time until next attack
  float nextJabTime = 0f;
  float nextmediumTime = 0f;
    float nextHeavyTime = 0f;
    float nextCrLightTime = 0f;
    bool crouch = false;


    // Update is called once per frame
    void Update()
    {
      if(Input.GetButtonUp("Crouch2")){
        crouch = false;
      }
        if (Input.GetButtonDown("Crouch2")){
              crouch = true;
            }
      if (crouch == true)
      {
        if (Time.time >= nextCrLightTime) {
          if (Input.GetKeyDown(KeyCode.J)){

            CrLight();
            nextCrLightTime = Time.time + 1f/crLightRate;
          }
        }
      } else if(crouch == false)
      {
        if (Time.time >= nextJabTime) {
          if (Input.GetKeyDown(KeyCode.J)){

            Jab();
            nextJabTime = Time.time + 1f/jabRate;
          }
        }

        if (Time.time >= nextmediumTime) {
          if (Input.GetKeyDown(KeyCode.K)){

            medium();
            nextmediumTime = Time.time + 1f/mediumRate;
          }
        }
        if (Time.time >= nextHeavyTime) {
          if (Input.GetKeyDown(KeyCode.L)){
            Heavy();
            nextHeavyTime = Time.time + 1f/heavyRate;
          }
        }
      }

    }


   void Jab()
    {
Collider2D [] hitPlayer1 = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, player1Layers);
// attack animation
  animator.SetTrigger("Jab");
  IEnumerator activeFrame(){
    yield return new WaitForSeconds(0.17f);
// damages the player1
    foreach(Collider2D player1 in hitPlayer1)
    {
      player1.GetComponent<player1>().TakeDamage(15);
    }
  }
  StartCoroutine(activeFrame());
}

void medium()
 {
Collider2D [] hitPlayer1 = Physics2D.OverlapCircleAll(mediumPoint.position, mediumRange, player1Layers);
// attack animation
animator.SetTrigger("Medium");
IEnumerator activeFrame(){
 yield return new WaitForSeconds(0.17f);
// damages the player1
 foreach(Collider2D player1 in hitPlayer1)
 {
   player1.GetComponent<player1>().TakeDamage(20);
 }
}
StartCoroutine(activeFrame());
}
void Heavy()
 {
Collider2D [] hitPlayer1 = Physics2D.OverlapCircleAll(heavyPoint.position,heavyRange, player1Layers);
// attack animation
animator.SetTrigger("Heavy");
IEnumerator activeFrame(){
 yield return new WaitForSeconds(0.333333f);
// damages the player1
 foreach(Collider2D player1 in hitPlayer1)
 {
   player1.GetComponent<player1>().TakeDamage(40);
 }
}
StartCoroutine(activeFrame());
}
void CrLight()
 {
Collider2D [] hitPlayer1 = Physics2D.OverlapCircleAll(crLightPoint.position, crLightRange, player1Layers);
// attack animation
animator.SetTrigger("crLight");
IEnumerator activeFrame(){

 yield return new WaitForSeconds(0.33333333333f);
// damages the player2
 foreach(Collider2D player1 in hitPlayer1)
 {
   player1.GetComponent<player1>().TakeDamage(15);
 }
}
StartCoroutine(activeFrame());
}
void OnDrawGizmosSelected()
{
  if (attackPoint == null)
      return;

      if (mediumPoint == null)
          return;
      if (heavyPoint == null)
            return;
            if (crLightPoint == null){
              return;
            }
  Gizmos.DrawWireSphere(mediumPoint.position, mediumRange);
  Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    Gizmos.DrawWireSphere(heavyPoint.position, heavyRange);
    Gizmos.DrawWireSphere(crLightPoint.position, crLightRange);
}
}
