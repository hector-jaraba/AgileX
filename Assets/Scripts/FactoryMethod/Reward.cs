using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory
{
    public abstract class Reward : MonoBehaviour
    {

        private int _points;

        protected SpriteRenderer spriteRenderer;
        protected Animator animator;
        protected CircleCollider2D circleCollider2D;

        public int GetPoints()
        {
            return _points;
        }

        public void SetPoints(int points)
        {
            this._points = points;
        }

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                Destroy(gameObject);
            }
        }

        /* Creates the normal components for a reward object */
        protected void CreateRewardComponents(){
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
            animator = gameObject.AddComponent<Animator>() as Animator;
            circleCollider2D = gameObject.AddComponent<CircleCollider2D>() as CircleCollider2D;
        }

        protected abstract void SpriteRenderConfigure();
        protected abstract void AnimatorConfigurator();
        protected abstract void CircleCollider2DConfigurator();
    }
}
