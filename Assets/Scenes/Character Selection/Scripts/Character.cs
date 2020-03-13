using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "New Character", menuName = "Character Select")]
public class Character : ScriptableObject
{
    [SerializeField] public new string name;
    public Sprite artwork;
    public Sprite endArtwork;
    public Sprite endArtwork2;

    public float speed;                 // Speed of the character
    public float speedLimit;      // Max falling velocity of the player
    public float jumpForce;       // How high player jumps
    public float jumpLimits;

    public RuntimeAnimatorController anim;

    public List<string> quotes;
}
