using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoWebFramework.Base;
using AutoWebFramework.Extensions;
using AutoWebFramework.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LiveloWebTest.Pages
{
    public class ProductPage : BasePage
    {
        public ProductPage(ParallelConfig parallelConfig) : base(parallelConfig)
        {
        }
        private By txtProductDetails => By.CssSelector("div.product-details__product-header-info-catalog.header-info-catalog > h2");

        private By txtProductID => By.Id("span-productId");

        private By optVoltage => By.Id("CC-prodDetails-sku-type_other_v_voltage");

        private By tabPartners => By.CssSelector("li.partners-tab__nav-item");

        private By txtPoints => By.CssSelector("div.container-price-points");

        private By btnAdd => By.CssSelector("button.button.button__primary.button--large");

        private By tabActivatedPartner => By.CssSelector("li.partners-tab__nav-item.active");

        private bool IsEletricalDevice()
        {
            WebDriverExtensions.WaitElement(_parallelConfig.Driver, btnAdd);
            return _parallelConfig.Driver.FindElement(optVoltage).IsElementPresent();
        }

        private Product GetProductDetails()
        {
            var description = _parallelConfig.Driver.GetText(txtProductDetails);
            var productCode = _parallelConfig.Driver.GetText(txtProductID);
            var voltage = new SelectElement(_parallelConfig.Driver.FindElement(optVoltage)).SelectedOption.Text;
            var partner = _parallelConfig.Driver.FindElement(tabActivatedPartner).GetAttribute("data-gtm-event-label");
            var points = _parallelConfig.Driver.GetText(txtPoints);

            return new Product(description, productCode, voltage, partner, points, 1);
        }

        public Product FillOutAdditionalInformation(string voltage = null, string partner = null)
        {
            _parallelConfig.Driver.WaitElement(notification);
            CloseCookieNotification();

            if (IsEletricalDevice())
            {
                if (String.IsNullOrWhiteSpace(voltage))
                {
                    //Select informed voltage
                    new SelectElement(_parallelConfig.Driver.FindElement(optVoltage)).SelectByIndex(1);
                }
                else
                {
                    //Select first available option for voltage
                    _parallelConfig.Driver.SelectDropDownListByText(optVoltage, voltage);
                }
            }

            var listPartners = _parallelConfig.Driver.FindElements(tabPartners);

            if (String.IsNullOrWhiteSpace(partner))
            {
            }
            else
            {
                var tabPartner = listPartners.Where(partnerName => partnerName.GetAttribute("data-gtm-event-label").Equals(partner)).First();

                if (tabPartner != null)
                {
                    tabPartner.Click();
                }
            }
            return GetProductDetails();
        }



        public ShoppingCartPage AddProductToCart()
        {
            _parallelConfig.Driver.ClickBy(btnAdd);
            WaitLiveloSipnner();

            _parallelConfig.CurrentPage = new ShoppingCartPage(_parallelConfig);
            return _parallelConfig.CurrentPage.As<ShoppingCartPage>();
        }
    }
}
