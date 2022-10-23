
public class GameEvent
{

}

public static class GameEvents{
    public static CheckHotUpdateEndNotify CheckHotUpdateEndNotify = new CheckHotUpdateEndNotify();
    public static ShowBackButtonPanelNotify ShowBackButtonPanelNotify = new ShowBackButtonPanelNotify();
    public static CloseBackButtonPanelNotify CloseBackButtonPanelNotify = new CloseBackButtonPanelNotify();
}

public class CheckHotUpdateEndNotify : GameEvent{
        
}
public class ShowBackButtonPanelNotify : GameEvent{

}
public class CloseBackButtonPanelNotify : GameEvent{

}