using AutoWebFramework.Base;
using AutoWebFramework.Extensions;
using OpenQA.Selenium;

namespace LiveloWebTest.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(ParallelConfig parallelConfig) : base(parallelConfig)
        {
        }
        private By btnShoppingCart => By.CssSelector("span.icon-shopping-cart.cart-size");

        private By featureCarousel => By.Id("div-featCarousel");

        public ProductPage SelectProductFromCarouselByIdx(int idx)
        {
            _parallelConfig.Driver.WaitElement(notification);
            _parallelConfig.Driver.WaitElement(featureCarousel);

            CloseCookieNotification();

            var activatedProducts = _parallelConfig.Driver.FindElements(By.CssSelector("div.owl-item.active"));
            var activatedProduct = activatedProducts[idx].FindElement(By.Id("div-productImage"));

             activatedProduct.Click();

            _parallelConfig.CurrentPage = new ProductPage(_parallelConfig);
            return _parallelConfig.CurrentPage.As<ProductPage>();
        }

        public ShoppingCartPage NavigateToShoppingCart()
        {
            _parallelConfig.Driver.ClickBy(btnShoppingCart);

            _parallelConfig.CurrentPage = new ShoppingCartPage(_parallelConfig);
            return _parallelConfig.CurrentPage.As<ShoppingCartPage>();
        }
    }
}
