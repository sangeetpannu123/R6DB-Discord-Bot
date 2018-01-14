using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace R6DB_Bot
{
    public static class RestService
    {
        public static string Rest(string requestFunction, Method method, List<Parameter> parameters = null, object body = null)
        {
            var builder = new ConfigurationBuilder()    // Begin building the configuration file
               .SetBasePath(AppContext.BaseDirectory)  // Specify the location of the config
               .AddJsonFile("_configuration.json");    // Add the configuration file
            var _config = builder.Build();                  // Build the configuration file
            
            var api_url = _config["r6db_url"];
            var api_key = _config["x-app-id"];

            var client = new RestClient(api_url);
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            if (parameters == null)
            {
                parameters = new List<Parameter>();
            }

            var request = new RestRequest(requestFunction, method);

            foreach (var parameter in parameters)
            {
                request.AddParameter(parameter.Name, parameter.Value);
            }

            if (body != null)
            {
                request.AddJsonBody(body);
            }


            // easily add HTTP Headers
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "Bearer " + api_key);

            // add files to upload (works with compatible verbs)
            // request.AddFile(path);

            // execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string

            return content;
        }
    }
}
