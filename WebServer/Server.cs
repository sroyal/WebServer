using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace WebServer
{
    class Server
    {
        public bool running = false; //is the Server running?

        private Encoding charEncoder = Encoding.UTF8; //Encodes string
        private Socket serverSocket; //server socket
        private string contentPath; //root path of our content

        //content types supported by our server
        //other supported content: http://webmaster-toolkit.com/mime-types.shtml
        private Dictionary<string, string> extentions = new Dictionary<string, string>()
        {
             //{ "extension", "content type" }
            { "htm", "text/html" },
            { "html", "text/html" },
            { "xml", "text/xml" },
            { "txt", "text/plain" },
            { "css", "text/css" },
            { "png", "image/png" },
            { "gif", "image/gif" },
            { "jpg", "image/jpg" },
            { "jpeg", "image/jpeg" },
            { "zip", "application/zip"}
        };

        public bool start(IPAddress ipAddress;
    }
}
