using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject BotaoAnim;
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void StartAnimation()
    {
        anim.SetTrigger("StartAnimation");
    }
}

