using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetris.Network
{
    public enum SecurityLevel
    {

        /// <summary>
        /// No security during handshake
        /// </summary>
        None = 0,
        /// <summary>
        ///  Uses a password to both restrict access to a server and encrypt the handshake
        /// </summary>
        Password,
        /// <summary>
        /// Uses TLS (Transport Level Security) to encrypt connections. No handshake is performed.
        /// </summary>
        TLS
    }
}
