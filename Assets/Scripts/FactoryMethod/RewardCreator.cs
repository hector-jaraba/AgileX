using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory{
    public class RewardCreator: MonoBehaviour
    {
        
        private GameObject rewardGO;
        private Reward rewardScript;
        private Vector3 transformReward;
        public enum TypeReward {
            COIN,
            GEM
        }

        public TypeReward type;
        public int numberRewards;
        public int area;
        public List<int> rewardsPositions;

        public GameObject CreateReward(TypeReward type){
            switch (type){
                case TypeReward.COIN:
                    rewardGO = Instantiate(Resources.Load("Prefabs/CoinObject")) as GameObject;
                    rewardScript = rewardGO.GetComponent<Coin>();
                    Debug.Log(rewardScript.IsTouchingReward());
                    break;

                case TypeReward.GEM:
                    rewardGO = Instantiate(Resources.Load("Prefabs/GemObject")) as GameObject;
                    rewardScript = rewardGO.GetComponent<Gem>();
                    Debug.Log(rewardScript.IsTouchingReward());
                    break;
            }
            rewardGO.transform.position = RandomPosition();
            rewardGO.transform.parent = this.gameObject.transform; 
            return rewardGO;
        }

        public Vector3 RandomPosition() {
            float minPos = this.transform.position.x - area;
            float maxPos = this.transform.position.x + area;
            int x;

            if (rewardsPositions.Count < (area * 2))
            {
                do
                {
                    x = (int)Random.Range(minPos, maxPos);
                } while (rewardsPositions.Contains(x));
            }
            else {
                x = (int)Random.Range(minPos, maxPos);
            }
            
            rewardsPositions.Add(x);
            return transformReward = new Vector3(x, this.transform.position.y);
        }



		private void Start()
		{
            for (int i = 0; i < numberRewards; i++) {
               rewardGO =  CreateReward(type);
            }

            
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(this.gameObject.transform.position, new Vector3(area*2, transform.position.y));
        }
    }
        
}
