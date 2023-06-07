using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Affinity : MonoBehaviour
{
	public AffinityType type;
	public bool isWeak;
    public bool isStrong;
}

public enum AffinityType
{
	None,
	Physical,
	Fire,
	Ice,
	Electricity,
	Wind
}
