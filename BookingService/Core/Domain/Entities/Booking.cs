using Domain.Enums;
using Action = Domain.Enums.Action;

namespace Domain.Entities;

public class Booking
{
    public int Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    private Status Status { get; set; }
    public Status CurrentStatus { get { return Status; } }
    public Room Room { get; set; } = null!;
    public Guest Guest { get; set; } = null!;

    public Booking() => Status = Status.Created;

    public void ChangeState(Action action) => Status = (Status, action) switch
    {
        (Status.Created, Action.Pay) => Status.Paid,
        (Status.Created, Action.Cancel) => Status.Cancelled,
        (Status.Paid, Action.Finish) => Status.Finished,
        (Status.Paid, Action.Refound) => Status.Refounded,
        (Status.Cancelled, Action.Reopen) => Status.Created,
        _ => Status
        //_ => throw new InvalidOperationException($"Invalid transition from {Status} to {action}")
    };
}
