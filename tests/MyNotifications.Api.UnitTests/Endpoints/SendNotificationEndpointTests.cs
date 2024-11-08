using FastEndpoints;
using MassTransit.RabbitMqTransport;
using Moq;
using MyNotifications.Api.Endpoints.SendNotification;
using MyNotifications.Database;
using MyNotifications.DomainModel.Entities;
using MyNotifications.DomainModel.Events;
using MyNotifications.DomainModel.Models;

namespace MyNotifications.Api.UnitTests.Endpoints;

[TestFixture]
public class SendNotificationEndpointTests
{
    private Mock<MnDbContext> _mockContext;
    private Mock<IPublisher> _mockPublisher;
    private SendNotificationEndpoint _endpoint;

    [SetUp]
    public void SetUp()
    {
        _mockContext = new Mock<MnDbContext>();
        _mockPublisher = new Mock<IPublisher>();
        _endpoint = new SendNotificationEndpoint(_mockContext.Object);
    }
    
    
}