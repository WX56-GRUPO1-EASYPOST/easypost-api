namespace easypost_api.ManageProject.Domain.Model.ValueObjects;

public interface IPublishable
{
    void SendToApproval();
    void Approve();
    void Reject();
    void ReturnToEdit();
}