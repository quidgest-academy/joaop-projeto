namespace quidgest.uitests.controls;
public interface IMenuControl
{
    void ActivateMenu(string moduleId, string itemId);

    void ActivateModule(string moduleId);

    public int GetMenuCount(string moduleId, string itemId);

    public int GetBookmarkCount();
}
