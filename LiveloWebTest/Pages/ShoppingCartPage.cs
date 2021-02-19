using AutoWebFramework.Base;
using AutoWebFramework.Extensions;
using AutoWebFramework.Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace LiveloWebTest.Pages
{
    public class ShoppingCartPage : BasePage
    {
        public ShoppingCartPage(ParallelConfig parallelConfig) : base(parallelConfig)
        {
        }
        private By txtDescription => By.CssSelector("div.cart-list__prodinfo > a");
        private By txtQty => By.CssSelector("div.cart-list__quantity-box");
        //private By txtPoints => By.CssSelector("div.cart-list__prodvalue > span");
        private By txtPoints => By.XPath("//div[@class='cart-list__prodvalue']/span[2]");

        private By txtHeaderSection => By.CssSelector("cart-list__header");
        private By tableCartList => By.Id("CC-cart-list");

        public string GetHeaderSection()
        {
            return _parallelConfig.Driver.GetText(txtHeaderSection);
        }

        public int GetTotalProducts()
        {
            return _parallelConfig.Driver.FindElements(By.XPath("//div[@data-bind='element: $parents[0].elementName()']")).Count;
        }

        public List<Product> GetListProducts()
        {
            List<Product> listProducts = new List<Product>();

            var listCartInformation = _parallelConfig.Driver.FindElements(By.XPath("//div[@data-bind='element: $parents[0].elementName()']"));

            foreach (var cartInfo in listCartInformation)
            {
                var description = cartInfo.FindElement(txtDescription).Text;
                var qty = cartInfo.FindElement(txtQty).Text;
                var points = cartInfo.FindElement(txtPoints).Text;
                Product p = new Product(description, null, null, null, points, Convert.ToInt32(qty));
                listProducts.Add(p);
            }

            return listProducts;
        }

    }
}
