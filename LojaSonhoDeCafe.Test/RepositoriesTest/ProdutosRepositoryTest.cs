using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Api.Repositories.Produtos;
using LojaSonhoDeCafe.Models.Entity;

namespace LojaSonhoDeCafe.Test.RepositoriesTest
{
    public class ProdutosRepositoryTest
    {

        private readonly IProdutoRepositoryApi _produtoRepository;
        public ProdutosRepositoryTest()
        {
            _produtoRepository = A.Fake<IProdutoRepositoryApi>();
        }

        //[Fact]
        //public async Task ProdutoRepository_AllProducts_ReturnIEnumerableProduto( )
        //{
        //    //Arange
        //    var produto = A.Fake<IEnumerable<Produto>>();

        //    A.CallTo(( ) => _produtoRepository.ObterTodosOsProdutos())
        //    .Returns(Task.FromResult<IEnumerable<Produto>>(produto));


        //    //Act
        //    IEnumerable<Produto> result = await _produtoRepository.ObterTodosOsProdutos();

        //    //Assert

        //    result.Should().NotBeNull();
        //}

    }
}
