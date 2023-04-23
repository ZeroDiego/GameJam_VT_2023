using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Person : MonoBehaviour
{
	private List<int> newSocialNeeded = new();

    protected int socialLevel;

	protected int socialPointsNeeded;
	protected int currentSocialPoints;

	protected bool Advance()
	{
		if (CheckIfAdvance())
		{

			socialPointsNeeded = currentSocialPoints;
			return true;
		}
		return false;
	}

	protected bool CheckIfAdvance()
	{
		if (currentSocialPoints >= socialPointsNeeded)
		{

			socialPointsNeeded = currentSocialPoints;
			return true;
		}
		return false;
	}


}
