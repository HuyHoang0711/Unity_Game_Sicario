using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAttack : MonoBehaviour
{
    GameSession gs;
    [SerializeField] GameObject rock;
    [SerializeField] float posY;
    [SerializeField] float posXMin;
    [SerializeField] float posXMax;
    [SerializeField] float timeBetweenAttack = 5f;
    bool isAttack = false;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        gs = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        ExeAttack();
    }
    public void ExeAttack()
    {
        if (gs.GetScore() % 3000 == 0 && gs.GetScore() > 0)
        {

            isAttack = true;
            if (isAttack)
                StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        
       
           
            Instantiate(rock, new Vector2(Random.Range(posXMin, posXMax), posY), Quaternion.identity);
            count++;
            yield return new WaitForSeconds(timeBetweenAttack);
            isAttack = false;

    }
}
