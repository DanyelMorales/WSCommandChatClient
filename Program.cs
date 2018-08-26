namespace MomoThePugsocket
{
    /**
     * Main entry point
     */
    class Program
    {
        const string HOST_ADDRESS = "ws://127.0.0.1:5000";

        /**
         * Run this class passing a host as first argument  otherwise
         * HOST_ADDRESS constant will be used
         */
        static void Main(string[] args)
        {
            var hostAddress = HOST_ADDRESS;
            if (args.Length > 0 )
            {
                hostAddress = args[0];
            }

            // create a new websocket client
            var myWebsocketClient = SocketClientFactory.buildSimpleClient(hostAddress);
            // make it work
            myWebsocketClient.connect();
        }
    }
}