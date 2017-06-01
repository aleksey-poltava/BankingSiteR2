using BankingSite.Controllers;
using BankingSite.Models;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace BankingSite.ControllerTests
{
    [TestFixture]

    public class LoanApplicationControllerTests
    {
        [Test]
        public void ShoudRenderDefaultView()
        {
            var fakeRepository = new Mock<IRepository>();
            var fakeLoanApplicationScorer = new Mock<ILoanApplicationScorer>();

            var sut = new LoanApplicationController(fakeRepository.Object, fakeLoanApplicationScorer.Object);

            //var result = sut.Apply() as ViewResult;

            //Assert.That(result.ViewName, Is.EqualTo("Apply"));

            sut.WithCallTo(x => x.Apply()).ShouldRenderDefaultView();
        }

        [Test]
        public void ShoudRedirectToAcceptedViewOnSuccessfullApplication()
        {
            var fakeRepository = new Mock<IRepository>();
            var fakeLoanApplicationScorer = new Mock<ILoanApplicationScorer>();

            var sut = new LoanApplicationController(fakeRepository.Object, fakeLoanApplicationScorer.Object);

            var acceptedApplication = new LoanApplication
            {
                IsAccepted = true
            };

            sut.WithCallTo(x => x.Apply(acceptedApplication)).ShouldRedirectTo<int>(x => x.Accepted);
        }

        [Test]
        public void ShoudRedirectToDeclineViewOnUnsuccessfullApplication()
        {
            var fakeRepository = new Mock<IRepository>();
            var fakeLoanApplicationScorer = new Mock<ILoanApplicationScorer>();

            var sut = new LoanApplicationController(fakeRepository.Object, fakeLoanApplicationScorer.Object);

            var declinedApplication = new LoanApplication
            {
                IsAccepted = false
            };

            sut.WithCallTo(x => x.Apply(declinedApplication)).ShouldRedirectTo<int>(x => x.Declined);
        }

    }
}
