using System;
using System.Collections.Concurrent;
using Project.Scripts.Connectivity.ExceptionHandling;
using TMPro;
using UnityEngine;

namespace Project.Scripts.Utils
{
    public class DebugLogger : MonoBehaviour
    {
        public static DebugLogger Instance;
        
        [SerializeField] private TextMeshProUGUI textField;
        private ConcurrentQueue<string> messages;
        
        private GlobalExceptionStorage globalExceptionStorage;

        private void Awake()
        {
            Instance = this;

            messages = new ConcurrentQueue<string>();
        }

        private void Start()
        {
            globalExceptionStorage = GlobalExceptionStorage.Instance;
        }

        public void AddLog(String log)
        {
            Debug.Log(log);
            messages.Enqueue(log);
        }

        public void ClearLogs()
        {
            messages.Clear();
            textField.text = "--Debug field--";
        }

        private void Update()
        {
            if (messages.TryDequeue(out var message))
            {
                textField.text += message;
            }

            if (globalExceptionStorage.TryPopException(out var exception))
            {
                textField.text += exception.ToString();
            }
        }

        private void OnDestroy()
        {
            Instance = null;
        }
    }
}
