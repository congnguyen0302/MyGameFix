using Game.Scripts.Player;
using UnityEngine;

namespace Game.Scripts.Trap
{
   public class TrapController : MonoBehaviour
   {
       public void OnTriggerEnter2D(Collider2D col)
      {
          if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
          {
              PlayerController.Instance.ChangeState(PlayerController.Instance.DieState);
          }
      }
   }

}
