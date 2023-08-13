using Project.Scripts.Connectivity.WebSocket;
using UnityEngine;

namespace Project.Scripts.EventSystem
{
    public class ConnectionTestController : MonoBehaviour
    {
        private bool ClientConnected { get; set; }
        private bool FirstRobotConnected { get; set; }
        private bool SecondRobotConnected { get; set; }
        private bool ThirdRobotConnected { get; set; }

        private void Start()
        {
            ClientConnected = false;
            FirstRobotConnected = false;
            SecondRobotConnected = false;
            ThirdRobotConnected = false;

            ConnectionTestEvents.Current.OnPressButtonConnectToServer += ConnectToWebSocketServer;
            ConnectionTestEvents.Current.OnPressButtonConnectToFirstRobot += InitializeConnectionFirstRobot;
            ConnectionTestEvents.Current.OnPressButtonConnectToSecondRobot += InitializeConnectionSecondRobot;
            ConnectionTestEvents.Current.OnPressButtonConnectToThirdRobot += InitializeConnectionThirdRobot;
        }

        private void ConnectToWebSocketServer()
        {
            if (ClientConnected) return;
            ClientConnected = true;
            WebSocketClient.Instance().ConnectToWebsocket("ws://192.168.18.20:8080/kuka-variables");
        }
        
        private void InitializeConnectionFirstRobot()
        {
            if (FirstRobotConnected) return;
            FirstRobotConnected = true;
            WebSocketClient.Instance().SendToWebSocketServer("{ \"host\": \"192.168.1.50\", \"var\": \"BASE\" }");
        }
    
        private void InitializeConnectionSecondRobot()
        {
            if (SecondRobotConnected) return;
            SecondRobotConnected = true;
            WebSocketClient.Instance().SendToWebSocketServer("{ \"host\": \"192.168.1.51\", \"var\": \"BASE\" }");
        }
    
        private void InitializeConnectionThirdRobot()
        {
            if (ThirdRobotConnected) return;
            ThirdRobotConnected = true;
            WebSocketClient.Instance().SendToWebSocketServer("{ \"host\": \"192.168.1.52\", \"var\": \"BASE\" }");
        }
    }
}
