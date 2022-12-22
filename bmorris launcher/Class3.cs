using Fiddler;
using System;
using static Fiddler.FiddlerApplication;
using System.Windows.Forms;
using System.IO;

namespace bmorris_launcher
{
    public static class proxy11
    {
        public static void beforeRequest(Session oSession)
        {
            if (oSession.fullUrl.Contains("unknownworlds"))
            {
                if (oSession.fullUrl == "http://subnautica.unknownworlds.com:443")
                {

                }
                else
                {
                    oSession.fullUrl = $"http://127.0.0.1:3642{oSession.PathAndQuery}";
                    Console.WriteLine(oSession.ResponseBody);
                    Console.WriteLine("redirected: " + oSession.fullUrl);
                }

            }
                }



        public static new void WSReq(object sender, WebSocketMessageEventArgs ARGS)
        {
            ARGS.oWSM.Abort();
            return;
        }
        public static void Start()
        {
            if (!CertMaker.rootCertExists() || !CertMaker.rootCertIsTrusted())
            {
                if (!CertMaker.createRootCert())
                {
                    return;
                }
                if (!CertMaker.rootCertIsTrusted())
                {
                    CertMaker.trustRootCert();
                }
            }
            FiddlerCoreStartupSettings Settings = new FiddlerCoreStartupSettingsBuilder().ListenOnPort(8888).OptimizeThreadPool().DecryptSSL().RegisterAsSystemProxy().Build();
            BeforeRequest += beforeRequest;
            OnWebSocketMessage += WSReq;
            Startup(Settings);
        }
        public static void Stop()
        {
            Shutdown();
        }
    }
}