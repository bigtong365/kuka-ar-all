using System;
using UnityEngine;

namespace Project.Scripts.EventSystem.Events
{
    public class ServerConfigEvents : MonoBehaviour
    {
        public static ServerConfigEvents Events;

        private void Awake()
        {
            Events = this;
        }

        public event Action<int> OnClickPingServer;
        public event Action<int> OnClickSaveServerConfig;
        public event Action<int> OnClickBackToMenu; 

        public void ServerPing(int id)
        {
            OnClickPingServer?.Invoke(id);
        }

        public void SaveServerConfig(int id)
        {
            OnClickSaveServerConfig?.Invoke(id);
        }

        public void BackToMenu(int id)
        {
            OnClickBackToMenu?.Invoke(id);
        }
    }
}
