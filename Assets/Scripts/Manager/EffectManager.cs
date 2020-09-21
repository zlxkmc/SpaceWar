using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {

    public ParticleSystem smallShellCollision;
    public ParticleSystem smallShellTeammate;
    public ParticleSystem smallShellEnemy;

    public ParticleSystem explosionCube;
    public ParticleSystem explosionWeapon;
    public ParticleSystem explosionKey;


    public static EffectManager _instance;

    private void Awake()
    {
        _instance = this;
    }
}
