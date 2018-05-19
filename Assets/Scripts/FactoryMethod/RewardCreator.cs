using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory{
    public class RewardCreator: MonoBehaviour
    {
        private Reward reward;
        public enum TypeReward {
            COIN,
            GEM
        }

        public TypeReward type;

        public Reward CreateReward(TypeReward type){
            switch(type){
                case TypeReward.COIN:
                    Instantiate(reward);
                    reward.AddComponent<Coin>();
                    Debug.Log("Coin added");
                    break;

                case TypeReward.GEM:

                    //reward = new Gem();
                    break;
            }

            return reward;
            
        }


		private void Awake()
		{
            GameObject cosa = new GameObject("hola");
            //reward = CreateReward(type);
		}
	}
        
}
