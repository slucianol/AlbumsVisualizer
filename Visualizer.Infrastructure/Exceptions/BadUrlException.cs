using System;
using System.Collections.Generic;
using System.Text;

namespace Visualizer.Infrastructure.Exceptions {
    public class BadUrlException : Exception {
        public BadUrlException(string message) : base(message) {
        }
    }
}
