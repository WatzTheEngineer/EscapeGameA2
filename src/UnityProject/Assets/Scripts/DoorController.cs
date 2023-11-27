using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOverColor : MonoBehaviour

{


	public GameObject hinge_of_door;

	private bool doorIsOpen = false;

	void Start()
	{

		
	}

	void OnMouseOver()
	{

		if (Input.GetMouseButtonUp(0))
		{
			if (doorIsOpen == false)
			{
				hinge_of_door.transform.Rotate(0, 90, 0);
                doorIsOpen = true;
            }
			else
			{
                hinge_of_door.transform.Rotate(0, -90, 0);
                doorIsOpen = false;
            }
            

        }

        
	}

	void OnMouseExit()
	{
		
	}
}