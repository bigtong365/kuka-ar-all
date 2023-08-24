using UnityEngine;

namespace Project.Scripts.EventSystem.Services.Menu
{
    public class PositioningService : MonoBehaviour
    {
        public static PositioningService Instance;
        internal readonly int PositioningError = 20;
        internal Vector3 BestFitPosition;
        private void Awake()
        {
            Instance = this;
        }
    }
}