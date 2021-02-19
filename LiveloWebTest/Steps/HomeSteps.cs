using System;
using System.Linq;
using AutoWebFramework.Base;
using AutoWebFramework.Config;
using AutoWebFramework.Model;
using LiveloWebTest.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace LiveloWebTest.Steps
{
    [Binding]
    public class HomeSteps : BaseStep
    { 
        //Context injection
        private new readonly ParallelConfig _parallelConfig;
        private Product expectedProduct;

        public HomeSteps(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        [Given(@"(.*) selecionou o (.*) produto do mostruário")]
        public void DadoDiogoSelecionouOProdutoDisponivelDaVitrine(string persona, ShowCasePosition position)
        {
            var idx = (int)Enum.Parse(position.GetType(), position.ToString());
            _parallelConfig.CurrentPage.As<HomePage>().SelectProductFromCarouselByIdx(idx);
        }

        [When(@"(.*) adiciona o produto ao carrinho com as características:")]
        public void QuandoAdicionaOProdutoAoCarrinhoComAsCaracteristicas(string persona, Table table)
        {
        }

        [Given(@"(.*) pesquisou o produto desejado:")]
        public void DadoPesquisouOProdutoDesejado(string persona, Table table)
        {
        }

        [When(@"(.*) adiciona o produto ao carrinho")]
        public void QuandoAdicionaOProdutoAoCarrinho(string persona)
        {
            expectedProduct = _parallelConfig.CurrentPage.As<ProductPage>().FillOutAdditionalInformation();
            _parallelConfig.CurrentPage.As<ProductPage>().AddProductToCart();
        }

        [When(@"(.*) acessa o seu carrinho de compras")]
        public void QuandoDiogoAcessaOSeuCarrinhoDeCompras(string persona)
        {
            _parallelConfig.CurrentPage.As<HomePage>().NavigateToShoppingCart();
        }

        [Given(@"a página principal da livelo foi carregada com sucesso")]
        public void DadoAPaginaPrincipalDaLiveloFoiCarregadaComSucesso()
        {
            _parallelConfig.Driver.Navigate().GoToUrl(Settings.AUT);
            _parallelConfig.CurrentPage = new HomePage(_parallelConfig);
        }

        [Then(@"o carrinho deverá apresentar os detalhes do\(s\) produto\(s\) selecionado\(s\)")]
        public void EntaoOCarrinhoDeveraApresentarOsDetalhesDoSProdutoSDesejadoS()
        {
            var actualProducts = _parallelConfig.CurrentPage.As<ShoppingCartPage>().GetListProducts();

            Assert.AreEqual(expectedProduct.Description, actualProducts[0].Description);
            Assert.AreEqual(expectedProduct.Qty, actualProducts[0].Qty);
            Assert.AreEqual(expectedProduct.Points, actualProducts[0].Points);

        }

        [Given(@"(.*) pesquisou o produto (.*) com as características:")]
        public void DadoPesquisouOProdutoComAsCaracteristicas(string persona, string description, Table table)
        {
        }

        [Given(@"(.*) selecionou o (.*) produto da pesquisa")]
        public void DadoSelecionouOProdutoDaPesquisa(string persona, ShowCasePosition position)
        {
        }


    }
}
