using MomoThePugsocket.Modules;
using MomoThePugsocket.Modules.View;

namespace MomoThePugsocket
{
    /**
     * Creates websocket client with stream readers and writers.
     */
    public static class SocketClientFactory
    {
        
        /**
         * Creates a new Websocket client with out of the box
         * message console chat.
         *
         * @param string host websocket server address 
         */
        public static Client<Message> buildSimpleClient(string host)
        {
            // client representation
            var window = new SimpleStream();
            // new websocket interpreter for incoming messages
            var webSocketExecutor = new WebsocketExecutor(window);
            
            // new websocket client delegator
            return new Client<Message>(host, webSocketExecutor);
        }
    }
}