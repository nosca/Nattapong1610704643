using UnityEngine;
using UnityEngine.UI;
using TMPro;
using WebSocketSharp;


namespace Programchat
{
    public class WebsocketConection : MonoBehaviour
    {
        public InputField inputUsername;
        public InputField inputIp;
        public InputField inputPort;
        public InputField inputChat;
        public TextMeshProUGUI textChat;

        public Transform loginWindow;
        public Transform chatWindow;
    
        private WebSocket websocket;
        private string username;

        public void Login()
        {
            websocket = new WebSocket("ws://" + inputIp.text +":" + inputPort.text);

            websocket.OnMessage += OnMessage;

            websocket.Connect();

            username = inputUsername.text;
        
            loginWindow.gameObject.SetActive(false);
            chatWindow.gameObject.SetActive(true);
        }

        public void SendChat()
        {
            MessageData data = new MessageData();
            data.username = username;
            data.message = inputChat.text;
            string jsonString = JsonUtility.ToJson(data);
            websocket.Send(jsonString);
        }

        private void OnDestroy()
        {
            if(websocket != null)
            {
                websocket.Close();
            }
            
        }
        public void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            var data = JsonUtility.FromJson<MessageData>(messageEventArgs.Data);
            if(data.username == username)
            {
                textChat.text += "\n<align=right><b>" + data.username + "\n</b>" + data.message;
            }
            else
            {
                textChat.text += "\n<align=left><b>" + data.username + "\n</b>" + data.message;
            }
            Debug.Log("Receive msg : " + messageEventArgs.Data);
        }
    }
    
    public class MessageData
    {
        public string username;
        public string message;
    }
}
