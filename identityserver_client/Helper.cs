﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityModel.Client;
using System.Net.Http;

namespace identityserver_client
{
    public class Helper
    {
        public static TokenResponse GetClientToken()
        {
            var client = new TokenClient(
                "http://localhost:5000/connect/token",
                "silicon",
                "F621F470-9731-4A25-80EF-67A6F7C5F4B8"
                );
            return client.RequestClientCredentialsAsync("api1").Result;
        }

        public static void CallApi(TokenResponse response)
        {
            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);

            Console.WriteLine(client.GetStringAsync("http://localhost:62789/test").Result);
        }

        public static TokenResponse GetUserToken()
        {
            var client = new TokenClient(
                        "http://localhost:5000/connect/token",
                        "carbon",
                        "21B5F798-BE55-42BC-8AA8-0025B903DC3B");

            return client.RequestResourceOwnerPasswordAsync("bob", "secret", "api1").Result;
        }
    }
}
