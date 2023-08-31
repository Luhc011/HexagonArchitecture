using Domain.Entities;
using Domain.Enums;
using NUnit.Framework;
using Action = Domain.Enums.Action;

namespace DomainTests.Bookings;

public class StateMachineTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ShouldAlwaysStartWithCreatedStatus()
    {
        var booking = new Booking();

        Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Created));
    }


    [Test]
    public void ShouldSetStatusToPaidWhenPayingForABookingWithCreatedStatus()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Pay);

        Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Paid));
    }

    [Test]
    public void ShouldSetStatusToCanceledWhenCancelingABookingWithCreatedStatus()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Cancel);

        Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Cancelled));
    }

    [Test]
    public void ShouldSetStatusToFinishWhenFinishingAPaidBooking()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Pay);
        booking.ChangeState(Action.Finish);

        Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Finished));
    }

    [Test]
    public void ShouldSetStatusToRefoundingWhenFinishingAPaidBooking()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Pay);
        booking.ChangeState(Action.Refound);

        Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Refounded));
    }

    [Test]
    public void ShouldSetStatusToCreatedWhenReopeningACanceledBooking()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Cancel);
        booking.ChangeState(Action.Reopen);

        Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Created));
    }

    [Test]
    public void ShouldNotChangeStatusWhenPayingForABookingWithPaidStatus()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Pay);
        booking.ChangeState(Action.Pay);

        Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Paid));
    }

    [Test]
    public void ShouldNotChangeStatusWhenCancelingABookingWithPaidStatus()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Pay);
        booking.ChangeState(Action.Cancel);

        Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Paid));
    }

    [Test]
    public void ShouldNotChangeStatusWhenFinishingABookingWithCreatedStatus()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Finish);

        Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Created));
    }

    [Test]
    public void ShouldNotChangeStatusWhenRefoundingABookingWithCreatedStatus()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Refound);

        Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Created));
    }

    [Test]
    public void ShouldNotChangeStatusWhenReopeningABookingWithCreatedStatus()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Reopen);

        Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Created));
    }

    [Test]
    public void ShouldNotChangeStatusWhenReopeningABookingWithPaidStatus()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Pay);
        booking.ChangeState(Action.Reopen);

        Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Paid));
    }
    [Test]
    public void ShouldNotChangeStatusWhenReopeningABookingWithFinishedStatus()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Pay);
        booking.ChangeState(Action.Finish);
        booking.ChangeState(Action.Reopen);

        Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Finished));
    }

    [Test]
    public void ShouldNotChangeStatusWhenReopeningABookingWithRefoundedStatus()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Pay);
        booking.ChangeState(Action.Refound);
        booking.ChangeState(Action.Reopen);

        Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Refounded));
    }

    [Test]
    public void ShouldNotChangeStatusWhenCancelingABookingWithCanceledStatus()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Cancel);
        booking.ChangeState(Action.Cancel);

        Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Cancelled));
    }

    [Test]
    public void ShouldNotChangeStatusWhenFinishingABookingWithCanceledStatus()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Cancel);
        booking.ChangeState(Action.Finish);

        Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Cancelled));
    }

    [Test]
    public void ShouldNotChangeStatusWhenRefoundingABookingWithCanceledStatus()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Cancel);
        booking.ChangeState(Action.Refound);

        Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Cancelled));
    }
    [Test]
    public void ShouldNotChangeStatusWhenFinishingABookingWithRefoundedStatus()
    {
        var booking = new Booking();
        booking.ChangeState(Action.Pay);
        booking.ChangeState(Action.Refound);
        booking.ChangeState(Action.Finish);

        Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Refounded));
    }
}
