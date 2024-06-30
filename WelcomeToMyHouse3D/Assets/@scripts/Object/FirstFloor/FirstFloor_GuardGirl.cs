using Assets.Scripts.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class FirstFloor_GuardGirl : MonoBehaviour
{
    private Animator _anim;
    private BoxCollider[] _patrolGrounds;
    private NavMeshAgent _agent;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        if (PlayerViewModel.Instance.PlayerData.QuestName > QuestName.FirstFloor_GetInjector)
            _anim.SetTrigger("WakeUp");
        else
            _anim.SetTrigger("Sleep");
    }
}
