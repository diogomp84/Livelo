using AutoWebFramework.Base;
using LiveloWebTest.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;


namespace LiveloWebTest.Steps
{
    [Binding]
    public class ShoppingCartSteps : BaseStep
    {
        private new readonly ParallelConfig _parallelConfig;
        public ShoppingCartSteps(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        [Then(@"o carrinho deverá apresentar os detalhes dos produtos desejados:")]
        public void EntaoOCarrinhoDeveraApresentarOsDetalhesDosProdutosDesejados(Table table)
        {
        }
        [Then(@"o carrinho deverá apresentar (.*) produto")]
        public void EntaoOCarrinhoDeveraApresentarProduto(int expectedTotalProducts)
        {
            var actualTotalProducts = _parallelConfig.CurrentPage.As<ShoppingCartPage>().GetTotalProducts();
            Assert.AreEqual(expectedTotalProducts, actualTotalProducts);
        }
    }
}
