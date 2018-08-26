using System;
using MomoThePugsocket.Modules.Interfaces;

namespace MomoThePugsocket.Modules.View
{
    /**
     *  Helper for reading and writting data from/to and input stream.
     * @see IStream
     */
    public class SimpleStream : IStream<Message>
    {
        private const string MESSAGE = "%s@%s:: %s";

        public void write(Message message)
        {
            var text = string.Format(MESSAGE, message.from, message.command.name, message.command.value);
            Console.WriteLine(text);
        }

        public void write(string msg)
        {
            Console.Write(msg);
        }

        public string read(string instruction)
        {
            write(instruction);
            return Console.ReadLine();
        }

        public void error(string error)
        {
            Console.Error.WriteLine(error);
        }
    }
}