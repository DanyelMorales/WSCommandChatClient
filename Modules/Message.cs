using MomoThePugsocket.Modules.Interfaces;
using Newtonsoft.Json;

namespace MomoThePugsocket.Modules
{
    
    /**
     * Main commands supported for server and clients
     */
    public enum SimpleCommands
    {
        Write,
        Rename,
        Notice,
        Shutdown
    };

    /**
     * Command container 
     */
    public class SimpleCommand : ICommand<SimpleCommands>
    {
        public SimpleCommands name { set; get; }
        public string value { set; get; }
    }


    /**
     * Message container
     */
    public class Message
    {
        public string from { set; get; }
        public SimpleCommand command { set; get; }
    }


    /**
     * Helper for message creation
     */
    public static class MessageBuilder
    {
        
        /**
         * Creates a new message using a string
         * @return Message object
         */
        public static Message build(string msg)
        {
            var message = new Message();
            var cmd = new SimpleCommand
            {
                name = SimpleCommands.Write,
                value = msg
            };
            message.command = cmd;
            return message;
        }

        /**
         *  Converts a string to a serialized Message Object
         * @returns a string representing a serialized object
         */
        public static string buildString(string msg)
        {
            var mymsg = build(msg);
            return JsonConvert.SerializeObject(mymsg);
        }
    }
}