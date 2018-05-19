using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory
{
    public abstract class Reward : MonoBehaviour
    {

        public int puntos;

        protected SpriteRenderer spriteRenderer;
        protected Animator animator;
        protected ContadorPuntosImplement contadorPuntos;
        protected bool touchReward;
       

       

        protected abstract void SpriteRenderConfigure();
        protected abstract void AnimatorConfigurator();

        protected virtual void Awake()
        {
            contadorPuntos = GameObject.Find("ContadorPuntosText").GetComponent<ContadorPuntosImplement>();
            CreateRewardComponents();
            touchReward = false; 
            
        }

        /* Creates the normal components for a reward object */
        protected virtual void CreateRewardComponents()
        {
            if (spriteRenderer == null)
            {
                spriteRenderer = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
                SpriteRenderConfigure();
            }

            if (animator == null)
            {
                animator = gameObject.AddComponent<Animator>() as Animator;
                AnimatorConfigurator();
            }

        }

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                Destroy(gameObject);
                if(contadorPuntos != null) contadorPuntos.SumarPuntos(puntos);
            }
        }

        public bool IsTouchingReward() {
            return touchReward;
        }


    }
}
