using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace appcenubbroyler.Provider
{
    public class RestUrl
    {
        public static string RestUrlAdress =
    Device.RuntimePlatform == Device.Android ?
    "http://localhost/api/Users/" :
    "http://192.168.2.7/api/Users/";
    }
}
