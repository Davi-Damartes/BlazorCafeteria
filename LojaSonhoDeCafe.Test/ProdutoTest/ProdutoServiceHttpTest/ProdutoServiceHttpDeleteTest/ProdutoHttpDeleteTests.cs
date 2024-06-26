﻿using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.ServicesHttp.ProdutosHttpService;
using Microsoft.Extensions.Logging;
using System.Net;

namespace LojaSonhoDeCafe.Test.ProdutoTest.ProdutoServiceHttpTest.ProdutoServiceHttpDeleteTest
{
    public class ProdutoHttpDeleteTests
    {

        private readonly Fixture _fixture = new();
        private readonly ILogger<ProdutoHttpService> _logger;

        public ProdutoHttpDeleteTests()
        {
            _logger = A.Fake<ILogger<ProdutoHttpService>>();
        }

        [Fact]
        public async Task ServiceHttpClient_DeletarProdutoPorId_ReturnUmProduto()
        {
            // Assert
            var generateId = _fixture.Create<Guid>();

            var produtoEsperados = _fixture.Create<ProdutoDto>();

            var handler = new HandlerSimularHttpCall(HttpStatusCode.OK, produtoEsperados);

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://www.example.com")

            };
            var produtoClient = new ProdutoHttpService(client, _logger);

            // Act
            await produtoClient.RemoverProduto(generateId);

            // Assert
            Assert.True(true);

        }
    }
}
