using System.IO.Compression;
using MomoThePugsocket.Modules.Interfaces;
using Newtonsoft.Json;
using WebSocketSharp;

namespace MomoThePugsocket.Modules
{
    
    /**
     * Main client window
     *
     * delegates operations to websocket executor and websocket thirdparty client
     */
    public class Client<T>
    {
        private WebSocket client;
        private IWebSocketExecutor<T, WebSocket> executor;

        public Client(string host, IWebSocketExecutor<T, WebSocket> executor)
        {
            client = new WebSocket(host);
            this.executor = executor;
            initializeClient();
        }

        /**
         * Attach websocket events to websocket executor
         */
        private void initializeClient()
        {
            
            // when a new message arrivss, executor should interpret any command
            client.OnMessage += (ss, ee) =>
            {
                var desearealizedMessage = JsonConvert.DeserializeObject<T>(ee.Data);
                executor.executeMessage(desearealizedMessage, client);
            };

            // a new connection is created, delegate it
            client.OnOpen += (ss, ee) =>
            {
                var webSocket = client;
                if (webSocket != null) executor.onConnect(webSocket);
            };
        }

        /**
         * Create a new connection now!
         */
        public void connect()
        {
            client.Connect();
        }

        /**
         * Close current connection
         */
        public void close()
        {
            client.Close();
        }
    }
}