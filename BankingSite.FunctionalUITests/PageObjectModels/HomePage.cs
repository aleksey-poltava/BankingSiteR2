using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace BankingSite.FunctionalUITests.PageObjectModels
{
    class HomePage : Page
    {
        public string PageHeader
        {
            get { return Find.Element(By.TagName("h1")).Text; }
        }
    }
}
