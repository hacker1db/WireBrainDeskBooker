using System;
using DeskBooker.Core.Domain;
using DeskBooker.Core.Processor;
using Microsoft.CodeAnalysis.Operations;
using Moq;
using NUnit.Framework;

namespace DeskBooker.Web.Pages
{
  [TestFixture]
  
  public class BookDeskModelTests
  {
    [Test]
    [TestCase(1, true)]
    [TestCase(0,false)]
    public void ShouldCallBookDeskMethodOfProcessorIfModelIsValid(
      int expectedBookDesks, bool isModelValid)
    {
      // Arrange
      var processorMock = new Mock<IDeskBookingRequestProcessor>();
      var bookDeskModel = new BookDeskModel(processorMock.Object)
      {
        DeskBookingRequest = new DeskBookingRequest()
      };

      if (!isModelValid)
      {
        bookDeskModel.ModelState.AddModelError("JustAkey","AnErrorMessage");
      }

       // Act 
        
      bookDeskModel.OnPost();
      //Assert
      processorMock.Verify(x => x.BookDesk(bookDeskModel.DeskBookingRequest), 
        Times.Exactly(expectedBookDesks));
    }

  }
}
