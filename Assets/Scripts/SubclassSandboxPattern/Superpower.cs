using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Superpower {

    public abstract void Activate(PlayerController player);

    public abstract void Speed(PlayerController player);

    public abstract void Jump(PlayerController player);

}
