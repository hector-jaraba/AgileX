using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory{
    public class RewardCreator : MonoBehaviour
    {
        private Reward reward;
        public enum TypeReward {
            COIN,
            GEM
        }

        TypeReward typeReward;

        public Reward CreateReward(){
            switch(typeReward){
                case TypeReward.COIN:
                    reward = new Coin();
                    break;

                case TypeReward.GEM:

                    reward = new Gem();
                    break;
            }

            return reward;
            
        }
    }
        
}
