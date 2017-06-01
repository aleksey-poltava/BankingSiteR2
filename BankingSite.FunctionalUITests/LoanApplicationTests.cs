using BankingSite.Controllers;
using BankingSite.FunctionalUITests.PageObjectModels;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Threading;

namespace BankingSite.FunctionalUITests
{
    [TestFixture()]
    class LoanApplicationTests
    {
        [Test]
        public void ShouldOpenMainPage()
        {
            var homePage = BrowserHost.Instance
                .NavigateToInitialPage<HomeController, HomePage>(x => x.Index());

            Thread.Sleep(5000);

            var h1Text = homePage.PageHeader;

            Assert.That(h1Text, Is.EqualTo("Low rate loan!"));

            Thread.Sleep(2000);
        }


        [Test]
        public void ShouldAcceptLoanApplication()
        {
            var applyPage = BrowserHost.Instance
                .NavigateToInitialPage<LoanApplicationController, LoanApplicationPage>(x => x.Apply());

            Thread.Sleep(5000);

            var acceptPage = applyPage.EnterFirstName("Gentry")
                .EnterLastName("Smith")
                .EnterAge("42")
                .EnterAnnualIncome("9999999")
                .SubmitApplication<AcceptedPage>();

            //var firstNameBox = BrowserHost.Instance.Application
            //    .Browser.FindElement(By.Id("FirstName"));
            //firstNameBox.SendKeys("Gentry");

            //var lastNameBox = BrowserHost.Instance.Application
            //    .Browser.FindElement(By.Id("LastName"));
            //lastNameBox.SendKeys("Smith");

            //var ageBox = BrowserHost.Instance.Application
            //    .Browser.FindElement(By.Id("Age"));
            //ageBox.SendKeys("42");

            //var incomeBox = BrowserHost.Instance.Application
            //    .Browser.FindElement(By.Id("AnnualIncome"));
            //incomeBox.SendKeys("9999999");

            Thread.Sleep(5000);

            //var applyButton = BrowserHost.Instance.Application
            //    .Browser.FindElement(By.Id("Apply"));
            //applyButton.Click();

            //Thread.Sleep(2000);

            //var acceptMessageText = BrowserHost.Instance.Application
            //    .Browser.FindElement(By.Id("acceptMessage"));

            var acceptMessageText = acceptPage.AcceptedMessage;

            Assert.That(acceptMessageText, Is.EqualTo("Congratulations Gentry - Your application was accepted!"));

            Thread.Sleep(5000);
        }

        [Test]
        public void ShouldDeclineLoanApplication()
        {
            var applyPage = BrowserHost.Instance
                .Application.NavigateToInitialPage<LoanApplicationController, LoanApplicationPage>(x => x.Apply());

            Thread.Sleep(5000);

            var declinePage = applyPage.EnterFirstName("Gentry")
                .EnterLastName("Smith")
                .EnterAge("16")
                .EnterAnnualIncome("20000")
                .SubmitApplication<DeclinedPage>();

            //var firstNameBox = BrowserHost.Instance.Application
            //    .Browser.FindElement(By.Id("FirstName"));
            //firstNameBox.SendKeys("Gentry");

            //var lastNameBox = BrowserHost.Instance.Application
            //    .Browser.FindElement(By.Id("LastName"));
            //lastNameBox.SendKeys("Smith");

            //var ageBox = BrowserHost.Instance.Application
            //    .Browser.FindElement(By.Id("Age"));
            //ageBox.SendKeys("16");

            //var incomeBox = BrowserHost.Instance.Application
            //    .Browser.FindElement(By.Id("AnnualIncome"));
            //incomeBox.SendKeys("20000");

            Thread.Sleep(5000);

            //var applyButton = BrowserHost.Instance.Application
            //    .Browser.FindElement(By.Id("Apply"));
            //applyButton.Click();

            //Thread.Sleep(2000);

            //var declineMessageText = BrowserHost.Instance.Application
            //    .Browser.FindElement(By.Id("declineMessage"));

            var declineMessageText = declinePage.DeclinedMessage;

            Assert.That(declineMessageText, Is.EqualTo("Sorry Gentry - We are unable to offer you a loan at this time."));

            Thread.Sleep(2000);

        }
    }
}
