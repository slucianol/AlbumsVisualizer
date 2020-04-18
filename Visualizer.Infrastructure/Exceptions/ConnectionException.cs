using System;
using System.Collections.Generic;
using System.Text;

namespace Visualizer.Infrastructure.Exceptions {
    public class ConnectionException : Exception {
        public ConnectionException(string message) : base(message) {
        }
    }
}
