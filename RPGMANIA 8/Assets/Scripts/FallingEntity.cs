using UnityEngine;


namespace Playable.Entities.Player
{
    public class FallingEntity : MonoBehaviour
    {
        protected CharacterController Controller;

        protected static float Gravity = 2.5f;

        protected Vector3 GravityForce = new Vector3(0, Gravity);

        protected bool grounded;
        public bool Grounded => grounded;

        [SerializeField]
        private LayerMask GroundLayer;

        [SerializeField]
        Transform GroundCheck;

        [SerializeField]
        float AwayFromGround;

        public virtual void FixedUpdate()
        {
            grounded = Physics.CheckSphere(GroundCheck.position, AwayFromGround, GroundLayer);

            Controller.Move(GravityForce * Time.deltaTime * -1);
        }

        protected void GravityReset()
        {
            GravityForce.y = Gravity;
        }


#if UNITY_EDITOR
        protected virtual void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(GroundCheck.position, .1f);
        }
#endif
    }
}
