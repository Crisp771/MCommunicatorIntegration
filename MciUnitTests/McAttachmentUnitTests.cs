using System;
using MCommunicatorIntegration.Dtos;
using MCommunicatorIntegration.Interfaces.Dtos;
using MCommunicatorIntegration.Interfaces.Repositories;
using MCommunicatorIntegration.Interfaces.Wrappers;
using MCommunicatorIntegration.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NUnit.Framework;

namespace MciUnitTests
{
    [TestFixture]
    public class McAttachmentRepositoryUnitTests
    {
        IMcAttachmentRepository _target;

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void WhenIInsertANewAttachmentTheCommandIsRecieved()
        {
            //Arranging
            ISqlWrapper sqlWrapper = Substitute.For<ISqlWrapper>();
            IMcAttachment payload = new McAttachment();

            _target = new McAttachmentRepository(sqlWrapper);

            //Act
            _target.Insert(payload);

            //Assert
            sqlWrapper.Connection().Received();
            sqlWrapper.Command().Received();

        }
    }
}
