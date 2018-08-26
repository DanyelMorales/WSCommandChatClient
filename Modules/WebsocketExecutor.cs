using System;
using MomoThePugsocket.Modules.Interfaces;
using WebSocketSharp;

namespace MomoThePugsocket.Modules
{
    /**
     * Executes incoming messages from websocket server
     */
    public class WebsocketExecutor : IWebSocketExecutor<Message, WebSocket>
    {
        private readonly IStream<Message> window;
    
        /**
         * @param window stream object to show or read data
         */
        public WebsocketExecutor(IStream<Message> window)
        {
            this.window = window;
        }
        
        /**
         * Executes any message from server
         */
        public Message executeMessage(Message message, WebSocket context)
        {
            switch (message.command.name)
            {
                case SimpleCommands.Write:
                    window.write(message);
                    break;
                case SimpleCommands.Shutdown:
                    context.Close();
                    window.write("--- CONNECTION IS CLOSED --- \n");
                    break;
                default:
                    message.command.name = SimpleCommands.Notice;
                    message.command.value = "UNRECOGNIZED COMMAND";
                    window.error("[x] Unrecognized command received\n");
                    break;
            }

            return message;
        }

        /**
         * Client Loop interface
         * 
         * When connection is created a user interface is created
         * to receive and send messages. Only if context is alive, otherwise
         * this will be killed.
         *
         */
        public void onConnect(WebSocket context)
        {
            do
            {
                var result = window.read(">>");
                var message = MessageBuilder.buildString(result);
                context.Send(message);
            } while (context.IsAlive);
        }
    }
}