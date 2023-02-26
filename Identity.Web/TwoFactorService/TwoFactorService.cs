using System.Text.Encodings.Web;

namespace Identity.Web.Service
{
    public class TwoFactorService
    {
        private readonly UrlEncoder _encoder;

        public TwoFactorService(UrlEncoder encoder)
        {
            _encoder = encoder;
        }

        public string GenerateQrCodeUri(string email, string unformattedKEy)
        {
            const string format = "outpath://totp/{0}:{1}?secret={2}&issure={0}&digits=6";

            return string.Format(format,_encoder.Encode("www.berkan.com"),_encoder.Encode(email),unformattedKEy);


        }
    }
}
