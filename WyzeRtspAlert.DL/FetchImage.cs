using RtspClientSharp;
using RtspClientSharp.RawFrames.Audio;
using RtspClientSharp.RawFrames.Video;
using System.Net;
using WyzeRtspAlert.DL.Interface;


namespace WyzeRtspAlert.DL
{
    public class FetchImage : IFetchImage
    {
        public async void Fetch(string address, string userName, string password)
        {
            // fetch an image from a rtsp live connection with the information given above

            CancellationToken token = CancellationToken.None;

            NetworkCredential credentials = new NetworkCredential(userName, password);
            ConnectionParameters connectionParameters = new ConnectionParameters(new Uri($"rtsp://{address}/live"), credentials);
            

            //var serverUri = new Uri("rtsp://192.168.1.77:554/ucast/11");
            //var credentials = new NetworkCredential("admin", "123456");
            // var connectionParameters = new ConnectionParameters(serverUri, credentials);
            connectionParameters.RtpTransport = RtpTransportProtocol.TCP;
            using (var rtspClient = new RtspClient(connectionParameters))
            {
                rtspClient.FrameReceived += (sender, frame) =>
                {
                    //process (e.g. decode/save to file) encoded frame here or 
                    //make deep copy to use it later because frame buffer (see FrameSegment property) will be reused by client
                    switch (frame)
                    {
                        case RawH264IFrame h264IFrame:
                        case RawH264PFrame h264PFrame:
                        case RawJpegFrame jpegFrame:
                        case RawAACFrame aacFrame:
                        case RawG711AFrame g711AFrame:
                        case RawG711UFrame g711UFrame:
                        case RawPCMFrame pcmFrame:
                        case RawG726Frame g726Frame:
                            
                            break;
                        default:
                            break;
                    }
                };
            
                await rtspClient.ConnectAsync(token);
                await rtspClient.ReceiveAsync(token);
            }


        }
    }
}