using UnityEngine;
using Zenject;

public class Portal : MonoBehaviour
{
    #region InJect
    [Inject] private UIEvent _uiEvent;
    #endregion;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();

            if(player != null)
            {
                _uiEvent.OnGameUI();
            }
        }
    }
}
