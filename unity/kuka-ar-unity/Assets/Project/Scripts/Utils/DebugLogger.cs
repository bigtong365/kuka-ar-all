using System;
using System.Collections.Concurrent;
using TMPro;
using UnityEngine;

namespace Project.Scripts.Utils
{
    public class DebugLogger : MonoBehaviour
    {
        public static DebugLogger Instance;
        
        [SerializeField] private TextMeshProUGUI textField;
        private ConcurrentQueue<string> messages;
        
        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            messages = new ConcurrentQueue<string>();
        }

        public void AddLog(String log)
        {
            messages.Enqueue(log);
        }

        public void ClearLogs()
        {
            messages.Clear();
            textField.text = "--Debug field--";
        }

        private void Update()
        {
            if (messages.TryDequeue(out string message))
            {
                textField.text += message;
            }
        }

        void OnDestroy()
        {
            Instance = null;
        }
    }
}