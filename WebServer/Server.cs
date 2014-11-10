using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace WebServer
{
    class Server
    {
        public bool running = false; //is the Server running?
        private int timeout = 8;
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

        //METHOD TO START SERVER
        public bool start(IPAddress ipAddress, int port, int maxNOConections, string contentPath)
        {
            //if already running dont start
            if (running)
            {
                return false;
            }
            //tcp/ip socket (ipv4)
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(ipAddress, port);
                serverSocket.Listen(maxNOConections);
                serverSocket.ReceiveTimeout = timeout;
                serverSocket.SendTimeout = timeout;
                running = true;
                this.contentPath = contentPath;
                
            }
            
            catch
            {
                return false;
            }
            //Our thread that will listen connection requests
            //and create new threads to handle them.
            Thread requestListenerT = new Thread(() =>
                {
                    while(running)
                    {
                        Socket clientSocket;
                        try
                        {
                            clientSocket = serverSocket.Accept();
                            //Create new thread to handle the request and continue to listen to the socket.
                            Thread requestHandler = new Thread(() =>
                            {
                                clientSocket.ReceiveTimeout = timeout;
                                clientSocket.SendTimeout = timeout;
                                try
                                {
                                    handleTheRequest(clientSocket);
                                }
                                catch
                                {
                                    try{(clientSocket.Close(); } catch{}
                                }

                            });
                            requestHandler.Start();
                        }
                        catch{}
                    }
                });
                requestListenerT.Start();
                return true;
        }//END START METHOD

        //METHOD TO HANDLE REQUESTS
        private void handleTheRequest(Socket clientSocket)
        {
            byte[] buffer = new byte[10240];
        }//END HANDLETHEREQUEST METHOD


    }
}
