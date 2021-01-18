using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField] private Animator thisAnimator;

    // Start is called before the first frame update
    void Start()
    {
        thisAnimator.SetFloat("locomotion", 1);
        this.transform.eulerAngles = new Vector3(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            thisAnimator.SetFloat("locomotion", 3);
            this.transform.eulerAngles = new Vector3(0, 90, 0);
            transform.position += new Vector3(3 * Time.deltaTime, 0,0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            thisAnimator.SetFloat("locomotion", 3);
            this.transform.eulerAngles = new Vector3(0, -90, 0);
            transform.position -= new Vector3(3 * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            thisAnimator.SetFloat("locomotion", 1);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            thisAnimator.SetFloat("locomotion", 1);
        }

    }

    public void combatReadyAnimation()
    {
        thisAnimator.SetBool("bDaggerBackRight", false);
        thisAnimator.SetFloat("locomotion", 1);
        thisAnimator.SetBool("bDaggerOutRight", true);
    }

    public void combatDoneAnimation()
    {
        Debug.Log("asss");
        thisAnimator.SetBool("bDaggerOutRight", false);
        thisAnimator.SetFloat("locomotion", 1);
        thisAnimator.SetBool("bDaggerBackRight", true);
    }

    public void dodgeAnimation()
    {
        thisAnimator.SetBool("bTaunt", false);
        thisAnimator.SetBool("bTaunt", true);
    }

    public void attackAnimation()
    {
        thisAnimator.SetBool("bAttack1Right", false);
        thisAnimator.SetBool("bAttack1Right", true);
    }

    public void getsHitAnimation()
    {
        thisAnimator.SetBool("gotHit", false);
        thisAnimator.SetBool("gotHit", true);
    }
}
