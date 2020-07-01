using FluentAssertions;
using RestSharp;
using Xunit;
using System;

namespace Correios
{
    public class Program
    {
       private IRestResponse GetCEP(object CEP)
        {
            var client = new RestClient("http://viacep.com.br/ws/" + CEP + "/json/");
            var RSrequest = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json };

            return client.Execute(RSrequest);
        }

        [Fact]
        public void sucesso()
        {
            var response = GetCEP("88040440");
            response.StatusCode.Should().Be(200);
        }
    }
}
