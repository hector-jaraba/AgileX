using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory{
    public abstract class Creator : MonoBehaviour
    {
        public abstract Reward CreateReward();
    }
        
}
