using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuCharacter : MonoBehaviour
{

    [SerializeField] private Animator thisAnimator;

    // Start is called before the first frame update
    void Start()
    {
        thisAnimator.SetFloat("locomotion", 1);
    }

}
