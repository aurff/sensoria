using UnityEngine;

[DisallowMultipleComponent]
public class PlayerSoundComponent : MonoBehaviour
{
	public AudioSource audioSource;
	public AudioClip jumpSound;
}

//DO NOT ADD MONOBEHAVIOUR MESSAGES (Start, Update, etc.)
