﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour
{
    Animator animator;
    private IEnumerator coroutine;
    [SerializeField] GameObject[] skillParticles;

    void Start()
    {
        animator = GetComponent<Animator>();

        for (int i = 0; i < skillParticles.Length; i++)
        {
            skillParticles[i].SetActive(false);
        }
    }

    void Update()
    {
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));


        if (Input.GetKeyUp(KeyCode.Alpha1)) UseSkill(1);
        if (Input.GetKeyUp(KeyCode.Alpha2)) UseSkill(2);
        if (Input.GetKeyUp(KeyCode.Alpha3)) UseSkill(3);
        if (Input.GetKeyUp(KeyCode.Alpha4)) UseSkill(4);
        if (Input.GetKeyUp(KeyCode.Alpha5)) UseSkill(5);

    }

    void UseSkill(int skillNumber)
    {
        animator.SetTrigger("Skill" + skillNumber);
        skillParticles[skillNumber - 1].SetActive(true);

        switch(skillNumber)
        {
            case 1:
                coroutine = WaitToEnableObject(skillParticles[skillNumber - 1], 4f);
                break;
            case 2:
                coroutine = WaitToEnableObject(skillParticles[skillNumber - 1], 3f);
                break;
            case 3:
                coroutine = WaitToEnableObject(skillParticles[skillNumber - 1], 3f);
                break;
            case 4:
                coroutine = WaitToEnableObject(skillParticles[skillNumber - 1], 6f);
                break;
            case 5:
                coroutine = WaitToEnableObject(skillParticles[skillNumber - 1], 3f);
                break;
        }
        coroutine = WaitToEnableObject(skillParticles[skillNumber - 1], 2.3f);
        StartCoroutine(coroutine);
    }

    IEnumerator WaitToEnableObject(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
    }
}
