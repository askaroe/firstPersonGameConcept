using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationChanger : MonoBehaviour, IInteractable
{
  public void Interact()
    {
        transform.Rotate(0f, 0f, 10f);
    }
}
