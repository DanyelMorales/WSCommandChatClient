using System;

namespace MomoThePugsocket.Modules.Interfaces
{
 
   /**
    * Command handled by websocket server and clients
    */
    public interface ICommand<T>
    {
        T name { set; get; }
        string value { set; get; }
    }

    /**
     * Execute messages commands from a websocket request
     */
    public interface IWebSocketExecutor<T, C>
    {
        
        /**
         * On every message coming from de websocket, this
         * method will be called.
         * 
         * @param message command to execute
         * @param context who is sending a command
         */
        T executeMessage(T message, C context);

        /**
         * Event dispatched when a new tcp connection is done
         * @param context who is sending a command
         */
       void onConnect(C context);
    }
    /**
     * Reads and writes data from/to an iostream
     * use it to show messages in client side
     *
     * @param T custom type for advanced message types
     */
    public interface IStream<T>
    {
        /**
         * Writes a message to client
         * @param message custom type message to show
         */
        void write(T message);
        
        /**
         * Writes a message string to client
         * @param msg raw string to be displayed
         */
        void write(string msg);
     
        /**
         * Read a message from the stream
         *
         * @param instruction any text to prints before read line
         */
        string read(string instruction);
     
      /**
       * Show an error to client
       * @param error simple string to be showed
       */
        void error(string error);
    }
}